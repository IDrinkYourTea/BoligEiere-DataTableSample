using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHusEier;

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
            GridView1.DataSource= dbl.GetAllDataFromEierAndHus();
            GridView1.DataBind();
        }
        protected void ButtonSearchTelefonNR_Click(object sender, EventArgs e)
        {
            List<BoligOgEier> boe = dbl.GetAllDataFromEierAndHusWhereTLFnr(int.Parse(TextBoxSearchTelefonNR.Text));
            GridView1.DataSource = boe;
            GridView1.DataBind();
        }
    }
}