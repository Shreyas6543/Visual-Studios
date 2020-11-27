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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ShreyasGowda\Documents\flashpay.mdf;Integrated Security = True; Connect Timeout = 30");
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd1 = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd1.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Signup values('" + sname.Text + "','" + smob.Text + "','" + spass.Text + "')";
                cmd1.CommandText= "insert into acc values('" + smob.Text + "',' 0 ')";
                cmd1.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("SignUp Successful please Login " + sname.Text + "");
                    this.Hide();
                    Login win1 = new Login();
                    win1.Show();
                }
                else { MessageBox.Show("SignUp Unsuccessful"); }
                con.Close();
                
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void pg1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow hom = new MainWindow();
            hom.Show();
        }
    }
        
}

