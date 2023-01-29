using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Entities;
using WorldAround.Domain.Models.Attractions;

namespace WorldAround.Application.Services;

public class AttractionsService : IAttractionsService
{
    private readonly IWorldAroundDbContext _context;
    private readonly IMapper _mapper;
    private readonly IBlobStorageGateway _blobStorageGateway;

    public AttractionsService(
        IWorldAroundDbContext context,
        IMapper mapper,
        IBlobStorageGateway blobStorageGateway)
    {
        _context = context;
        _mapper = mapper;
        _blobStorageGateway = blobStorageGateway;
    }

    public async Task<GetAttractionModel> GetAttractionAsync(int attractionId, CancellationToken cancellationToken)
    {
        var attraction = await _context.Attractions
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == attractionId, cancellationToken);

        return _mapper.Map<GetAttractionModel>(attraction);
    }

    public async Task<GetAttractionsModel> GetAttractionsAsync(GetAttractionsParams @params, CancellationToken cancellationToken)
    {
        var attractionsQuery = _context.Attractions.AsQueryable();

        if (@params.UserId is not null)
        {
            attractionsQuery = attractionsQuery.Where(x => x.AuthorId == @params.UserId);
        }

        if (!string.IsNullOrWhiteSpace(@params.SearchValue))
        {
            var searchValue = @params.SearchValue.ToLower();
            attractionsQuery = attractionsQuery.Where(x =>
                x.Name.ToLower().Contains(searchValue) || x.Description.ToLower().Contains(searchValue));
        }

        var result = await _context.Attractions.Select(x => new GetAttractionsModel
        {
            Data = attractionsQuery
                .Skip(@params.PageIndex * @params.PageSize)
                .Take(@params.PageSize)
                .Select(attraction => new AttractionModel
                {
                    Id = attraction.Id,
                    Name = attraction.Name,
                    AuthorId = attraction.AuthorId,
                    AuthorName = attraction.Author.FirstName + " " + attraction.Author.LastName,
                    CommentsCount = attraction.Comments.Count,
                    ImagePath = attraction.Images.Any()
                        ? attraction.Images.First().ImagePath
                        : string.Empty,
                    Rating = attraction.Ratings.Any()
                        ? attraction.Ratings.Select(rating => rating.Value).Average()
                        : 0
                })
                .ToArray(),
            Length = attractionsQuery.Count()
        }).FirstOrDefaultAsync(cancellationToken);

        return result;
    }

    public async Task CreateAttractionAsync(CreateAttractionModel createAttractionModel)
    {
        var blobName =
            $"Attraction{createAttractionModel.AuthorId}_{DateTime.Now.ToFileTime()}_{createAttractionModel.Image.FileName}";

        await _blobStorageGateway.UploadImageAsync(blobName, createAttractionModel.Image);

        var attraction = new Attraction
        {
            AuthorId = createAttractionModel.AuthorId,
            Name = createAttractionModel.Name,
            Description = createAttractionModel.Description,
            Latitude = createAttractionModel.Latitude,
            Longitude = createAttractionModel.Longitude,
            Images = new List<Image>
            {
                new()
                {
                    ImagePath = blobName
                }
            }
        };

        _context.Attractions.Add(attraction);
        await _context.SaveChangesAsync();
    }
}
