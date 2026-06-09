using System.IO;

namespace VisionMotionControl.Helpers;

/// <summary>
/// 日志记录工具
/// </summary>
public static class LogHelper
{
    private static readonly string LogDirectory;
    private static readonly object LockObj = new();

    static LogHelper()
    {
        LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        Directory.CreateDirectory(LogDirectory);
    }

    /// <summary>
    /// 记录信息日志
    /// </summary>
    public static void Info(string message)
    {
        WriteLog("INFO", message);
    }

    /// <summary>
    /// 记录警告日志
    /// </summary>
    public static void Warn(string message)
    {
        WriteLog("WARN", message);
    }

    /// <summary>
    /// 记录错误日志
    /// </summary>
    public static void Error(string message, Exception? ex = null)
    {
        var fullMsg = ex != null ? $"{message} | Exception: {ex.Message}" : message;
        WriteLog("ERROR", fullMsg);
    }

    /// <summary>
    /// 记录调试日志
    /// </summary>
    public static void Debug(string message)
    {
#if DEBUG
        WriteLog("DEBUG", message);
#endif
    }

    private static void WriteLog(string level, string message)
    {
        var logFile = Path.Combine(LogDirectory, $"{DateTime.Now:yyyyMMdd}.log");
        var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level}] {message}";

        lock (LockObj)
        {
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }

        Console.WriteLine(logEntry);
    }
}
