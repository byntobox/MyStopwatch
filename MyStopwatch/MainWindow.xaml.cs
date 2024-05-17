using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyStopwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer currentStopwatchTimer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        string currentStopwatchTime = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            CurrentStopwatchTextBlock.Text = "00:00:00";

            currentStopwatchTimer.Tick += new EventHandler(StopwatchTimer_Tick);
            currentStopwatchTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);

        }

        void StopwatchTimer_Tick(object sender, EventArgs e)
        {
            if(stopwatch.IsRunning)
            {
                TimeSpan timeElapsed = stopwatch.Elapsed;
                currentStopwatchTime = String.Format("{0:00}:{1:00}:{2:00}", timeElapsed.Minutes, timeElapsed.Seconds, timeElapsed.Milliseconds / 10);
                CurrentStopwatchTextBlock.Text = currentStopwatchTime;
            }
        }

        void ClickedOn_StartStopwatchButton(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            currentStopwatchTimer.Start();
        }

        void ClickedOn_StopStopwatchButton(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
        }

        void ClickedOn_ResetStopwatchButton(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            CurrentStopwatchTextBlock.Text = "00:00:00";
        }
    }
}