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

        //textBox1 = Passenger ID
        //textBox2 = Name
        //textBox3 = Address
        //textBox4 = Passport number
        //textBox5 = Phone
        //comboBox1 = Nationality
        //comboBox2 = Gender


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
            //con.Close();
        }
        private void ShowPassengers_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
            populate();
        }

        //back button
        private void button4_Click(object sender, EventArgs e)
        {
            Passenger passen = new Passenger();
            passen.Show();
            this.Hide();

        }

        // Delete button
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox1.Text == "ID")
            {
                MessageBox.Show("Enter the ID of the passenger that requires to be removed");
            }
            else
            {
                try
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM PassengerTable WHERE PassengerID=" + textBox1.Text + ";";
                    SqlCommand sqlCommand = new SqlCommand(deleteQuery, con);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Passenger removed successfully");

                    con.Close();

                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        // not able to find the errors in this case will do it in the end

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int rowCount = dataGridView1.RowCount;
            //string cellCount = dataGridView1.SelectedRows[0].ToString();    
            //MessageBox.Show(cellCount);
            //int widhtDGV = dataGridView1.Size.Width;
            //int heightDGV = dataGridView1.Size.Height;
            //MessageBox.Show("row count of the datagridview is " + rowCount);
            //MessageBox.Show("Width of the datagridview is " + widhtDGV);
            //MessageBox.Show("Height of the datagridview is " + heightDGV);

            try
            {
                //textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                //textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                //comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                //textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();


                textBox1.DataBindings.Add(new Binding("Text", dataGridView1[0,e.RowIndex], "Value", false));
                textBox2.DataBindings.Add(new Binding("Text", dataGridView1[1,e.RowIndex], "Value", false));
                textBox3.DataBindings.Add(new Binding("Text", dataGridView1[3,e.RowIndex], "Value", false));
                textBox4.DataBindings.Add(new Binding("Text", dataGridView1[2,e.RowIndex], "Value", false));
                comboBox1.DataBindings.Add(new Binding("Text", dataGridView1[4,e.RowIndex], "Value", false));
                comboBox2.DataBindings.Add(new Binding("Text", dataGridView1[5,e.RowIndex], "Value", false));
                textBox5.DataBindings.Add(new Binding("Text", dataGridView1[6, e.RowIndex], "Value", false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }
        // Reset Button
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        // Update button
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Information missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string updateQuery = "UPDATE PassengerTable SET PassengerName = '" + textBox2.Text + "', Passport = '" + textBox4.Text + "', PassengerAddress = '" + textBox3.Text + "', PassengerNation = '" + comboBox1.SelectedItem.ToString() + "', PassengerGen = '" + comboBox2.SelectedItem.ToString() + "', PassengerPhone = '" + textBox5.Text + "' WHERE PassengerID = " + textBox1.Text + ";";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Updated Successfully");
                    con.Close();
                    populate();


                }
                catch( Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
