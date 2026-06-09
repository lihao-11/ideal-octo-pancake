using System.Windows.Controls;
using VisionMotionControl.Globals;
using VisionMotionControl.Models.MvvmModels;

namespace VisionMotionControl.Controls;

public partial class UC_AxisState : UserControl
{
    public UC_AxisState()
    {
        InitializeComponent();
    }

    public void UpdateState(AxisStateModel state)
    {
        AxisNameText.Text = state.AxisName;
        PositionText.Text = state.CurrentPosition.ToString("F3");
        SpeedText.Text = state.CurrentSpeed.ToString("F3");
        StatusText.Text = state.StatusText;

        StatusBorder.Background = state.Status switch
        {
            AxisStatus.Idle => new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(16, 185, 129)) { Opacity = 0.15 },
            AxisStatus.Running => new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 130, 246)) { Opacity = 0.15 },
            AxisStatus.Fault => new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(239, 68, 68)) { Opacity = 0.15 },
            _ => new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 85, 105)) { Opacity = 0.15 }
        };

        LimitPosEllipse.Fill = state.HardLimitPositive
            ? System.Windows.Media.Brushes.Red
            : new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 85, 105));

        LimitNegEllipse.Fill = state.HardLimitNegative
            ? System.Windows.Media.Brushes.Red
            : new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 85, 105));

        HomeEllipse.Fill = state.IsHomed
            ? System.Windows.Media.Brushes.Green
            : new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 85, 105));
    }
}
