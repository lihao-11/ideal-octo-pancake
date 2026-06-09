namespace VisionMotionControl.Globals;

/// <summary>
/// 轴状态枚举
/// </summary>
public enum AxisStatus
{
    Idle = 0,
    Running = 1,
    Stopped = 2,
    Fault = 3,
    LimitTriggered = 4,
    Homing = 5
}

/// <summary>
/// 相机状态枚举
/// </summary>
public enum CameraStatus
{
    Disconnected = 0,
    Connected = 1,
    Acquiring = 2,
    Error = 3
}

/// <summary>
/// 日志类型枚举
/// </summary>
public enum LogType
{
    Motion = 0,
    Vision = 1,
    Operation = 2,
    Link = 3,
    Alarm = 4,
    System = 5
}

/// <summary>
/// 授权类型枚举
/// </summary>
public enum AuthType
{
    Trial = 0,
    Permanent = 1,
    Expired = 2
}

/// <summary>
/// 运动模式枚举
/// </summary>
public enum MotionMode
{
    Jog = 0,
    Inch = 1,
    AbsMove = 2,
    RelMove = 3,
    Interpolation = 4,
    Home = 5
}

/// <summary>
/// 用户角色枚举
/// </summary>
public enum UserRole
{
    Admin = 0,
    Operator = 1,
    Inspector = 2,
    Visitor = 3
}

/// <summary>
/// 联动流程步骤状态
/// </summary>
public enum LinkStepStatus
{
    Waiting = 0,
    Executing = 1,
    Completed = 2,
    Failed = 3
}

/// <summary>
/// 检测结果枚举
/// </summary>
public enum DetectResult
{
    Unknown = 0,
    Pass = 1,
    Fail = 2
}

/// <summary>
/// 配方类型枚举
/// </summary>
public enum RecipeType
{
    Motion = 0,
    Vision = 1,
    Link = 2,
    Cad = 3
}
