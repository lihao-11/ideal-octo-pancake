using VisionMotionControl.Globals;
using VisionMotionControl.Helpers;

namespace VisionMotionControl.MotionCtrl;

/// <summary>
/// IO操作类
/// </summary>
public class IoOperateHelper
{
    /// <summary>
    /// 读取单个输入
    /// </summary>
    public bool ReadInput(int ioNo)
    {
        if (!GlobalVariables.MotionCardConnected) return false;
        // TODO: 调用ZMC_API读取输入
        return false;
    }

    /// <summary>
    /// 批量读取输入
    /// </summary>
    public bool[] ReadInputs(int startNo, int count)
    {
        if (!GlobalVariables.MotionCardConnected) return new bool[count];
        // TODO: 批量读取
        return new bool[count];
    }

    /// <summary>
    /// 写入单个输出
    /// </summary>
    public void WriteOutput(int ioNo, bool value)
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info($"IO输出 {ioNo} = {value}");
        // TODO: 调用ZMC_API写入输出
    }

    /// <summary>
    /// 批量写入输出
    /// </summary>
    public void WriteOutputs(int startNo, bool[] values)
    {
        if (!GlobalVariables.MotionCardConnected) return;
        LogHelper.Info($"批量IO输出: 起始{startNo}, 数量{values.Length}");
        // TODO: 批量写入
    }
}
