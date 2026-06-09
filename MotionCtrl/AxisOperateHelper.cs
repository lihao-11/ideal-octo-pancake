using VisionMotionControl.Globals;
using VisionMotionControl.Helpers;

namespace VisionMotionControl.MotionCtrl;

/// <summary>
/// 三轴操作类
/// </summary>
public class AxisOperateHelper
{
    private readonly MotionCardHelper _motionCard;

    public AxisOperateHelper(MotionCardHelper motionCard)
    {
        _motionCard = motionCard;
    }

    /// <summary>
    /// 单轴绝对定位
    /// </summary>
    public void SingleAxisAbsMove(int axisNo, double position, double speed)
    {
        LogHelper.Info($"轴{axisNo}绝对定位: {position:F3}mm, 速度{speed}mm/s");
        // TODO: 调用底层SDK
    }

    /// <summary>
    /// 单轴相对定位
    /// </summary>
    public void SingleAxisRelMove(int axisNo, double distance, double speed)
    {
        LogHelper.Info($"轴{axisNo}相对定位: {distance:F3}mm");
        // TODO: 调用底层SDK
    }

    /// <summary>
    /// 单轴点动
    /// </summary>
    public void SingleAxisJog(int axisNo, double speed)
    {
        _motionCard.AxisJog(axisNo, speed);
    }

    /// <summary>
    /// 单轴回零
    /// </summary>
    public void SingleAxisHome(int axisNo)
    {
        LogHelper.Info($"轴{axisNo}回零");
        // TODO: 调用底层SDK
    }

    /// <summary>
    /// 检查限位状态
    /// </summary>
    public bool CheckLimitStatus(int axisNo)
    {
        // TODO: 读取限位状态
        return false;
    }

    /// <summary>
    /// 三轴直线插补
    /// </summary>
    public void LinearInterpolation(double x, double y, double z, double speed)
    {
        LogHelper.Info($"直线插补: X={x:F3}, Y={y:F3}, Z={z:F3}");
        _motionCard.AxisAbsMove(x, y, z, speed);
    }
}
