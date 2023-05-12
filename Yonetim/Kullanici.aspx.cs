using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;

public partial class Kullanici : System.Web.UI.Page
{


    string Baslik = "Kullanici";
    string Link = "Kullanici.aspx";
    string ResimYolu = "";
    string SilinecekResim = "";
   

    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();
    resimislemleri Resim = new resimislemleri();


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title =Baslik + " || İSTANBUL İLK YARDIM ";

       
        lblBaslik.Text = Baslik +" Ekle";


        if (Request.QueryString["Engelle"] != null && Request.QueryString["Engelle"].ToString() != "")
            {
                db.execute("Update tblKullanici Set Engel=1 Where KullaniciId='" + Request.QueryString["Engelle"] + "'");
                lblBasarili.Text = msj.basarili(Baslik, "Engellendi");
                pnlBasarili.Visible = true;
                pnlHata.Visible = false;
                pnlKontrol.Visible = false;
            }
        if (Request.QueryString["EngelKaldir"] != null && Request.QueryString["EngelKaldir"].ToString() != "")
        {
            db.execute("Update tblKullanici Set Engel=0 Where KullaniciId='" + Request.QueryString["EngelKaldir"] + "'");
            lblBasarili.Text = msj.basarili(Baslik, "Engellendi");
            pnlBasarili.Visible = true;
            pnlHata.Visible = false;
            pnlKontrol.Visible = false;
        }

        Listele();
        Listele2();
        ListeleEngelleAra();
        ListeleEngelliAra();
        
    }

    private void Listele()
    {
        DataTable dt = db.GetDataTable("Select * From tblKullanici Where Engel=0");
       
        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
        pnlKaldir.Visible = true;
        pnlEngelle.Visible = false;

    }

    private void Listele2()
    {
        DataTable dt = db.GetDataTable("Select * From tblKullanici Where Engel=1");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = DtListEngelKaldir;
        DtListEngelKaldir.DataSource = Sayfalama.DataSourcePaged;
        DtListEngelKaldir.DataBind();

        pnlKaldir.Visible = false;
        pnlEngelle.Visible = true;
    }


    private void ListeleEngelleAra()
    {

        DataTable dt = db.GetDataTable("Select * From tblKullanici Where Engel=0 AND AdSoyad Like '%" + txtAra.Text + "%' OR Mail Like '%" + txtAra.Text + "%' ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = DtListNormalAra;
        DtListNormalAra.DataSource = Sayfalama.DataSourcePaged;
        DtListNormalAra.DataBind();
       

    }

    private void ListeleEngelliAra()
    {

        DataTable dt = db.GetDataTable("Select * From tblKullanici Where Engel=1 AND AdSoyad Like '%" + txtAra2.Text + "%' OR Mail Like '%" + txtAra2.Text + "%' ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = DtListEngelliAra;
        DtListEngelliAra.DataSource = Sayfalama.DataSourcePaged;
        DtListEngelliAra.DataBind();


    }


    protected void DrpList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpList.SelectedValue=="0")
        {
             //pnlKaldir.Visible = false;
             //pnlEngelle.Visible = false;
        }
        else if (DrpList.SelectedValue == "1")
        {
            pnlKaldir.Visible = true;
            pnlEngelle.Visible = false;
        }
        else if (DrpList.SelectedValue == "2")
        {
            pnlKaldir.Visible = false;
            pnlEngelle.Visible = true;
        }
    }
    protected void DrpAra_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpAra.SelectedValue == "0")
        {
            pnlNormalAra.Visible = false;
            pnlEngelliAra.Visible = false;
        }
        else if (DrpAra.SelectedValue == "1")
        {
            pnlNormalAra.Visible = false;
            pnlEngelliAra.Visible = true;
        }
        else if (DrpAra.SelectedValue == "2")
        {
            pnlNormalAra.Visible = true;
            pnlEngelliAra.Visible = false;
        }
       
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        if (txtAra.Text != "" && DrpAra.SelectedValue!="0")
        {
            
            ListeleEngelleAra();
            pnlNormalAra.Visible = true;
            pnlEngelliAra.Visible = false;
        }



    }
    protected void btnAra2_Click(object sender, EventArgs e)
    {
        if (txtAra2.Text != "" && DrpAra.SelectedValue != "0")
        {
            
            ListeleEngelliAra();
            pnlEngelliAra.Visible = true;
            pnlNormalAra.Visible = false;
        }
    }
}