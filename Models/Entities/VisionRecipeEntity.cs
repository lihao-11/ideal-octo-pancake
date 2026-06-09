using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 视觉配方实体
/// </summary>
[SugarTable("VisionRecipes")]
public class VisionRecipeEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(Length = 100, IsNullable = false)]
    public string RecipeName { get; set; } = string.Empty;

    [SugarColumn]
    public int Exposure { get; set; } = 1000;

    [SugarColumn]
    public double Gain { get; set; } = 6.0;

    [SugarColumn]
    public int Fps { get; set; } = 25;

    [SugarColumn(Length = 200)]
    public string TemplatePath { get; set; } = string.Empty;

    [SugarColumn]
    public double DetectThreshold { get; set; } = 0.7;

    [SugarColumn]
    public DateTime CreateTime { get; set; } = DateTime.Now;

    [SugarColumn]
    public DateTime? UpdateTime { get; set; }
}
