using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();
        }
        
        public static SqlConnection con = new SqlConnection(@"Data Source =DESKTOP-3VUS80A;Initial Catalog = master;Integrated Security = True");

        public static SqlCommand cmd = new SqlCommand("SELECT * FROM medicaments", con);
        public static SqlDataAdapter dap = new SqlDataAdapter(cmd);








        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("idM", 60);
            listView1.Columns.Add("nom", 150);
            listView1.Columns.Add("type", 150);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox6.Text != "")
            {
                //public static SqlCommand cmd2 = new SqlCommand("insert into medicaments values(@id, @n, @ty)", con);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO  medicaments (idM, nom, type) VALUES (@idM, @nom, @type)", con);


                cmd2.Parameters.AddWithValue("@idM", textBox1.Text);
                cmd2.Parameters.AddWithValue("@nom", textBox3.Text);
                cmd2.Parameters.AddWithValue("@type", textBox6.Text);
                con.Open();
                cmd2.ExecuteNonQuery();

                // DataSet ds = new DataSet();


                MessageBox.Show("bien ajoute");
            }

            // declaration.cd.GetInsertCommand();

            else
            {
                MessageBox.Show("entrer les donnees!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
       
        DataSet ds = new DataSet();
            //con.Open();

            dap.Fill(ds, "med");
            listView1.Items.Clear();

            for (int i = 0; i < ds.Tables["med"].Rows.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                // lvi.Text = ds.Tables["med"].Rows[i][0].ToString();
                lvi.SubItems.Add(ds.Tables["med"].Rows[i][0].ToString());
                lvi.SubItems.Add(ds.Tables["med"].Rows[i][1].ToString());
                lvi.SubItems.Add(ds.Tables["med"].Rows[i][2].ToString());
                listView1.Items.Add(lvi);




            }
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM medicaments WHERE idM=@idM", con);
                deleteCommand.Parameters.AddWithValue("@idM", textBox1.Text);
                con.Open();
                deleteCommand.ExecuteNonQuery();

                MessageBox.Show("suppression avec succes");
            }
            else
            {
                MessageBox.Show("entrer les donnees!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand uCommand = new SqlCommand("update medicaments SET nom=@nom,type=@type WHERE idM=@idM", con);
                uCommand.Parameters.AddWithValue("@idM", textBox1.Text);
                uCommand.Parameters.AddWithValue("@nom", textBox3.Text);
                uCommand.Parameters.AddWithValue("@type", textBox6.Text);
                con.Open();
                uCommand.ExecuteNonQuery();

                MessageBox.Show("modification avec succes");
            }
            else
            {
                MessageBox.Show("entrer les donnees!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                DataSet ds = new DataSet();
                //declaration.con.Open();

                dap.Fill(ds, "med");
                listView1.Items.Clear();

                int pos=-1;

                for (int i = 0; i < ds.Tables["med"].Rows.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    if (ds.Tables["med"].Rows[i][0].ToString() == textBox1.Text)
                    {

                        pos = i;

                        // break;

                       // lvi.Text = ds.Tables["med"].Rows[i][0].ToString();
                        lvi.SubItems.Add(ds.Tables["med"].Rows[i][0].ToString());
                        lvi.SubItems.Add(ds.Tables["med"].Rows[i][1].ToString());
                        lvi.SubItems.Add(ds.Tables["med"].Rows[i][2].ToString());
                        listView1.Items.Add(lvi);

                    }
                }
                if(pos==-1)
                {
                    MessageBox.Show("votre recherche est introuvable");
                }


            }
            else
            {
                MessageBox.Show("renseignez un champ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}

