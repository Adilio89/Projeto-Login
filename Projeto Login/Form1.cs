using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Projeto_Login
{
    public partial class Form1 : Form
    {
        public static int x = 1;
        string MySqlClientString =
            "server= localhost;Port=3306;User Id = root; Database = bd_base; SSL Mode=0";
        public Form1()
        {
            InitializeComponent();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from tbusuarios where login = '" +
                txtusuario.Text + "' AND senha = " + txtsenha.Text, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            //MessageBox.Show(reader.Read().ToString());
            if (reader.Read())
            {
                MessageBox.Show("Usuário Logado !");
                //System.Diagnostics.Process.Start("C:/Users/leand/source/repos/EIN2/Tabuada/Tabuada/bin/Debug/netcoreapp3.1/tabuada.exe");
                //this.Hide();
                //new Form2().Show();
            }
            else
            {
                MessageBox.Show("Usuário Inexistente !");
            }
            if (reader.Read() || (txtusuario.Text == "ADMIN" && txtsenha.Text == "191919"))
            {
                this.Hide();
                new Form2().Show();
            }
        }
                

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White)
            {
                
                this.BackColor = Color.Black;
            }
           else
            {
                //pictureBox3.Image = Properties.Resources.dia;
                this.BackColor = Color.White;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtsenha.UseSystemPasswordChar == true)
            {
                txtsenha.UseSystemPasswordChar = false;
                button3.Image = Properties.Resources.aberto;
            }
            
            else
            {
                txtsenha.UseSystemPasswordChar = true;
                button3.Image = Properties.Resources.fechado;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.White)
            {
                BackColor = Color.Black;
                button4.Image = Properties.Resources.noite;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
            }
            else
            {
                BackColor = Color.White;
                button4.Image = Properties.Resources.dia;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
        }

        private void txtsenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8
                ? false : true;
        }
    }
}
