using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VisionMotionControl.Globals;
using VisionMotionControl.Models.MvvmModels;

namespace VisionMotionControl.ViewModels;

/// <summary>
/// 视觉检测页面ViewModel
/// </summary>
public partial class VisionDetectViewModel : ObservableObject
{
    [ObservableProperty]
    private CameraParamModel _cameraParam = new();

    [ObservableProperty]
    private bool _isAcquiring;

    [ObservableProperty]
    private double _detectResultX;

    [ObservableProperty]
    private double _detectResultY;

    [ObservableProperty]
    private double _detectScore;

    [RelayCommand]
    private void ConnectCamera()
    {
        GlobalVariables.Camera?.ConnectCamera();
    }

    [RelayCommand]
    private void StartAcquisition()
    {
        IsAcquiring = true;
        GlobalVariables.Camera?.StartContinuousAcquisition();
    }

    [RelayCommand]
    private void StopAcquisition()
    {
        IsAcquiring = false;
        GlobalVariables.Camera?.StopContinuousAcquisition();
    }

    [RelayCommand]
    private void SingleTrigger()
    {
        GlobalVariables.Camera?.GrabSingleImage();
    }

    [RelayCommand]
    private void ApplyCameraParam()
    {
        GlobalVariables.Camera?.SetExposure(CameraParam.Exposure);
        GlobalVariables.Camera?.SetGain(CameraParam.Gain);
    }
}
