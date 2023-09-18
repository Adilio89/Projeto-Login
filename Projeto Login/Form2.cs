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

namespace Projeto_Login
{
    public partial class Form2 : Form
    {
        string MySqlClientString =
        "server= localhost;Port=3306;User Id = root; " +
            "Database = bd_base; SSL Mode=0";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tbusuarios", conn);
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tbusuarios(login,senha) " +
                "VALUES('" + txtusuario.Text + "', " + txtsenha.Text + ")";
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            txtusuario.Clear();
            txtsenha.Clear();
            button1_Click(button1, e);
            MessageBox.Show("Registro Gravado com Sucesso", "Alerta",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja finalizar?", "Confirme",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}
