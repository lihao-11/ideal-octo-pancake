using VisionMotionControl.Globals;
using VisionMotionControl.Helpers;

namespace VisionMotionControl.MotionCtrl;

/// <summary>
/// 运动卡核心助手类
/// </summary>
public class MotionCardHelper
{
    private int _cardHandle = -1;
    private readonly System.Timers.Timer _statusTimer;

    public MotionCardHelper()
    {
        _statusTimer = new System.Timers.Timer(GlobalConstants.DEFAULT_READ_INTERVAL_MS);
        _statusTimer.Elapsed += (s, e) => ReadAxisStatus();
    }

    /// <summary>
    /// 连接ECI1408运动控制卡
    /// </summary>
    public bool ConnectCard()
    {
        try
        {
            LogHelper.Info($"正在连接运动卡: {GlobalVariables.MotionCardIp}");
            // TODO: 调用ZMC_API.OpenController
            GlobalVariables.MotionCardConnected = true;
            _statusTimer.Start();
            LogHelper.Info("运动卡连接成功");
            return true;
        }
        catch (Exception ex)
        {
            LogHelper.Error("运动卡连接异常", ex);
            GlobalVariables.MotionCardConnected = false;
            return false;
        }
    }

    /// <summary>
    /// 断开运动卡
    /// </summary>
    public void DisconnectCard()
    {
        _statusTimer.Stop();
        // TODO: 调用ZMC_API.CloseController
        GlobalVariables.MotionCardConnected = false;
        LogHelper.Info("运动卡已断开");
    }

    /// <summary>
    /// 三轴绝对定位运动
    /// </summary>
    public void AxisAbsMove(double x, double y, double z, double speed)
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info($"三轴绝对运动: X={x:F3}, Y={y:F3}, Z={z:F3}, Speed={speed}");
        // TODO: 调用ZMC_API.MultiAxisAbsMove
    }

    /// <summary>
    /// 三轴相对定位运动
    /// </summary>
    public void AxisRelMove(double x, double y, double z, double speed)
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info($"三轴相对运动: ΔX={x:F3}, ΔY={y:F3}, ΔZ={z:F3}");
        // TODO: 调用ZMC_API.MultiAxisRelMove
    }

    /// <summary>
    /// 单轴Jog运动
    /// </summary>
    public void AxisJog(int axisNo, double speed)
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info($"轴{axisNo} Jog运动, Speed={speed}");
        // TODO: 调用ZMC_API.AxisJog
    }

    /// <summary>
    /// 单轴停止
    /// </summary>
    public void AxisStop(int axisNo)
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info($"轴{axisNo} 停止");
        // TODO: 调用ZMC_API.AxisStop
    }

    /// <summary>
    /// 全局急停
    /// </summary>
    public void AllEmergencyStop()
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Warn("执行全局急停!");
        // TODO: 调用ZMC_API.StopAllAxis
    }

    /// <summary>
    /// 三轴回零
    /// </summary>
    public void HomeAllAxis()
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info("三轴回零开始");
        // TODO: 调用ZMC_API.HomeAxis
    }

    /// <summary>
    /// 读取轴状态
    /// </summary>
    private void ReadAxisStatus()
    {
        if (!GlobalVariables.MotionCardConnected) return;
        // TODO: 读取坐标、速度、限位状态等
    }

    /// <summary>
    /// 自动重连
    /// </summary>
    public async Task AutoReConnect(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            if (!GlobalVariables.MotionCardConnected)
            {
                ConnectCard();
            }
            await Task.Delay(2000, ct);
        }
    }
}
