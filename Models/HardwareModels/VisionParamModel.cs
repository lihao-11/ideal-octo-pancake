namespace VisionMotionControl.Models.HardwareModels;

/// <summary>
/// 视觉参数模型
/// </summary>
public class VisionParamModel
{
    public int Exposure { get; set; } = 1000;
    public double Gain { get; set; } = 6.0;
    public int Fps { get; set; } = 25;
    public string TriggerMode { get; set; } = "Soft";
    public int Width { get; set; } = 1920;
    public int Height { get; set; } = 1080;
    public double DetectThreshold { get; set; } = 0.7;
    public string TemplatePath { get; set; } = string.Empty;
}
