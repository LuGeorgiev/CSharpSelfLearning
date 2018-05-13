using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void SecondsChangeHandler(object sender, EventArgs e);
        public event SecondsChangeHandler SecondsChanged;

        public delegate void MinutesChangedHandler(int currentMinute);
        public event MinutesChangedHandler MinutesChanged;

        public MainWindow()
        {
            InitializeComponent();
            this.SecondsChanged += OnSecondsChanged;
            this.MinutesChanged += OnMinutesChanged;
        }

        private void OnMinutesChanged(int currentMinute)
        {
            MinutesChanged(DateTime.Now.Minute);
        }

        private void OnSecondsChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonSecconds_Click(object sender, RoutedEventArgs e)
        {
            labelSeconds.Content = DateTime.Now.Second;
        }

        private void buttonSecconds_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
