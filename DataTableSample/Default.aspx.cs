using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataKlasse;

namespace DataTableSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected DBLayer dbl = new DBLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        

       

        protected void ButtonShowAll_Click(object sender, EventArgs e)
        {
            GridView1.DataSource= dbl.GetAllDataFromElever();
            GridView1.DataBind();
        }
        protected void ButtonSearchElev_Click(object sender, EventArgs e)
        {
            string Fornavn = TextBoxSearchElev.Text; 
            GridView1.DataSource = dbl.GetElev(Fornavn);
            GridView1.DataBind();
        }
    }
}