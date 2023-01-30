using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace gestion_de_depense
{
    class ADO
    {
        // Declaration des objets sql
        public SqlConnection cnx = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();


        private static int idutulisateur = 5;

        public static int GlobalVar
        {
            get { return idutulisateur; }
            set { idutulisateur = value; }
        }

        // declaration de la methode connecter
        public void CONNECTER()
        {
            if (cnx.State == ConnectionState.Closed || cnx.State == ConnectionState.Broken)
            {
                // cnx.ConnectionString = "Data Source=LENOVOPC;Initial Catalog=TDI;Integrated Security=True";
                cnx.ConnectionString = @"Data Source=DESKTOP-U8SOM8J\SQLEXPRESS;Initial Catalog=GestionDepense;Integrated Security=True";
                cnx.Open();
            }
        }

        // declaration de la methode deconnecter
        public void DECONNECTER()
        {
            if (cnx.State == ConnectionState.Open)
            {

                cnx.Close();
            }
        }
    }
}
