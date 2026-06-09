using System.IO;
using IniParser.Model;
using IniParser;

namespace VisionMotionControl.Helpers;

/// <summary>
/// 配置文件读写工具
/// </summary>
public static class ConfigHelper
{
    private static readonly string ConfigDirectory;

    static ConfigHelper()
    {
        ConfigDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
        Directory.CreateDirectory(ConfigDirectory);
    }

    /// <summary>
    /// 读取INI配置
    /// </summary>
    public static string? ReadIni(string fileName, string section, string key, string? defaultValue = null)
    {
        var filePath = Path.Combine(ConfigDirectory, fileName);
        if (!File.Exists(filePath)) return defaultValue;

        var parser = new FileIniDataParser();
        var data = parser.ReadFile(filePath);
        return data[section][key] ?? defaultValue;
    }

    /// <summary>
    /// 写入INI配置
    /// </summary>
    public static void WriteIni(string fileName, string section, string key, string value)
    {
        var filePath = Path.Combine(ConfigDirectory, fileName);
        var parser = new FileIniDataParser();
        IniData data;

        if (File.Exists(filePath))
        {
            data = parser.ReadFile(filePath);
        }
        else
        {
            data = new IniData();
        }

        data[section][key] = value;
        parser.WriteFile(filePath, data);
    }

    /// <summary>
    /// 读取JSON配置
    /// </summary>
    public static T? ReadJson<T>(string fileName) where T : class
    {
        var filePath = Path.Combine(ConfigDirectory, fileName);
        if (!File.Exists(filePath)) return null;

        var json = File.ReadAllText(filePath);
        return System.Text.Json.JsonSerializer.Deserialize<T>(json);
    }

    /// <summary>
    /// 写入JSON配置
    /// </summary>
    public static void WriteJson<T>(string fileName, T obj) where T : class
    {
        var filePath = Path.Combine(ConfigDirectory, fileName);
        var json = System.Text.Json.JsonSerializer.Serialize(obj, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, json);
    }
}
