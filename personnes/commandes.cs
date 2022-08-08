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

namespace GestionPersG22
{
    public partial class commandes : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DELL2017-PC\SQLEXPRESS;Initial Catalog=edc;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;
        int ID;
        public commandes()
        {
            InitializeComponent();
        }
        private void afficher()
        {
            try
            {
                dt = new DataTable();
                con.Open();

                //SqlCommand cmd = new SqlCommand("SELECT * FROM client_table", con);
                adpt = new SqlDataAdapter("SELECT * FROM BONCOMMANDE", con);
                adpt.Fill(dt);

                dataGridView2.DataSource = dt;


            }
            catch
            {
                MessageBox.Show("Une erreur est survenue");
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void commandes_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO BONCOMMANDE " +
                    "VALUES('" + textBox1.Text + "', '" + dateTimePicker1.Text + "', '" + textBox4.Text + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "')", con);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue");
            }
            finally
            {
                con.Close();
                afficher();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update  BONCOMMANDE set  DATEBC = '" + dateTimePicker1.Text + "', TYPECB = '" + textBox4.Text + "', DATEEXP = '" + dateTimePicker2.Text + "' , ADRLIV = '" + textBox5.Text + "' where IDCO = '" + ID + "' ", con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Your data has been updated");
            }
            catch
            {

                MessageBox.Show("Une erreur est survenue");
            }
            finally
            {
                afficher();
            }
           
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            ID = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from   BONCOMMANDE  where IDCO = '" + ID + "' ", con);
                cmd.ExecuteNonQuery();

                con.Close();
                //MessageBox.Show("Your data has been updated");
            }
            catch
            {

                MessageBox.Show("Une erreur est survenue");
            }
            finally
            {
                afficher();
            }
            
        }
    }
}
