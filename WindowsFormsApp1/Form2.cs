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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;

        }

        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QTLF4OF;Initial Catalog=data;Integrated Security=True");

        public static SqlCommand cmd = new SqlCommand("SELECT * FROM stock", con);
        public static SqlDataAdapter dap = new SqlDataAdapter(cmd);

        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("id_Stock", 210);
            listView1.Columns.Add("Quantite", 180);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void enregisterStock_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //public static SqlCommand cmd2 = new SqlCommand("insert into medicaments values(@id, @n, @ty)", con);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO  stock (idS, quantite) VALUES (@idS, @quantite)", con);


                cmd2.Parameters.AddWithValue("@idS", textBox1.Text);
                cmd2.Parameters.AddWithValue("@quantite", textBox2.Text);

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
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //con.Open();

            dap.Fill(ds, "med");
            listView1.Items.Clear();

            for (int i = 0; i < ds.Tables["med"].Rows.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ds.Tables["med"].Rows[i][0].ToString();
                lvi.SubItems.Add(ds.Tables["med"].Rows[i][1].ToString());


                listView1.Items.Add(lvi);




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("SVP entere des nombres seuelement 😊 ");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("SVP entere des nombres seuelement 😊 ");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void get()
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM stock WHERE idS=@idS", con);
                deleteCommand.Parameters.AddWithValue("@idS", textBox1.Text);
                con.Open();
                deleteCommand.ExecuteNonQuery();

                MessageBox.Show("suppression avec succes");
            }
            else
            {
                MessageBox.Show("entrer les donnees!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
           
            DialogResult = MessageBox.Show("tu veut vrement supprime OK/CANCEL!! )", "Conditional", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.OK)
            {
                foreach (int i in listView1.SelectedIndices)
                {
                    string test = listView1.Items[i].Text;
                    listView1.Items.Remove(listView1.Items[i]);
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM stock WHERE idS='" + test + "'", con);
                    con.Open();
                    deleteCommand.ExecuteNonQuery();

                }
            }
            else
            {
                
            }
        }
    }
}
