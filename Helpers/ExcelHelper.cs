namespace VisionMotionControl.Helpers;

/// <summary>
/// Excel导入导出工具
/// </summary>
public static class ExcelHelper
{
    /// <summary>
    /// 导出数据到Excel
    /// </summary>
    public static void ExportToExcel<T>(List<T> data, string filePath, string sheetName = "Sheet1")
    {
        // TODO: 使用NPOI实现Excel导出
        LogHelper.Info($"导出Excel: {filePath}, 记录数: {data.Count}");
    }

    /// <summary>
    /// 从Excel导入数据
    /// </summary>
    public static List<T> ImportFromExcel<T>(string filePath, string sheetName = "Sheet1") where T : new()
    {
        // TODO: 使用NPOI实现Excel导入
        LogHelper.Info($"导入Excel: {filePath}");
        return new List<T>();
    }
}
