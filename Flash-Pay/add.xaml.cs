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
    /// Interaction logic for add.xaml
    /// </summary>
    public partial class add : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ShreyasGowda\Documents\flashpay.mdf;Integrated Security = True; Connect Timeout = 30");
        public add()
        {
            InitializeComponent();
        }

        private void pg2_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            SqlCommand cmd1 = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd1.CommandType = CommandType.Text;
            cmd.CommandText = "select bal from acc where Mobile='" + mym.Text + "'";
            cmd.ExecuteNonQuery();

            SqlDataReader drw = cmd.ExecuteReader();
            drw.Read();
            
                int amtir = drw.GetInt32(0);
            drw.Close();
                int amt = int.Parse(am.Text);
                int bali = amtir + amt;

                cmd1.CommandText = "Update acc set bal='" + bali + "' where Mobile='" + mym.Text + "'";
                cmd1.ExecuteNonQuery();
            
                MessageBox.Show("MONEY ADDED SUCCESFULLY");
                con.Close();
            
        }

        private void pg1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Home hom = new Home();
            hom.Show();
        }
    }
}
