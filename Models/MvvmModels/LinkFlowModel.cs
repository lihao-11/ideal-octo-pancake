using CommunityToolkit.Mvvm.ComponentModel;
using VisionMotionControl.Globals;

namespace VisionMotionControl.Models.MvvmModels;

/// <summary>
/// 联动流程步骤模型
/// </summary>
public partial class LinkFlowModel : ObservableObject
{
    [ObservableProperty]
    private int _stepNo;

    [ObservableProperty]
    private string _stepName = string.Empty;

    [ObservableProperty]
    private LinkStepStatus _status = LinkStepStatus.Waiting;

    [ObservableProperty]
    private string _result = string.Empty;

    public string StatusText => Status switch
    {
        LinkStepStatus.Waiting => "等待",
        LinkStepStatus.Executing => "执行中",
        LinkStepStatus.Completed => "已完成",
        LinkStepStatus.Failed => "失败",
        _ => "未知"
    };
}
