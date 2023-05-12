using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iletisim : System.Web.UI.Page
{
    dbislem db = new dbislem();

    string Baslik = "iletişim";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        DataRow dr = db.GetDataRow("Select * From tblIletisim");
        if (dr!=null)
        {
            lblAdSoyad.Text=dr["AdSoyad"].ToString();
        lblTel.Text = dr["Tel"].ToString();
        lblMail.Text = dr["Mail"].ToString();
        }
        


        
      Page.Title = Baslik+Session["Title"].ToString();
      Page.MetaKeywords = Baslik;
        

    }

   

}