using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Timer = System.Windows.Forms.Timer;

namespace MatrixScreensaver
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var screens = Screen.AllScreens;
            var forms = screens.Select((screen, index) =>
            {
                string matrixUrl = index switch
                {
                    0 => "https://rezmason.github.io/matrix/?palette=0.1,0,0.2,0,1,0,0,0.5,0.5,0,0,1", // red
                    1 => "https://rezmason.github.io/matrix/",                                      // green (default)
                    2 => "https://rezmason.github.io/matrix/?palette=0.1,0,0.2,0,0,0,1,0.5,0,0,0.5,1", // blue
                    _ => "https://rezmason.github.io/matrix/" // fallback
                };

                var form = new FullscreenMatrixForm(screen, matrixUrl);
                form.Show();
                return form;
            }).ToArray();

            Application.Run();
        }
    }

    public class FullscreenMatrixForm : Form
    {

        private readonly WebView2 webView;
        private Point _initialMousePosition;
        private bool _initializedMouse = false;
        private readonly Timer _mouseTimer;

        public FullscreenMatrixForm(Screen screen, string matrixUrl)
        {
            StartPosition = FormStartPosition.Manual;
            Bounds = screen.Bounds;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Black;
            TopMost = true;
            DoubleBuffered = true;

            webView = new WebView2
            {
                Dock = DockStyle.Fill,
                Source = new Uri(matrixUrl),
                BackColor = Color.Black
            };
            Controls.Add(webView);

            KeyDown += (_, __) => Application.Exit();

            // Set up timer to check mouse movement every 200ms
            _mouseTimer = new Timer { Interval = 200 };
            _mouseTimer.Tick += CheckMousePosition;
            _mouseTimer.Start();
        }

        private void CheckMousePosition(object sender, EventArgs e)
        {
            var currentPosition = Cursor.Position;

            if (!_initializedMouse)
            {
                _initialMousePosition = currentPosition;
                _initializedMouse = true;
                return;
            }

            int deltaX = Math.Abs(currentPosition.X - _initialMousePosition.X);
            int deltaY = Math.Abs(currentPosition.Y - _initialMousePosition.Y);

            if (deltaX > 5 || deltaY > 5)
            {
                Application.Exit();
            }
        }
    }
}