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
    /// Interaction logic for send.xaml
    /// </summary>
    public partial class send : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ShreyasGowda\Documents\flashpay.mdf;Integrated Security = True; Connect Timeout = 30");
        public send()
        {
            InitializeComponent();
        }


        private void pg1_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
            SqlCommand cmd3 = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd1.CommandType = CommandType.Text;
            cmd.CommandText = "select bal from acc where Mobile='"+mym.Text+"'";
            cmd.ExecuteNonQuery();
            SqlDataReader drw = cmd.ExecuteReader();
            drw.Read();

            int amti = drw.GetInt32(0);
            drw.Close();
            int amt = int.Parse(am.Text);
            int bali = amti - amt;
            if (bali>= 0)
            {
                cmd1.CommandText = "select bal from acc where Mobile='" + rm.Text + "'";
                cmd1.ExecuteNonQuery();
                SqlDataReader drw1 = cmd1.ExecuteReader();
                drw1.Read();

                int ramti = drw1.GetInt32(0);
                drw1.Close();
                int rbal = ramti + amt;
                cmd2.CommandText = "Update acc set bal='" + bali + "' where Mobile='" + mym.Text + "'";
                cmd3.CommandText = "Update acc set bal='" + rbal + "' where Mobile='" + rm.Text + "'";
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("TRANSACTION SUCCESFULL");
            }
            else
            {
                MessageBox.Show("INSUFFICIENT BALENCE!!!");
            }

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
