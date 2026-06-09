namespace VisionMotionControl.Models.HardwareModels;

/// <summary>
/// 轴参数模型
/// </summary>
public class MotionParamModel
{
    public double PulseUnit { get; set; } = 0.001;
    public double Speed { get; set; } = 25.0;
    public double Accel { get; set; } = 500.0;
    public double Decel { get; set; } = 500.0;
    public double SoftLimitXMin { get; set; } = 0.0;
    public double SoftLimitXMax { get; set; } = 300.0;
    public double SoftLimitYMin { get; set; } = 0.0;
    public double SoftLimitYMax { get; set; } = 200.0;
    public double SoftLimitZMin { get; set; } = 0.0;
    public double SoftLimitZMax { get; set; } = 50.0;
    public int IoInputCount { get; set; } = 16;
    public int IoOutputCount { get; set; } = 16;
}
