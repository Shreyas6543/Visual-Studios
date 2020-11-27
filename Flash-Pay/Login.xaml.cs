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
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        
        public Login()
        {
            InitializeComponent();
        }

        private void login_Click1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ShreyasGowda\Documents\flashpay.mdf;Integrated Security = True; Connect Timeout = 30");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Signup where Mobile='" + lmob.Text + "' and Password='" + lpass.Text + "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()=="1")
            
                {

                if (App.Current.Resources.Contains("uName")) App.Current.Resources.Remove("uName");
                App.Current.Resources.Add("uName", lmob);
                MessageBox.Show("Successfully Logged in");
                this.Hide();
                Home hom = new Home();
                    hom.Show();
                }
                else { MessageBox.Show("Please check your number and Password"); }
                con.Close();
                
                

             }

        private void pg1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow hom = new MainWindow();
            hom.Show();
        }
    }
    }

