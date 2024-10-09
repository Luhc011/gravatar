using System.Security.Cryptography;
using System.Text;

namespace VisaoPkg.Gravatar;

public static class GravatarExtension
{
    public static string ToGravatar(this string email)
    {
        if (string.IsNullOrEmpty(email))
            return string.Empty;

        using var md5 = MD5.Create();
        var inputBytes = Encoding.ASCII.GetBytes(email);
        var hashBytes = md5.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        foreach (var item in hashBytes)
            sb.Append(item.ToString("X2"));

        return $"https://gravatar.com.br/avatar/{sb.ToString().ToLower()}";

    }
}
