using VisionMotionControl.Helpers;
using VisionMotionControl.Models.HardwareModels;
using VisionMotionControl.MotionCtrl;

namespace VisionMotionControl.CadParse;

/// <summary>
/// 图纸坐标转运动坐标类
/// </summary>
public class DxfToMotionHelper
{
    private readonly DxfParseHelper _dxfParser;
    private readonly MotionCardHelper? _motionCard;

    public double OffsetX { get; set; } = 0.0;
    public double OffsetY { get; set; } = 0.0;
    public double ScaleFactor { get; set; } = 1.0;

    public DxfToMotionHelper(DxfParseHelper dxfParser, MotionCardHelper? motionCard = null)
    {
        _dxfParser = dxfParser;
        _motionCard = motionCard;
    }

    /// <summary>
    /// 将DXF点位转换为运动坐标并下发
    /// </summary>
    public bool ConvertAndSend(string dxfPath, double speed)
    {
        var points = _dxfParser.ParseDxfPoints(dxfPath);
        if (points.Count == 0)
        {
            LogHelper.Warn("无有效点位可下发");
            return false;
        }

        var motionPoints = points.Select(p => new AxisPoint(
            p.X * ScaleFactor + OffsetX,
            p.Y * ScaleFactor + OffsetY,
            p.Z)).ToList();

        LogHelper.Info($"转换完成，准备下发 {motionPoints.Count} 个点位");

        if (_motionCard != null)
        {
            foreach (var point in motionPoints)
            {
                _motionCard.AxisAbsMove(point.X, point.Y, point.Z, speed);
            }
        }

        return true;
    }
}
