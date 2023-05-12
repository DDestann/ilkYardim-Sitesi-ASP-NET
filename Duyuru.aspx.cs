using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Duyuru : System.Web.UI.Page
{
    dbislem db = new dbislem();

    string Baslik = "Duyuru";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["Id"] == null)
        //    Response.Redirect("Default.aspx");

        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        Page.Title = Baslik + Session["Title"].ToString();
      lblBaslik.Text = Baslik;
      Page.MetaKeywords = Baslik;
   
      DuyuruListele();
    }

    private void DuyuruListele()
    {

        DataTable dt = db.GetDataTable("Select * From tblDuyuru ORDER BY DuyuruId DESC");
        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = DtList;
        DtList.DataSource = Sayfalama.DataSourcePaged;
        DtList.DataBind();

    }

    public string metin_kisalt_yan(string metin)
    {

        metin = Regex.Replace(metin, @"<(.\n)*?>", string.Empty);

        if (metin.Length > 450) metin = metin.Substring(0, 450);

        metin = metin + "...";

        return metin;

    }

    public string Duyurular(string ID, string baslik)
    {

        string git = db.linkYonlendir("Duyuru", ID, baslik);

        return git;
    }
}