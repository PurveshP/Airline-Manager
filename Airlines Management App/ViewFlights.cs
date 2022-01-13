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
    public partial class ViewFlights : Form
    {

        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\purv2\\source\\repos\\Airline-Manager\\AirlinesDB.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection(ConnectionString);
        public ViewFlights()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //textBox2 = FlightID 
        //textBox1 = FlightCapacity
        //dateTimePicker1 = Flight Date
        //comboBox1 = FlightDeparture
        //comboBox2 = Flight Arrival


        //Back button
        private void button4_Click(object sender, EventArgs e)
        {
            FlightsTable fTable = new FlightsTable();
            fTable.Show(this);
            this.Hide();
        }


        private void ViewFlights_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
            populate();
            
        }


        // Reset Button
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
        }

        private void populate()
        {
            string query = "SELECT * FROM FlightsTable";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //MessageBox.Show(textBox2.Text);
            try
            {
                con.Open();
                sqlDA = new SqlDataAdapter(query, con);
                sqlDA.Fill(ds);
                con.Close();
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.DataBindings.Add(new Binding("Text", dataGridView1[0, e.RowIndex], "Value", false));
                textBox1.DataBindings.Add(new Binding("Text", dataGridView1[4, e.RowIndex], "Value", false));
                dateTimePicker1.DataBindings.Add(new Binding("Text", dataGridView1[3, e.RowIndex], "Value", false));
                comboBox1.DataBindings.Add(new Binding("Text", dataGridView1[1, e.RowIndex], "Value", false));
                comboBox2.DataBindings.Add(new Binding("Text", dataGridView1[2, e.RowIndex], "Value", false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //MessageBox.Show("The value of Flight ID is - " + textBox2.Text);

        }


        //Delete Button
        private void button1_Click(object sender, EventArgs e)
        {

            string FlightID = textBox2.Text;
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter the Flight ID for the flight that requries to be removed");
            }
            else
            {
                try
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM FlightsTable WHERE FlightID=" + textBox2.Text + ";";
                    SqlCommand sqlCommand = new SqlCommand(deleteQuery, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Flight removed successfully");

                    con.Close();

                    populate();
                }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
        }



        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string updateQuery = "UPDATE FlightsTable SET FlightDeparture = '" + comboBox1.SelectedItem.ToString() + "', FlightArrival = '" + comboBox2.SelectedItem.ToString() + "', FlightDate = '" + dateTimePicker1.Value.ToString() + "', FlightCapacity = '" + textBox1.Text + "' WHERE FlightID = " + textBox2.Text + ";";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Updated Successfully");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
