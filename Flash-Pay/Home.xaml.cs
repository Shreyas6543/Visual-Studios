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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
      

        public Home()
        {
            InitializeComponent();
        }

        

      

        private void sendb(object sender, RoutedEventArgs e)
        {
            this.Hide();
            send snd = new send();
            snd.Show();
        }

        private void addb(object sender, RoutedEventArgs e)
        {
            this.Hide();
            add ad = new add();
            ad.Show();
        }

        private void bale(object sender, RoutedEventArgs e)
        {
            this.Hide();
            balence bal = new balence();
            bal.Show();

        }

       
    }
}
