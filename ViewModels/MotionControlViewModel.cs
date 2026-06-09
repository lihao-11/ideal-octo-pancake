using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VisionMotionControl.Globals;
using VisionMotionControl.Models.MvvmModels;

namespace VisionMotionControl.ViewModels;

/// <summary>
/// 运动控制页面ViewModel
/// </summary>
public partial class MotionControlViewModel : ObservableObject
{
    [ObservableProperty]
    private AxisStateModel _axisX = new() { AxisNo = 0, AxisName = "X轴" };

    [ObservableProperty]
    private AxisStateModel _axisY = new() { AxisNo = 1, AxisName = "Y轴" };

    [ObservableProperty]
    private AxisStateModel _axisZ = new() { AxisNo = 2, AxisName = "Z轴" };

    [ObservableProperty]
    private double _jogSpeed = 10.0;

    [ObservableProperty]
    private double _targetX;

    [ObservableProperty]
    private double _targetY;

    [ObservableProperty]
    private double _targetZ;

    [ObservableProperty]
    private double _moveSpeed = 25.0;

    [ObservableProperty]
    private bool _isEmergencyStop;

    [RelayCommand]
    private void JogMove(string axisDirection)
    {
        var parts = axisDirection.Split(',');
        if (parts.Length != 2) return;
        var axisNo = int.Parse(parts[0]);
        var direction = int.Parse(parts[1]);
        GlobalVariables.MotionCard?.AxisJog(axisNo, JogSpeed * direction);
    }

    [RelayCommand]
    private void StopAxis(int axisNo)
    {
        GlobalVariables.MotionCard?.AxisStop(axisNo);
    }

    [RelayCommand]
    private void AbsMove()
    {
        GlobalVariables.MotionCard?.AxisAbsMove(TargetX, TargetY, TargetZ, MoveSpeed);
    }

    [RelayCommand]
    private void HomeAll()
    {
        GlobalVariables.MotionCard?.HomeAllAxis();
    }

    [RelayCommand]
    private void EmergencyStop()
    {
        IsEmergencyStop = true;
        GlobalVariables.MotionCard?.AllEmergencyStop();
    }
}
