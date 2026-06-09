using System.Security.Cryptography;
using System.Text;

namespace VisionMotionControl.Helpers;

/// <summary>
/// 加密解密工具
/// </summary>
public static class EncryptHelper
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("VisionMotion2026");

    /// <summary>
    /// AES加密
    /// </summary>
    public static string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return string.Empty;

        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = new byte[16];

        var encryptor = aes.CreateEncryptor();
        var bytes = Encoding.UTF8.GetBytes(plainText);
        var encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        return Convert.ToBase64String(encrypted);
    }

    /// <summary>
    /// AES解密
    /// </summary>
    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return string.Empty;

        try
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = new byte[16];

            var decryptor = aes.CreateDecryptor();
            var bytes = Convert.FromBase64String(cipherText);
            var decrypted = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            return Encoding.UTF8.GetString(decrypted);
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// MD5哈希
    /// </summary>
    public static string Md5Hash(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = MD5.HashData(bytes);
        return Convert.ToHexString(hash);
    }
}
