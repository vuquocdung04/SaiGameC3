

public class RandomStringGenerator
{
    private const string chars = "qwertyuiopasdfghjklzxcvbnm123456789";

    public static string Generator(int length)
    {
        string randomString = "";
        for (int i = 0;i < length;i++)
        {
            randomString += chars[UnityEngine.Random.Range(0, chars.Length)];
        }
        return randomString;
    }
}
