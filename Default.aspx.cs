using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text.RegularExpressions;
public partial class Default : System.Web.UI.Page
{
    dbislem db = new dbislem();
    protected void Page_Load(object sender, EventArgs e)
    {


        Session["Title"]=" || HİJYEN İLK YARDIM";


        Page.Title = "AnaSayfa" + Session["Title"].ToString() ;



        BannerLİstele();

        DuyuruLitele();
        TabMenuListele();
        AnaSayfaİcerikListele();
        AnaSayfaResimListele();
        AnaSayfaResimBuyukListele();
    }

  

    private void TabMenuListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblVideoAltKat ORDER BY VideoAltKatId DESC LIMIT 0,3 ");
        rptTabMenu.DataSource = dt;
        rptTabMenu.DataBind();
    }

    private void DuyuruLitele()
    {
        DataTable dt = db.GetDataTable("Select  * From tblDuyuru ORDER BY DuyuruId DESC LIMIT 0,3 ");
        Repeater2.DataSource = dt;
        Repeater2.DataBind();
    }

    private void AnaSayfaİcerikListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblAnaicerik ORDER BY RAND() LIMIT 2 ");
        Repeater3.DataSource = dt;
        Repeater3.DataBind();
    }

    private void AnaSayfaResimBuyukListele()
    {
        DataTable dt = db.GetDataTable("Select  * From tblAnaResim ORDER BY RAND() LIMIT 2 ");
        Repeater5.DataSource = dt;
        Repeater5.DataBind();
    }

    private void AnaSayfaResimListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblAnaResim ORDER BY AnaResimId DESC ");
        Repeater4.DataSource = dt;
        Repeater4.DataBind();
    }

    private void BannerLİstele()
    {
        DataTable dt = db.GetDataTable("Select * From tblBanner");
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }


    public string metin_kisalt_yan(string metin)
    {

        metin = Regex.Replace(metin, @"<(.\n)*?>", string.Empty);

        if (metin.Length > 150) metin = metin.Substring(0, 150);

        metin = metin + "...";

        return metin;

    }

    public string Duyurular(string ID, string baslik)
    {

        string git = db.linkYonlendir("Duyuru", ID, baslik);

        return git;
    }


    
}