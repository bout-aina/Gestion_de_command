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
    
    public partial class categorie : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DELL2017-PC\SQLEXPRESS;Initial Catalog=edc;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;
        int ID, id_produit,id_cat,id_art;
        public categorie()
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
                adpt = new SqlDataAdapter("SELECT * FROM CATEGORIE", con);
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
        private void afficher_article()
        {
            try
            {
                dt = new DataTable();
                con.Open();

                //SqlCommand cmd = new SqlCommand("SELECT * FROM client_table", con);
                adpt = new SqlDataAdapter("SELECT * FROM ARTICLE where IDPROD = '"+ id_produit+"'", con);
                adpt.Fill(dt);

                dataGridView3.DataSource = dt;


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
        private void afficher_produit()
        {
            try
            {
                dt = new DataTable();
                con.Open();

                //SqlCommand cmd = new SqlCommand("SELECT * FROM client_table", con);
                adpt = new SqlDataAdapter("SELECT * FROM PRODUIT where IDCAT = '"+ ID +"' ", con);
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void categorie_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            nom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            des.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            afficher_produit();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update  CATEGORIE set  NOM = '" + nom.Text + "', DESCRIPTION = '" + des.Text + "' where IDCAT = '" + ID + "' ", con);
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
            des.Text = nom.Text  = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from   CATEGORIE  where IDCAT = '" + ID + "' ", con);
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
            des.Text = nom.Text =  "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO PRODUIT " +
                    "VALUES('" + ID + "','" + textBox1.Text + "', '" + richTextBox1.Text + "')", con);

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
                afficher_produit();
            }
            textBox1.Text = richTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update  PRODUIT  set  NOM = '" + textBox1.Text + "', DESCRIPTION = '" + richTextBox1.Text + "' where IDPROD = '" + id_produit + "' ", con);
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
                afficher_produit();
            }
            textBox1.Text = richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from   PRODUIT  where IDPROD = '" + id_produit + "' ", con);
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
                afficher_produit();
            }
            textBox1.Text = richTextBox1.Text = "";
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO ARTICLE " +
                    "VALUES('" + ID + "','" + id_produit + "', '" + textBox2.Text + "', '" + float.Parse(textBox3.Text) + "')", con);

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
                afficher_produit();
                afficher_article();
            }
            textBox2.Text = textBox3.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update  ARTICLE  set  NOM = '" + textBox2.Text + "', PRIXUNI = '" + float.Parse(textBox3.Text) + "' where IDA = '" + id_art + "' ", con);
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
                afficher_produit();
                afficher_article();
            }
            textBox2.Text = textBox3.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from   ARTICLE  where IDA = '" + id_art + "' ", con);
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
                afficher_produit();
                afficher_article();
            }
            textBox1.Text = richTextBox1.Text = textBox2.Text=textBox3.Text= "";
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_art = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString());
            textBox2.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text =dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   id_cat= int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            id_produit = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            afficher_article();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO CATEGORIE " +
                    "VALUES('" + nom.Text + "', '" + des.Text + "')", con);

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
    }
}
