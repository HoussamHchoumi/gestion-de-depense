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
    
    public partial class Form1 : Form
    {
        ADO d = new ADO();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                textBox2.UseSystemPasswordChar = false;

            }
            else if (checkBox1.Checked == false)
            {

                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                //verification de personne 
            d.cmd = new SqlCommand("select count (*) from personne where nomDutilisateur = '" + textBox1.Text + "' and MotDePasse = '"+textBox2.Text+"'", d.cnx);
            d.CONNECTER();
            int i = (int)d.cmd.ExecuteScalar();
            if (i == 0)
            {
                MessageBox.Show("incorrect");

            }
            else
            {
                //enregistrer idpersonne dans un variable globale 
                d.cmd = new SqlCommand("select IdPersonne from personne where nomDutilisateur = '" + textBox1.Text + "' and MotDePasse = '" + textBox2.Text + "'", d.cnx);
             
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    ADO.GlobalVar = (int)d.dr[0];

                }
               
                menu m = new menu();
                m.Show();
                this.Hide();
            }
            d.DECONNECTER();
        }
    }
}
