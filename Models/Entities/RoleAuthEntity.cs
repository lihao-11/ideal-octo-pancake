using SqlSugar;

namespace VisionMotionControl.Models.Entities;

/// <summary>
/// 角色权限实体
/// </summary>
[SugarTable("RoleAuth")]
public class RoleAuthEntity
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(IsNullable = false)]
    public int Role { get; set; }

    [SugarColumn]
    public bool MotionAuth { get; set; } = false;

    [SugarColumn]
    public bool VisionAuth { get; set; } = false;

    [SugarColumn]
    public bool RecipeAuth { get; set; } = false;

    [SugarColumn]
    public bool MqttAuth { get; set; } = false;

    [SugarColumn]
    public bool UserManageAuth { get; set; } = false;

    [SugarColumn]
    public bool ConfigAuth { get; set; } = false;
}
