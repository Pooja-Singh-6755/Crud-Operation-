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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace poojadatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1.address of SQL Server and Database
            string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";

            // 2. establish Connection
            SqlConnection con = new SqlConnection(ConnectionString);

            // 3.open Connection
            con.Open();

            // 4.prepare query 
            string FirstName= textBox1.Text;
            string LastName= textBox2.Text;
         string Query =  "INSERT INTO names(FirstName, SecondName) values('"+FirstName+"', '"+LastName+"')";
            SqlCommand cmd = new SqlCommand(Query, con);


            // 5. execute query
            cmd.ExecuteNonQuery();



            // 6. close connection
            con.Close();

            MessageBox.Show("DATA HAS BEEN SAVED !!");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //address of sql server and database(connecting string)
            string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";


            //establish connection  (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection 
            con.Open();

            // prepare query 
            string query = "Select * from Names";
            SqlCommand cmd = new SqlCommand(query, con);

            //Execute query 
             var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();     //reduce duplicate data show

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ID"], reader["FirstName"].ToString().ToUpper() , reader["SecondName"].ToString().ToUpper() , "Edit");
            }
            
            
            // method 1 ( its is not alter data)
          //  DataTable table = new DataTable();
            //table.Load(reader);

         // dataGridView1.DataSource = table;


            //close connection 
            con.Close();        }

        private void button3_Click(object sender, EventArgs e)
        {
            // adress the sql server and database
            string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";


            // established connection 
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection
            con.Open();

            //prepare query 
            string nameID = textBox3.Text;
            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;
            string Query = "update names set FirstName='"+FirstName+ "' , SecondName='"+LastName+"' where ID = '"+nameID+"'";
            SqlCommand cmd = new SqlCommand(Query, con);


            //execute query
            cmd.ExecuteNonQuery();

            //close connection 
            con.Close();

            MessageBox.Show("DATA UPDATE");
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";



        }

        private void button4_Click(object sender, EventArgs e)
        {

            // adress the sql server and database
            string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";


            // established connection 
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection
            con.Open();

            //prepare query 
            string nameID = textBox3.Text;
           
            string Query = "select * from names where ID='"+nameID+"'";
            SqlCommand cmd = new SqlCommand(Query, con);


            //execute query
            var reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                textBox1.Text = reader["FirstName"].ToString();
                textBox2.Text = reader["SecondName"].ToString();
            }
            else
            {
                MessageBox.Show("not found");
            }

            //close connection 
            con.Close();

           



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if ( e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                string nameID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

              if(  MessageBox.Show(" Do you deleted your data ?" , "confirm deleted " , MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // adress the sql server and database
                    string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";


                    // established connection 
                    SqlConnection con = new SqlConnection(ConnectionString);

                    //open connection
                    con.Open();

                    //prepare query 
                  
                    string Query = "delete from names where ID = '" + nameID + "'";
                    SqlCommand cmd = new SqlCommand(Query, con);


                    //execute query
                    cmd.ExecuteNonQuery();

                    //close connection 
                    con.Close();

                    MessageBox.Show("DATA DELETED");
                    textBox3.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";


                    button2_Click(this, e);   // update table without any refresh

                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            // adress the sql server and database
            string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";


            // established connection 
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection
            con.Open();

            //prepare query 
            string nameID = textBox3.Text;
         
            string Query = "delete from names where ID = '"+nameID+"'";
            SqlCommand cmd = new SqlCommand(Query, con);


            //execute query
            cmd.ExecuteNonQuery();

            //close connection 
            con.Close();

            MessageBox.Show("DATA DELETED");
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";


            button2_Click(this, e);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //address of sql server and database(connecting string)
            string ConnectionString = "Data Source=LAPTOP-8HFB67PS\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";


            //establish connection  (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //open connection 
            con.Open();

            // prepare query 
            string search = textBox4.Text;

            string query = "select * from names where firstName like '%"+search+"%' or SecondName like '%"+search+"%';";
            SqlCommand cmd = new SqlCommand(query, con);

            //Execute query 
            var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();     //reduce duplicate data show

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ID"], reader["FirstName"].ToString().ToUpper(), reader["SecondName"].ToString().ToUpper(), "Edit");
            }

            con.Close();
        }
    }
}
