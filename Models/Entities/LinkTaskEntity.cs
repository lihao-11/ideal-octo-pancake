using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 联动任务实体
/// </summary>
[SugarTable("LinkTasks")]
public class LinkTaskEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(Length = 100, IsNullable = false)]
    public string TaskName { get; set; } = string.Empty;

    [SugarColumn(Length = 500)]
    public string DxfPath { get; set; } = string.Empty;

    [SugarColumn(Length = 2000)]
    public string LinkFlow { get; set; } = string.Empty;

    [SugarColumn]
    public int ExecuteCount { get; set; } = 0;

    [SugarColumn]
    public double YieldRate { get; set; } = 0.0;

    [SugarColumn]
    public DateTime CreateTime { get; set; } = DateTime.Now;
}
