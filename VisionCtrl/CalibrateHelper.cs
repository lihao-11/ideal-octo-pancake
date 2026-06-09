using System.IO;
using VisionMotionControl.Helpers;
using VisionMotionControl.Models.HardwareModels;

namespace VisionMotionControl.VisionCtrl;

/// <summary>
/// 手眼标定类
/// </summary>
public class CalibrateHelper
{
    private List<CalibPoint> _calibPoints = new();

    /// <summary>
    /// 标定参数
    /// </summary>
    public double PixelToMm { get; set; } = 0.025;
    public double OffsetX { get; set; } = 0.0;
    public double OffsetY { get; set; } = 0.0;
    public double RotationAngle { get; set; } = 0.0;

    /// <summary>
    /// 添加标定点
    /// </summary>
    public void AddCalibPoint(double pixelX, double pixelY, double machineX, double machineY)
    {
        _calibPoints.Add(new CalibPoint
        {
            PixelX = pixelX,
            PixelY = pixelY,
            MachineX = machineX,
            MachineY = machineY
        });
        LogHelper.Info($"添加标定点: Pixel({pixelX:F2},{pixelY:F2}) -> Machine({machineX:F3},{machineY:F3})");
    }

    /// <summary>
    /// 执行标定计算
    /// </summary>
    public bool CalculateCalibration()
    {
        if (_calibPoints.Count < 3)
        {
            LogHelper.Warn("标定点不足，至少需要3个点");
            return false;
        }
        // TODO: 最小二乘法计算标定参数
        LogHelper.Info($"标定完成: PixelToMm={PixelToMm:F6}, Offset=({OffsetX:F3},{OffsetY:F3})");
        return true;
    }

    /// <summary>
    /// 像素转机械坐标
    /// </summary>
    public AxisPoint PixelToMachine(double pixelX, double pixelY)
    {
        var rad = RotationAngle * Math.PI / 180.0;
        var rotX = pixelX * Math.Cos(rad) - pixelY * Math.Sin(rad);
        var rotY = pixelX * Math.Sin(rad) + pixelY * Math.Cos(rad);
        var machX = rotX * PixelToMm - OffsetX;
        var machY = rotY * PixelToMm - OffsetY;
        return new AxisPoint(machX, machY, 0);
    }

    /// <summary>
    /// 保存标定参数
    /// </summary>
    public void SaveCalibration(string filePath)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(new
        {
            PixelToMm,
            OffsetX,
            OffsetY,
            RotationAngle,
            PointCount = _calibPoints.Count
        });
        File.WriteAllText(filePath, json);
        LogHelper.Info($"标定参数已保存: {filePath}");
    }

    /// <summary>
    /// 加载标定参数
    /// </summary>
    public void LoadCalibration(string filePath)
    {
        if (!File.Exists(filePath)) return;
        var json = File.ReadAllText(filePath);
        // TODO: 反序列化标定参数
        LogHelper.Info($"标定参数已加载: {filePath}");
    }

    private class CalibPoint
    {
        public double PixelX { get; set; }
        public double PixelY { get; set; }
        public double MachineX { get; set; }
        public double MachineY { get; set; }
    }
}
