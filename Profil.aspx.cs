using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;
using System.Web.Security;

public partial class Profil : System.Web.UI.Page
{
    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();
    resimislemleri Resim = new resimislemleri();

    string Cinsiyet="";
    
    string ResimYolu = "";
    string Baslik = "Profil";
  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        Page.Title = Baslik + Session["Title"].ToString();

        
        
        if (!Page.IsPostBack)
        {

            if (Session["KullaniciId"] != "" && Session["KullaniciId"] != null)
            {
                if (Session["Engel"] != "1")
                {
                    Listele();
                ilListele();
                }
                else
                {
                    Response.Redirect("KulGiris.aspx");
                }
                

                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }


        }

                

    }

    



 


    private void Listele()
    {
        ilListele();
        ilce2Listele();

        DataRow dr = db.GetDataRow("SELECT  tblKullanici.*,  tbliller.*,  tblilceler.* FROM   tblKullanici INNER JOIN " +
                       "  tbliller ON  tblKullanici.ilId =  tbliller.ilId INNER JOIN " +
                       "  tblilceler ON  tblKullanici.ilceId =  tblilceler.ilceId where  tblKullanici.KullaniciId='"+Session["KullaniciId"]+"' AND  tblKullanici.Engel=0");
        Drpil.SelectedValue = dr["ilId"].ToString();
        Drpilce.SelectedValue = dr["ilceId"].ToString();

        lblililce.Text = dr["ilAdi"].ToString()+" / "+dr["ilceAdi"].ToString();

        lblKulAd.Text = dr["AdSoyad"].ToString();
        txtAdSoyad.Text = dr["AdSoyad"].ToString();
        txtSifre.Text = dr["Sifre"].ToString();
        txtDTarih.Text = dr["DTarih"].ToString();
        ProfilResim.ImageUrl = Resim.resimGetirPanel("Profil", "Kucuk") + dr["ResimYolu"].ToString();
        if (dr["Cinsiyet"].ToString() == "Bay")
            rdbtnBay.Checked = true;
        else
        rdbtnBayan.Checked = true;

        UpdatePanel1.Visible = false;
        txtAdSoyad.Enabled = false;
        txtSifre.Enabled = false;
        txtDTarih.Enabled = false;
        rdbtnBay.Enabled = false;
        rdbtnBayan.Enabled = false;
        fluResim.Enabled = false;
       
      
      


    }

    private void ilListele()
    {
        DataTable dt = db.GetDataTable("Select * From tbliller");
        Drpil.DataTextField = "ilAdi";
        Drpil.DataValueField = "ilId";
        Drpil.DataSource = dt;
        Drpil.DataBind();
        Drpil.Items.Insert(0, new ListItem("il Seçiniz..", "0"));


    }

    private void ilceListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblilceler where ilId=" + Drpil.SelectedValue);
        Drpilce.DataTextField = "ilceAdi";
        Drpilce.DataValueField = "ilceId";
        Drpilce.DataSource = dt;
        Drpilce.DataBind();
        //Drpilce.Items.Insert(0, new ListItem("ilce Seçiniz..", "0"));


    }

    private void ilce2Listele()
    {
        DataTable dt = db.GetDataTable("Select * From tblilceler");
        Drpilce.DataTextField = "ilceAdi";
        Drpilce.DataValueField = "ilceId";
        Drpilce.DataSource = dt;
        Drpilce.DataBind();
        //Drpilce.Items.Insert(0, new ListItem("ilce Seçiniz..", "0"));


    }
    protected void Drpil_SelectedIndexChanged(object sender, EventArgs e)
    {
        ilceListele();
    }
    protected void BtnGuncelle_Click(object sender, EventArgs e)
    {
        string SilinecekResim = "";
      
        if (fluResim.HasFile)
        {
                DataRow drResim = db.GetDataRow("Select * From tblKullanici Where KullaniciId='" + Session["KullaniciId"] + "'");
                SilinecekResim = drResim["ResimYolu"].ToString();

                FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel2("Profil", "buyuk")) + SilinecekResim);
                fi.Delete();

                FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel2("Profil", "kucuk")) + SilinecekResim);
                fi2.Delete();

                FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel2("Profil", "orjinal")) + SilinecekResim);
                fi3.Delete();

           
           
                ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "Profil", 250, 200);

                if (rdbtnBay.Checked)
                    Cinsiyet = "Bay";
                else
                    Cinsiyet = "Bayan";

                db.execute("Update tblKullanici Set AdSoyad='" + txtAdSoyad.Text + "', ilId='" + Drpil.SelectedValue + "', ilceId='" + Drpilce.SelectedValue + "', Sifre='" + txtSifre.Text + "', Cinsiyet='" + Cinsiyet + "',ResimYolu='" + ResimYolu + "' ,DTarih='" + txtDTarih.Text + "'  Where KullaniciId=" + Session["KullaniciId"]);

                Response.Redirect("Profil.aspx");
           

        }
        else
        {
            if (rdbtnBay.Checked)
                Cinsiyet = "Bay";
            else
                Cinsiyet = "Bayan";

            //if (rdbtnBay.Checked)
            //    ResimYolu = "ResimYokBay.jpg";
            //else
            //    ResimYolu = "ResimYokBayan.jpg";


            db.execute("Update tblKullanici Set AdSoyad='" + txtAdSoyad.Text + "', ilId='" + Drpil.SelectedValue + "', ilceId='" + Drpilce.SelectedValue + "', Sifre='" + txtSifre.Text + "', Cinsiyet='" + Cinsiyet + "' ,DTarih='" + txtDTarih.Text + "' Where KullaniciId=" + Session["KullaniciId"]);

            Response.Redirect("Profil.aspx");
        }


        BtnGuncelle.Visible = false;
        BtnDuzenle.Visible = true;

        UpdatePanel1.Visible = false;
        txtAdSoyad.Enabled = false;
        txtSifre.Enabled = false;
        txtDTarih.Enabled = false;
        rdbtnBay.Enabled = false;
        rdbtnBayan.Enabled = false;
        fluResim.Enabled = false;
        
       
    }
    protected void BtnDuzenle_Click(object sender, EventArgs e)
    {
        BtnGuncelle.Visible = true;
        BtnDuzenle.Visible = false;

        UpdatePanel1.Visible = true;
        txtAdSoyad.Enabled = true;
        txtSifre.Enabled = true;
        txtDTarih.Enabled = true;
        rdbtnBay.Enabled = true;
        rdbtnBayan.Enabled = true;
        fluResim.Enabled = true;


    }

    protected void btnProfil_Click(object sender, EventArgs e)
    {
        pnlBilgi.Visible = true;
        pnlGonder.Visible = false;
    
        pnlBasarili.Visible = false;
        pnlHata.Visible = false;
     
    }

    protected void btnMsj_Click(object sender, EventArgs e)
    {
        pnlBilgi.Visible = false;
        pnlGonder.Visible = true;
     
      
    }
    protected void btnMsjGonder_Click(object sender, EventArgs e)
    {
        if (txtKonu.Text!="" && txtMsj.Text!="")
        {
            db.execute("Insert Into tblMesajlar(KullaniciAdi,Mail,Konu,Mesaj,GTarih,Onay) Values('" + Session["AdSoyad"] + "','" + Session["Mail"] + "','" + txtKonu.Text + "','" + txtMsj.Text + "','" + DateTime.Now.ToString() + "' ,'" + "0" + "' )");
            lblBasarili.Text = "Mesajınız Admin Onayına Başarıyla Gönderilmiştir...";
            pnlBasarili.Visible = true;
            pnlHata.Visible = false;

            txtMsj.Text = "";
            txtKonu.Text = "";

        }
        else
        {
            lblHata.Text = "Mesaj Göndermek için Konu ve Mesaj Kısmını Boş Bırakmayınız";
            pnlBasarili.Visible = false;
            pnlHata.Visible = true;

        }
        

    }
}