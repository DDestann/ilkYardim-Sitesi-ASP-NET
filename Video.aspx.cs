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
    string Baslik = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");
        
        if (!Page.IsPostBack)
        {
            VideoListele();
        }

        Listele();



        Page.Title = Baslik + Session["Title"].ToString();
        Page.MetaKeywords = Baslik;


    }

    private void Listele()
    {
        if (Request.QueryString["VideoId"] != null && Request.QueryString["VideoId"].ToString() != "")
        {
            DataRow dr = db.GetDataRow("Select * From tblVideoKat WHERE VideoKatId='" + Request.QueryString["VideoId"] + "' ");
            lblBaslik.Text = dr["VideoKatAdi"].ToString();
            Baslik = dr["VideoKatAdi"].ToString();

        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void VideoListele()
    {
        


        if (Request.QueryString["VideoId"] != null && Request.QueryString["VideoId"].ToString() != "")
        {
            DataTable dt = db.GetDataTable("Select * From tblVideoAltKat WHERE VideoKatId='" + Request.QueryString["VideoId"] + "' ");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        
    }


  
}