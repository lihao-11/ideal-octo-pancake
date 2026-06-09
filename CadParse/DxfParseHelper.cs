using System.IO;
using VisionMotionControl.Helpers;
using VisionMotionControl.Models.HardwareModels;

namespace VisionMotionControl.CadParse;

/// <summary>
/// DXF解析核心类
/// </summary>
public class DxfParseHelper
{
    /// <summary>
    /// 解析DXF文件提取点位
    /// </summary>
    public List<AxisPoint> ParseDxfPoints(string dxfPath)
    {
        var points = new List<AxisPoint>();
        if (!File.Exists(dxfPath))
        {
            LogHelper.Warn($"DXF文件不存在: {dxfPath}");
            return points;
        }

        try
        {
            LogHelper.Info($"解析DXF文件: {dxfPath}");
            // TODO: 使用netDxf库解析DXF文件
            // DxfDocument dxfDoc = DxfDocument.Load(dxfPath);
            // foreach (var entity in dxfDoc.Entities.Points) { ... }

            // 模拟数据
            points.Add(new AxisPoint(120.0, 45.0, 0));
            points.Add(new AxisPoint(240.0, 45.0, 0));
            points.Add(new AxisPoint(240.0, 180.0, 0));
            points.Add(new AxisPoint(120.0, 180.0, 0));
            points.Add(new AxisPoint(120.0, 45.0, 0));

            LogHelper.Info($"提取到 {points.Count} 个点位");
        }
        catch (Exception ex)
        {
            LogHelper.Error("DXF解析失败", ex);
        }
        return points;
    }

    /// <summary>
    /// 解析DXF直线
    /// </summary>
    public List<(AxisPoint start, AxisPoint end)> ParseDxfLines(string dxfPath)
    {
        var lines = new List<(AxisPoint, AxisPoint)>();
        // TODO: 解析DXF直线实体
        return lines;
    }

    /// <summary>
    /// 解析DXF圆弧
    /// </summary>
    public List<(AxisPoint center, double radius, double startAngle, double endAngle)> ParseDxfArcs(string dxfPath)
    {
        var arcs = new List<(AxisPoint, double, double, double)>();
        // TODO: 解析DXF圆弧实体
        return arcs;
    }
}
