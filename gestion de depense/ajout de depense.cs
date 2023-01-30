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
namespace gestion_de_depense
{
    public partial class ajout_de_depense : Form
    {
        ADO d = new ADO();

        public ajout_de_depense()
        {
            InitializeComponent();
        }
        void refresh()
        {
            dataGridView1.Rows.Clear();
            d.cmd = new SqlCommand("select * from charge where IdPersonne = '"+ADO.GlobalVar+"' ", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                dataGridView1.Rows.Add(d.dr[0].ToString(), d.dr[1].ToString(), d.dr[2].ToString(), d.dr[3].ToString(), d.dr[4].ToString(), d.dr[5].ToString());
            }
            d.dr.Close();
            d.DECONNECTER();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d.cmd = new SqlCommand(" insert into charge (TypeCharge,DateCharge,montant,observation,IdPersonne) values('" + comboBox1.Text + "', '" + dateTimePicker1.Value + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + ADO.GlobalVar + "') ", d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            MessageBox.Show("bient ajouter");
            d.DECONNECTER();
            refresh();
        }
       
        private void ajout_de_depense_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
