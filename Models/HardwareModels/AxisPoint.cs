namespace VisionMotionControl.Models.HardwareModels;

/// <summary>
/// 三轴坐标点
/// </summary>
public class AxisPoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public AxisPoint() { }

    public AxisPoint(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString() => $"X:{X:F3}, Y:{Y:F3}, Z:{Z:F3}";
}
