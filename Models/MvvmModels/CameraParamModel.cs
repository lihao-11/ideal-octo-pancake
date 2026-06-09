using CommunityToolkit.Mvvm.ComponentModel;
using VisionMotionControl.Globals;

namespace VisionMotionControl.Models.MvvmModels;

/// <summary>
/// 相机参数MVVM模型
/// </summary>
public partial class CameraParamModel : ObservableObject
{
    [ObservableProperty]
    private string _cameraName = string.Empty;

    [ObservableProperty]
    private string _cameraIp = string.Empty;

    [ObservableProperty]
    private CameraStatus _status = CameraStatus.Disconnected;

    [ObservableProperty]
    private int _exposure = 1000;

    [ObservableProperty]
    private double _gain = 6.0;

    [ObservableProperty]
    private int _fps = 25;

    [ObservableProperty]
    private int _imageWidth = 1920;

    [ObservableProperty]
    private int _imageHeight = 1080;

    [ObservableProperty]
    private string _triggerMode = "软触发";

    public string StatusText => Status switch
    {
        CameraStatus.Disconnected => "未连接",
        CameraStatus.Connected => "已连接",
        CameraStatus.Acquiring => "采集中",
        CameraStatus.Error => "错误",
        _ => "未知"
    };
}
