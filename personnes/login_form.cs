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
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //data binding
            
        }

        private void Register_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userlogin = textBox1.Text;
            string userpassword = textBox2.Text;
            string connectionstring;
            SqlConnection connexion;
            connectionstring = @"Data Source=DELL2017-PC\SQLEXPRESS;Initial Catalog=edc;Integrated Security=True";
            connexion = new SqlConnection(connectionstring);
            connexion.Open();
            string sqlquery;
            SqlCommand command;
            SqlDataReader dataReader;

            sqlquery = "select login , mdp from admin where login='" + userlogin + "' and mdp='" + userpassword + "'";
            command = new SqlCommand(sqlquery, connexion);
            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                // MessageBox.Show(dataReader.GetValue(0)+" ");

                Menu f = new Menu();
                f.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("erreur");
            }
            connexion.Close();
        }

        private void login_form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
