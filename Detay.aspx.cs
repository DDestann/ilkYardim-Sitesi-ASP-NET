using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detay : System.Web.UI.Page
{
    dbislem db = new dbislem();

    string Baslik = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        if (Request.QueryString["Id"] != null && Request.QueryString["Id"].ToString() != "")
        {
            DataRow dr = db.GetDataRow("Select * From tblAltKat Where AltKatId=" + Request.QueryString["Id"]);
            Baslik = dr["AltKatAdi"].ToString();
            lblBaslik.Text = dr["AltKatAdi"].ToString();
            lblicerik.Text = dr["AltKatIcerik"].ToString();
        }
        else if (Request.QueryString["DuyuruId"] != null && Request.QueryString["DuyuruId"].ToString() != "")
        {
            DataRow dr = db.GetDataRow("Select * From tblDuyuru Where DuyuruId=" + Request.QueryString["DuyuruId"]);
            Baslik = dr["Baslik"].ToString();
            lblBaslik.Text = dr["Baslik"].ToString();
            lblicerik.Text = dr["icerik"].ToString();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

        Page.MetaKeywords = Baslik + Session["Key"].ToString();
        Page.Title = Baslik + Session["Title"].ToString();
        
        
    }

   

}