using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 运动配方实体
/// </summary>
[SugarTable("MotionRecipes")]
public class MotionRecipeEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(Length = 100, IsNullable = false)]
    public string RecipeName { get; set; } = string.Empty;

    [SugarColumn]
    public double AxisX { get; set; }

    [SugarColumn]
    public double AxisY { get; set; }

    [SugarColumn]
    public double AxisZ { get; set; }

    [SugarColumn]
    public double Speed { get; set; } = 25.0;

    [SugarColumn]
    public double Accel { get; set; } = 500.0;

    [SugarColumn]
    public double Decel { get; set; } = 500.0;

    [SugarColumn]
    public int UseCount { get; set; } = 0;

    [SugarColumn]
    public DateTime CreateTime { get; set; } = DateTime.Now;

    [SugarColumn]
    public DateTime? UpdateTime { get; set; }

    [SugarColumn(Length = 200)]
    public string Remark { get; set; } = string.Empty;
}
