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
    public partial class FlightsTable : Form
    {


        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\purv2\\source\\repos\\Airline-Manager\\AirlinesDB.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection(ConnectionString);



        public FlightsTable()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //textBox2 = flightID
        //textBox1 - Capacity
        //comboBox1 - Departure
        //comboBox2 - arrival
        //dateTimePicker1 - date

        // ADD button

        private void button2_Click(object sender, EventArgs e)
        {
            string FlightID = textBox2.Text;
            string FlightCapacity = textBox1.Text;
            string FlightDeparture = (string)comboBox1.SelectedItem;
            string FlightArrival = (string)comboBox2.SelectedItem;
            string FlightDate = dateTimePicker1.Text;

            if(FlightID == "" || FlightCapacity == "" || FlightDeparture == "" || FlightArrival == "" || FlightCapacity == "" || FlightDate == "")
            {
                MessageBox.Show("Information missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string flightAddQuery = "INSERT INTO FlightsTable VALUES(@FlightID, @FlightDeparture, @FlightArrival, @FlightDate, @FlightCapacity)";
                    SqlCommand cmd = new SqlCommand(flightAddQuery, con);

                    cmd.Parameters.AddWithValue("@FlightID", FlightID);
                    cmd.Parameters.AddWithValue("@FlightDeparture", FlightDeparture);
                    cmd.Parameters.AddWithValue("@FlightArrival", FlightArrival);
                    cmd.Parameters.AddWithValue("@FlightDate", FlightDate);
                    cmd.Parameters.AddWithValue("@FlightCapacity", FlightCapacity);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight added successfully");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void FlightsTable_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            
        }


        // Cancel button
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewFlights viewF = new ViewFlights();
            viewF.Show();
            this.Hide();
        }
    }
}
