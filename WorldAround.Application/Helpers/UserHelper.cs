namespace WorldAround.Application.Helpers;

public static class UserHelper
{
    public static bool IsEmail(string text)
    {
        return text.Contains('@');
    }
}
