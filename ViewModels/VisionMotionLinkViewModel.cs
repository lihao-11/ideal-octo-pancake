using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VisionMotionControl.Globals;
using VisionMotionControl.Models.MvvmModels;
using System.Collections.ObjectModel;

namespace VisionMotionControl.ViewModels;

/// <summary>
/// 视运联动页面ViewModel
/// </summary>
public partial class VisionMotionLinkViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<LinkFlowModel> _linkFlowSteps = new();

    [ObservableProperty]
    private bool _isLinkRunning;

    [ObservableProperty]
    private bool _autoCompensation = true;

    [ObservableProperty]
    private double _compensationThreshold = 0.05;

    public VisionMotionLinkViewModel()
    {
        // 初始化联动流程步骤
        LinkFlowSteps.Add(new LinkFlowModel { StepNo = 1, StepName = "视觉定位" });
        LinkFlowSteps.Add(new LinkFlowModel { StepNo = 2, StepName = "坐标转换" });
        LinkFlowSteps.Add(new LinkFlowModel { StepNo = 3, StepName = "补偿计算" });
        LinkFlowSteps.Add(new LinkFlowModel { StepNo = 4, StepName = "运动执行" });
        LinkFlowSteps.Add(new LinkFlowModel { StepNo = 5, StepName = "结果检测" });
    }

    [RelayCommand]
    private async Task StartLinkFlow()
    {
        IsLinkRunning = true;
        GlobalVariables.IsLinkRunning = true;

        foreach (var step in LinkFlowSteps)
        {
            step.Status = LinkStepStatus.Executing;
            await Task.Delay(500); // 模拟执行
            step.Status = LinkStepStatus.Completed;
        }

        IsLinkRunning = false;
        GlobalVariables.IsLinkRunning = false;
    }

    [RelayCommand]
    private void StopLinkFlow()
    {
        IsLinkRunning = false;
        GlobalVariables.IsLinkRunning = false;
    }

    [RelayCommand]
    private void ResetFlow()
    {
        foreach (var step in LinkFlowSteps)
        {
            step.Status = LinkStepStatus.Waiting;
            step.Result = string.Empty;
        }
    }
}
