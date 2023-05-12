using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Galeri : System.Web.UI.Page
{
    dbislem db = new dbislem();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        Page.Title = "Galeri " + Session["Title"].ToString();

        GaleriListele();
    }

    private void GaleriListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblGaleri");
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

      
        
    }

   

  
}