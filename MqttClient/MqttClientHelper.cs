using System.Text;
using System.Text.Json;
using VisionMotionControl.Globals;
using VisionMotionControl.Helpers;

namespace VisionMotionControl.MqttClient;

/// <summary>
/// MQTT客户端封装类
/// </summary>
public class MqttClientHelper
{
    private object? _mqttClient;
    private readonly System.Timers.Timer _reconnectTimer;
    private readonly System.Timers.Timer _publishTimer;

    public string ServerIp { get; set; } = "mqtt.example.com";
    public int Port { get; set; } = 1883;
    public string ClientId { get; set; } = "VisionMotionClient";
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string SubscribeTopic { get; set; } = "motion/cmd";
    public string PublishTopic { get; set; } = "motion/status";

    /// <summary>
    /// 收到远程指令事件
    /// </summary>
    public event EventHandler<string>? OnCommandReceived;

    public MqttClientHelper()
    {
        _reconnectTimer = new System.Timers.Timer(GlobalConstants.DEFAULT_MQTT_RECONNECT_INTERVAL_MS);
        _reconnectTimer.Elapsed += (s, e) => TryReconnect();

        _publishTimer = new System.Timers.Timer(1000);
        _publishTimer.Elapsed += (s, e) => PublishStatus();
    }

    /// <summary>
    /// 连接MQTT服务器
    /// </summary>
    public bool Connect()
    {
        try
        {
            LogHelper.Info($"连接MQTT: {ServerIp}:{Port}");
            // TODO: 使用M2Mqtt连接
            GlobalVariables.MqttConnected = true;
            _publishTimer.Start();
            LogHelper.Info("MQTT连接成功");
            return true;
        }
        catch (Exception ex)
        {
            LogHelper.Error("MQTT连接失败", ex);
            _reconnectTimer.Start();
            return false;
        }
    }

    /// <summary>
    /// 断开连接
    /// </summary>
    public void Disconnect()
    {
        _reconnectTimer.Stop();
        _publishTimer.Stop();
        // TODO: 断开MQTT
        GlobalVariables.MqttConnected = false;
        LogHelper.Info("MQTT已断开");
    }

    /// <summary>
    /// 发布消息
    /// </summary>
    public void Publish(string topic, string payload)
    {
        if (!GlobalVariables.MqttConnected) return;
        // TODO: 使用M2Mqtt发布
        LogHelper.Debug($"MQTT发布: {topic} -> {payload}");
    }

    /// <summary>
    /// 订阅主题
    /// </summary>
    public void Subscribe(string topic)
    {
        if (!GlobalVariables.MqttConnected) return;
        // TODO: 使用M2Mqtt订阅
        LogHelper.Info($"MQTT订阅: {topic}");
    }

    /// <summary>
    /// 自动重连
    /// </summary>
    private void TryReconnect()
    {
        if (GlobalVariables.MqttConnected) return;
        LogHelper.Info("MQTT尝试重连...");
        Connect();
    }

    /// <summary>
    /// 定时发布设备状态
    /// </summary>
    private void PublishStatus()
    {
        if (!GlobalVariables.MqttConnected) return;
        var status = new
        {
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            MotionConnected = GlobalVariables.MotionCardConnected,
            CameraConnected = GlobalVariables.CameraConnected,
            X = GlobalVariables.MotionReadDic.TryGetValue("X", out var x) ? x : 0,
            Y = GlobalVariables.MotionReadDic.TryGetValue("Y", out var y) ? y : 0,
            Z = GlobalVariables.MotionReadDic.TryGetValue("Z", out var z) ? z : 0
        };
        Publish(PublishTopic, JsonSerializer.Serialize(status));
    }
}
