using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airlines_Management_App
{
    public partial class ShowPassengers : Form
    {
        public ShowPassengers()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\purv2\\source\\repos\\Airline-Manager\\AirlinesDB.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection(ConnectionString);

        private void populate()
        {
            
            //MessageBox.Show("connected to data base");

            string query = "SELECT * FROM PassengerTable";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            //SqlCommandBuilder builder = new SqlCommandBuilder(sqlDA);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                sqlDA = new SqlDataAdapter(query, con);
               // MessageBox.Show("Connection is active");
                sqlDA.Fill(ds);
                //MessageBox.Show("Update!");
                con.Close();
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            
            


            //ds.Tables.Add("PassengerTable");
            //sqlDA.Fill(ds, "PassengerTable");
            //dataGridView1.DataSource = ds; 
            //dataGridView1.DataMember = "PassengerTable";

            //DataGridView PassengerDGV = new DataGridView();
            //sqlDA.Fill(ds);
            //PassengerDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void ShowPassengers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Passenger passen = new Passenger();
            passen.Show();
            this.Hide();

        }
    }
}
