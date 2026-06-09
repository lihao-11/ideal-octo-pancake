using System.Collections.Concurrent;
using VisionMotionControl.MotionCtrl;
using VisionMotionControl.VisionCtrl;
using VisionMotionControl.MqttClient;

namespace VisionMotionControl.Globals;

/// <summary>
/// 全局变量与实例管理
/// </summary>
public static class GlobalVariables
{
    #region 运动控制全局实例
    public static string MotionCardIp { get; set; } = "192.168.1.200";
    public static int MotionReadInterval { get; set; } = 200;
    public static MotionCardHelper? MotionCard { get; set; }
    public static ConcurrentDictionary<string, int> MotionWriteDic { get; set; } = new();
    public static ConcurrentDictionary<string, object> MotionReadDic { get; set; } = new();
    public static bool MotionCardConnected { get; set; } = false;
    #endregion

    #region 机器视觉全局实例
    public static string CameraIp { get; set; } = "192.168.1.201";
    public static CameraHelper? Camera { get; set; }
    public static bool CameraConnected { get; set; } = false;
    #endregion

    #region MQTT全局实例
    public static MqttClientHelper? MqttClient { get; set; }
    public static bool MqttConnected { get; set; } = false;
    #endregion

    #region 系统全局
    public static string CurrentUserName { get; set; } = string.Empty;
    public static UserRole CurrentUserRole { get; set; } = UserRole.Visitor;
    public static CancellationTokenSource SystemCts { get; set; } = new();
    public static bool IsSystemRunning { get; set; } = false;
    public static string CurrentRecipeName { get; set; } = string.Empty;
    #endregion

    #region 联动全局
    public static bool IsLinkRunning { get; set; } = false;
    public static bool AutoCompensationEnabled { get; set; } = true;
    public static double CompensationThreshold { get; set; } = 0.05;
    #endregion
}
