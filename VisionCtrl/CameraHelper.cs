using VisionMotionControl.Globals;
using VisionMotionControl.Helpers;

namespace VisionMotionControl.VisionCtrl;

/// <summary>
/// 水星相机封装类
/// </summary>
public class CameraHelper
{
    private bool _isConnected = false;
    private readonly System.Timers.Timer _acquisitionTimer;

    public CameraHelper()
    {
        _acquisitionTimer = new System.Timers.Timer(40); // 25fps
        _acquisitionTimer.Elapsed += (s, e) => OnFrameAcquired?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// 图像采集事件
    /// </summary>
    public event EventHandler? OnFrameAcquired;

    /// <summary>
    /// 连接相机
    /// </summary>
    public bool ConnectCamera()
    {
        try
        {
            LogHelper.Info($"正在连接相机: {GlobalVariables.CameraIp}");
            // TODO: 调用Galaxy SDK枚举并连接相机
            _isConnected = true;
            GlobalVariables.CameraConnected = true;
            LogHelper.Info("相机连接成功");
            return true;
        }
        catch (Exception ex)
        {
            LogHelper.Error("相机连接异常", ex);
            _isConnected = false;
            GlobalVariables.CameraConnected = false;
            return false;
        }
    }

    /// <summary>
    /// 断开相机
    /// </summary>
    public void DisconnectCamera()
    {
        _acquisitionTimer.Stop();
        // TODO: 断开相机
        _isConnected = false;
        GlobalVariables.CameraConnected = false;
        LogHelper.Info("相机已断开");
    }

    /// <summary>
    /// 单帧采集
    /// </summary>
    public byte[]? GrabSingleImage()
    {
        if (!_isConnected) return null;
        // TODO: 调用Galaxy SDK采集单帧
        return null;
    }

    /// <summary>
    /// 开始连续采集
    /// </summary>
    public void StartContinuousAcquisition()
    {
        if (!_isConnected) return;
        _acquisitionTimer.Start();
        LogHelper.Info("开始连续采集");
    }

    /// <summary>
    /// 停止连续采集
    /// </summary>
    public void StopContinuousAcquisition()
    {
        _acquisitionTimer.Stop();
        LogHelper.Info("停止连续采集");
    }

    /// <summary>
    /// 设置曝光
    /// </summary>
    public void SetExposure(int exposureUs)
    {
        if (!_isConnected) return;
        LogHelper.Info($"设置曝光: {exposureUs}us");
        // TODO: 设置相机曝光
    }

    /// <summary>
    /// 设置增益
    /// </summary>
    public void SetGain(double gainDb)
    {
        if (!_isConnected) return;
        LogHelper.Info($"设置增益: {gainDb}dB");
        // TODO: 设置相机增益
    }
}
