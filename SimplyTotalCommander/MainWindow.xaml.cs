
using System;
using System.Windows;


namespace SimplyTotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            SourceInitialized += new EventHandler(MainWindow_NoResizeWindowOnDoubleClick);
        }
        void MainWindow_NoResizeWindowOnDoubleClick(object sender, EventArgs e)
        {
            System.Windows.Interop.HwndSource source = System.Windows.Interop.HwndSource.FromHwnd(new System.Windows.Interop.WindowInteropHelper(this).Handle);
            source.AddHook(new System.Windows.Interop.HwndSourceHook(WndProc));
        }

        int WM_NCLBUTTONDBLCLK { get { return 0x00A3; } }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCLBUTTONDBLCLK)
            {
                handled = true;  //prevent double click from resize the window.
            }

            return IntPtr.Zero;
        }

        private void WindowControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
        private void WindowControl_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

    }
}
