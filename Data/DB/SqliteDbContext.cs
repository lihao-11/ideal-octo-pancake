using System.IO;
using SqlSugar;
using VisionMotionControl.Globals;
using VisionMotionControl.Models.Entities;

namespace VisionMotionControl.Data.DB;

/// <summary>
/// SQLite数据库上下文
/// </summary>
public static class SqliteDbContext
{
    public static SqlSugarScope? Db { get; private set; }

    /// <summary>
    /// 初始化数据库
    /// </summary>
    public static void InitDatabase()
    {
        try
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConstants.DATA_FOLDER, GlobalConstants.DB_FILE_NAME);
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

            var connectionString = $"Data Source={dbPath};Version=3;";

            Db = new SqlSugarScope(new ConnectionConfig
            {
                ConnectionString = connectionString,
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            },
            db =>
            {
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine($"[SQL] {sql}");
                };
            });

            // 自动建表
            Db.CodeFirst.InitTables(
                typeof(UserEntity),
                typeof(RoleAuthEntity),
                typeof(MotionRecipeEntity),
                typeof(VisionRecipeEntity),
                typeof(LinkTaskEntity),
                typeof(LogEntity),
                typeof(CalibrateEntity)
            );

            Console.WriteLine($"数据库初始化完成: {dbPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"数据库初始化失败: {ex.Message}");
        }
    }
}
