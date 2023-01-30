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
    public partial class gestion_depense : Form
    {
        ADO d = new ADO();
        DataSet ds1 = new DataSet();
         public gestion_depense()
        {
            InitializeComponent();
        }
       
         
        private void gestion_depense_Load(object sender, EventArgs e)
        {
            //chargement de combobox 
            d.CONNECTER();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from personne", d.cnx);
            da1.Fill(ds1, "pr");
            comboBox1.DataSource = ds1.Tables["pr"];
            comboBox1.DisplayMember = "nomDutilisateur";
            comboBox1.ValueMember = "IdPersonne";
            d.DECONNECTER();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            d.cmd = new SqlCommand("select sum (montant) from charge where IdPersonne = '"+comboBox1.SelectedValue+"'",d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while(d.dr.Read())
            {
                dataGridView1.Rows.Add(comboBox1.Text, d.dr[0]);
            }
            d.DECONNECTER();
        }
    }
}
