using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 用户实体
/// </summary>
[SugarTable("Users")]
public class UserEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(Length = 50, IsNullable = false)]
    public string UserName { get; set; } = string.Empty;

    [SugarColumn(Length = 100, IsNullable = false)]
    public string Password { get; set; } = string.Empty;

    [SugarColumn(Length = 50)]
    public string DisplayName { get; set; } = string.Empty;

    [SugarColumn(IsNullable = false)]
    public int Role { get; set; } = 3; // Visitor

    [SugarColumn(Length = 200)]
    public string Remark { get; set; } = string.Empty;

    [SugarColumn(IsNullable = false)]
    public DateTime CreateTime { get; set; } = DateTime.Now;

    [SugarColumn]
    public DateTime? LastLoginTime { get; set; }
}
