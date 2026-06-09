using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 日志实体
/// </summary>
[SugarTable("Logs")]
public class LogEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(IsNullable = false)]
    public DateTime LogTime { get; set; } = DateTime.Now;

    [SugarColumn(IsNullable = false)]
    public int LogType { get; set; }

    [SugarColumn(Length = 50)]
    public string DeviceNo { get; set; } = string.Empty;

    [SugarColumn(Length = 50)]
    public string OperateType { get; set; } = string.Empty;

    [SugarColumn(Length = 50)]
    public string Status { get; set; } = string.Empty;

    [SugarColumn(Length = 500)]
    public string Remark { get; set; } = string.Empty;

    [SugarColumn(Length = 50)]
    public string UserName { get; set; } = string.Empty;
}
