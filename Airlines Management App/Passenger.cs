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
    public partial class Passenger : Form
    {

        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\purv2\\source\\repos\\Airline-Manager\\AirlinesDB.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection con = new SqlConnection(ConnectionString);

        


        
        public Passenger()
        {
            InitializeComponent();
        }

        
        
        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string PassengerID = textBox1.Text;
            //string PassengerName = textBox2.Text;
            //string PassportNumber = textBox4.Text;
            //string PassengerAddress = textBox3.Text;
            //string PassengerPhone = textBox5.Text;
            //string PassengerGen = (string)comboBox1.SelectedItem;
            //string PassengerNation = (string)comboBox2.SelectedItem;

            //MessageBox.Show("Passenger Id {0}", PassengerID);
            //MessageBox.Show("Passenger Name {0}", PassengerName);
            //MessageBox.Show("Passennger passport number {0}", PassportNumber);
            //MessageBox.Show("Passenger Address {0}", PassengerAddress);
            //MessageBox.Show("Passenger Phone {0}", PassengerPhone);
            //MessageBox.Show("Passenger Gender {0}", PassengerGen);
            //MessageBox.Show("Passenger nationality {0}", PassengerNation);

            //if (PassengerID == "" || PassengerName == "" || PassportNumber == "" || 
            //    PassengerAddress == "" || PassengerNation == "" || PassengerGen == "" || 
            //    PassengerPhone == "")
            //{
            //    MessageBox.Show("Information Missing");
            //}
            //else
            //{
            //    try
            //    {

            //        //string sql1= "insert into PassengerTable value("+PassengerID+", '"+PassengerName+"', '"+PassportNumber+"', '"+PassengerAddress+"', '"+PassengerNation+"', '"+PassengerGen+"', '"+PassengerGen+"')";
            //        SqlCommand cmd = new SqlCommand( "sql1", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@PassengerID", textBox1.Text);
            //        cmd.Parameters.AddWithValue("@PassengerName", textBox2.Text);
            //        cmd.Parameters.AddWithValue("@Passport", textBox4.Text);
            //        cmd.Parameters.AddWithValue("@PassengerNation", (string)comboBox2.SelectedItem);
            //        cmd.Parameters.AddWithValue("@PassengerGen", (string)comboBox1.SelectedItem);
            //        cmd.Parameters.AddWithValue("@PassengerPhone", textBox5.Text);

            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Passenger added successfully");
            //        con.Close();

            //    } catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        // Add button
        private void button2_Click_1(object sender, EventArgs e)
        {
            string PassengerID = textBox1.Text;
            string PassengerName = textBox2.Text;
            string PassportNumber = textBox4.Text;
            string PassengerAddress = textBox3.Text;
            string PassengerPhone = textBox5.Text;
            string PassengerGen = (string)comboBox1.SelectedItem;
            string PassengerNation = (string)comboBox2.SelectedItem;



            //MessageBox.Show("Passenger Id"+ PassengerID);
            //MessageBox.Show("Passenger Name {0}", PassengerName);
            //MessageBox.Show("Passennger passport number {0}", PassportNumber);
            //MessageBox.Show("Passenger Address {0}", PassengerAddress);
            //MessageBox.Show("Passenger Phone {0}", PassengerPhone);
            //MessageBox.Show("Passenger Gender {0}", PassengerGen);
            //MessageBox.Show("Passenger nationality {0}", PassengerNation);


            if (PassengerID == "" || PassengerName == "" || PassportNumber == "" ||
                PassengerAddress == "" || PassengerNation == "" || PassengerGen == "" ||
                PassengerPhone == "")
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                //con.Open();
                //MessageBox.Show("Connected to data base");
                //con.Close();
                try
                {
                    con.Open();
                    string sql1 = "INSERT INTO PassengerTable VALUES(@PassengerID, @PassengerName, @Passport, @PassengerAddress, @PassengerNation, @PassengerGen, @PassengerPhone)";
                    SqlCommand cmd = new SqlCommand(sql1, con);


                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PassengerID", Int32.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@PassengerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Passport", textBox4.Text);
                    cmd.Parameters.AddWithValue("@PassengerAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PassengerNation", (string)comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@PassengerGen", (string)comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@PassengerPhone", textBox5.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger added successfully");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        // this is for the cancel button
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exit");
        }

        private void Passenger_Load(object sender, EventArgs e)
        {

        }

        // Show passenger button
        private void button3_Click(object sender, EventArgs e)
        {
            ShowPassengers showpass = new ShowPassengers();
            showpass.Show();
            this.Hide();
        }
    }
}
