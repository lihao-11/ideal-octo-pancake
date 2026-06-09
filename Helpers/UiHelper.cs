using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace VisionMotionControl.Helpers;

/// <summary>
/// UI辅助工具
/// </summary>
public static class UiHelper
{
    /// <summary>
    /// 跨线程更新UI
    /// </summary>
    public static void InvokeOnUiThread(Action action)
    {
        Application.Current?.Dispatcher.Invoke(action);
    }

    /// <summary>
    /// 异步跨线程更新UI
    /// </summary>
    public static void BeginInvokeOnUiThread(Action action)
    {
        Application.Current?.Dispatcher.BeginInvoke(action, DispatcherPriority.Normal);
    }

    /// <summary>
    /// 显示消息弹窗
    /// </summary>
    public static void ShowMessage(string message, string title = "提示")
    {
        MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
    }

    /// <summary>
    /// 显示错误弹窗
    /// </summary>
    public static void ShowError(string message, string title = "错误")
    {
        MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
    }

    /// <summary>
    /// 显示确认弹窗
    /// </summary>
    public static bool ShowConfirm(string message, string title = "确认")
    {
        return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
    }

    /// <summary>
    /// 根据状态获取颜色
    /// </summary>
    public static Brush GetStatusBrush(bool isNormal)
    {
        return isNormal ? Brushes.Green : Brushes.Red;
    }
}
