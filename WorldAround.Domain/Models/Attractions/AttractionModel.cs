using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldAround.Domain.Models.Attractions;

public class AttractionModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? AuthorId { get; set; }
    public string AuthorName { get; set; }

    public int CommentsCount { get; set; }
    public double Rating { get; set; }

    public string ImagePath { get; set; }
}