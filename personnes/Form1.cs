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

namespace GestionPersG22
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL2017-PC\SQLEXPRESS;Initial Catalog=edc;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;
        int ID,id_compte;
        //SqlConnection con = new SqlConnection("Data Source=DELL2017-PC\\SQLEXPRESS;Initial Catalog=client;Integrated Security=True");

        public Form1()
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
                adpt = new SqlDataAdapter("SELECT * FROM client", con);
                adpt.Fill(dt);

                dataGridView1.DataSource = dt;


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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO client " +
                    "VALUES('" + login.Text + "', '" + mdp.Text + "', '" + nom.Text + "','" + prenom.Text + "','" + tel.Text + "','" + email.Text + "')", con);

                cmd.ExecuteNonQuery();
            } catch
            {
                MessageBox.Show("Une erreur est survenue");
            }
            finally
            {
                con.Close();
                afficher();
            }


           

            login.Text = nom.Text = prenom.Text =tel.Text=email.Text=mdp.Text= "";
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from   client  where id = '" + ID + "' ", con);
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
            login.Text = nom.Text = prenom.Text = tel.Text = email.Text = mdp.Text = "";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update  client set  LOGIN = '" + login.Text + "', MDP = '" + mdp.Text + "', NOM = '" + nom.Text + "' , PRENOM = '" + prenom.Text + "', NUMTEL = '" + tel.Text + "', ADRMAIL = '" + email.Text + "' where id = '" + ID + "' ", con);
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
            login.Text = nom.Text = prenom.Text = tel.Text = email.Text = mdp.Text = "";
        }

        private void lvwPersonnes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void search_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            login.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            mdp.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            nom.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            prenom.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            tel.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu f = new Menu();
            f.Show();
            this.Hide();
        }
    }
}
