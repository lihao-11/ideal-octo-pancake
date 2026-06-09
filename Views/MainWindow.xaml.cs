using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using VisionMotionControl.Views.Pages;

namespace VisionMotionControl.Views;

public partial class MainWindow : Window
{
    private Button? _activeNavButton;
    private readonly DispatcherTimer _clockTimer;

    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize clock timer
        _clockTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _clockTimer.Tick += (s, e) => UpdateClock();
        _clockTimer.Start();
        UpdateClock();
        
        // Set initial page
        _activeNavButton = NavVisionMotionLink;
        MainFrame.Navigate(new VisionMotionLinkPage());
    }

    private void UpdateClock()
    {
        ClockText.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    private void NavButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button clickedButton) return;
        
        // Update active button style
        if (_activeNavButton != null)
        {
            _activeNavButton.Style = (Style)FindResource("NavButton");
        }
        clickedButton.Style = (Style)FindResource("NavButtonActive");
        _activeNavButton = clickedButton;
        
        // Navigate to page
        var tag = clickedButton.Tag?.ToString();
        Page? page = tag switch
        {
            "VisionMotionLink" => new VisionMotionLinkPage(),
            "MotionControl" => new MotionControlPage(),
            "VisionDetect" => new VisionDetectPage(),
            "CadParse" => new CadParsePage(),
            "RecipeManage" => new RecipeManagePage(),
            "Reports" => new ReportsPage(),
            "SystemConfig" => new SystemConfigPage(),
            _ => null
        };
        
        if (page != null)
        {
            MainFrame.Navigate(page);
        }
    }
}
