namespace VisionMotionControl.Globals;

/// <summary>
/// 全局常量定义
/// </summary>
public static class GlobalConstants
{
    #region 运动控制默认参数
    public const double DEFAULT_PULSE_UNIT = 0.001;
    public const double DEFAULT_SPEED = 25.0;
    public const double DEFAULT_ACCEL = 500.0;
    public const double DEFAULT_DECEL = 500.0;
    public const int DEFAULT_READ_INTERVAL_MS = 200;
    public const int MOTION_CARD_PORT = 502;
    #endregion

    #region 相机默认参数
    public const int DEFAULT_EXPOSURE_US = 1000;
    public const double DEFAULT_GAIN_DB = 6.0;
    public const int DEFAULT_FPS = 25;
    public const int DEFAULT_ACQUISITION_TIMEOUT_MS = 1000;
    #endregion

    #region MQTT默认参数
    public const int DEFAULT_MQTT_PORT = 1883;
    public const int DEFAULT_MQTT_KEEPALIVE_S = 60;
    public const int DEFAULT_MQTT_RECONNECT_INTERVAL_MS = 5000;
    #endregion

    #region 系统参数
    public const int DEFAULT_LOG_RETENTION_DAYS = 30;
    public const int DEFAULT_COORDINATE_UPDATE_INTERVAL_MS = 200;
    public const double DEFAULT_COMPENSATION_THRESHOLD_MM = 0.05;
    public const double DEFAULT_LINK_DELAY_MS = 100;
    public const int MAX_EXPORT_ROWS = 100000;
    #endregion

    #region 文件路径
    public const string CONFIG_FOLDER = "Config";
    public const string DATA_FOLDER = "Data";
    public const string LOG_FOLDER = "Logs";
    public const string TEMPLATE_FOLDER = "Templates";
    public const string DB_FILE_NAME = "vision_motion.db";
    #endregion

    #region 限位与急停
    public const double SOFT_LIMIT_X_MIN = 0.0;
    public const double SOFT_LIMIT_X_MAX = 300.0;
    public const double SOFT_LIMIT_Y_MIN = 0.0;
    public const double SOFT_LIMIT_Y_MAX = 200.0;
    public const double SOFT_LIMIT_Z_MIN = 0.0;
    public const double SOFT_LIMIT_Z_MAX = 50.0;
    #endregion
}
