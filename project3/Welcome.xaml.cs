using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

namespace project3
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hidden;
        string t1 = (Environment.OSVersion.ToString());
        string t2 = Environment.MachineName;
        string t3 = Environment.Version.ToString();
        string t4 = Environment.UserName;

        public Welcome()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            timer.Tick += Timer_Tick;
            panelWidth = sidepanel.Width;
            osversion.Text = t1;
            username.Text = t4;
            machine.Text = t2;
            version.Text = Convert.ToString(t3);
            user.Text = Convert.ToString(t4);
        }
        private void btnmaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnminimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sendCode sc = new sendCode();
            this.Hide();
            sc.Show();

        }
        private void Hyperlink(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://learn.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value

            Process.Start(new ProcessStartInfo { FileName = @"http://itservices.axiscades.com/", UseShellExecute = true });

            e.Handled = true;
        }

        private void Label(object sender, RoutedEventArgs e)
        {
            IPHostEntry iph;
            string myip = "?";
            iph = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in iph.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    myip = ip.ToString();

                }

            }
            abc.Text = myip;

        }


        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (hidden)
            {
                sidepanel.Width += 1;
                if (sidepanel.Width > panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }

            }
            else
            {
                sidepanel.Width -= 1;
                if (sidepanel.Width < 30)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();


        }



        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}