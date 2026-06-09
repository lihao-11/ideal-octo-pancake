using CommunityToolkit.Mvvm.ComponentModel;
using VisionMotionControl.Globals;

namespace VisionMotionControl.Models.MvvmModels;

/// <summary>
/// 轴状态MVVM模型
/// </summary>
public partial class AxisStateModel : ObservableObject
{
    [ObservableProperty]
    private int _axisNo;

    [ObservableProperty]
    private string _axisName = string.Empty;

    [ObservableProperty]
    private double _currentPosition;

    [ObservableProperty]
    private double _currentSpeed;

    [ObservableProperty]
    private AxisStatus _status = AxisStatus.Idle;

    [ObservableProperty]
    private bool _isEnabled;

    [ObservableProperty]
    private bool _hardLimitPositive;

    [ObservableProperty]
    private bool _hardLimitNegative;

    [ObservableProperty]
    private bool _softLimitTriggered;

    [ObservableProperty]
    private bool _isHomed;

    public string StatusText => Status switch
    {
        AxisStatus.Idle => "空闲",
        AxisStatus.Running => "运行中",
        AxisStatus.Stopped => "已停止",
        AxisStatus.Fault => "故障",
        AxisStatus.LimitTriggered => "限位触发",
        AxisStatus.Homing => "回零中",
        _ => "未知"
    };
}
