namespace MovieStore.App.TokenOperations;

public class Token
{
    public string AccessToken { get; set; }

    public DateTime ExpireTime { get; set; }

    public string RefreshToken { get; set; }
}