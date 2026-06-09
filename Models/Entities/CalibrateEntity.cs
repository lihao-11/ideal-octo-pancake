using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 标定参数实体
/// </summary>
[SugarTable("CalibrateParams")]
public class CalibrateEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(Length = 100, IsNullable = false)]
    public string CalName { get; set; } = string.Empty;

    [SugarColumn]
    public double PixelToMm { get; set; } = 0.025;

    [SugarColumn]
    public double OffsetX { get; set; } = 0.0;

    [SugarColumn]
    public double OffsetY { get; set; } = 0.0;

    [SugarColumn]
    public double Angle { get; set; } = 0.0;

    [SugarColumn]
    public DateTime CalibrateDate { get; set; } = DateTime.Now;

    [SugarColumn]
    public bool IsDefault { get; set; } = false;
}
