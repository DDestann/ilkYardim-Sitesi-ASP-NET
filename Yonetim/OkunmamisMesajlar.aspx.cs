using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class OkunmamisMesajlar : System.Web.UI.Page
{


    string Baslik = "Okunmamis Mesajlar";
    string Link = "OkunmamisMesajlar.aspx";



    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title =Baslik + " || İSTANBUL İLK YARDIM ";

       
        lblBaslik.Text = Baslik;



        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Durum"] != null && Request.QueryString["Durum"].ToString() != "")
            {
                if (Request.QueryString["Durum"] == "Guncelle")
                {
                    lblBasarili.Text = msj.basarili(Baslik, "Güncellendi Ve Yayınlandı");
                    pnlBasarili.Visible = true;
                    pnlHata.Visible = false;
                    pnlKontrol.Visible = false;
                    
                }
            }
            else if (Request.QueryString["Duzenle"] != null && Request.QueryString["Duzenle"].ToString() != "")
            {
                DataRow drDuzenle = db.GetDataRow("Select * From tblMesajlar where MsjId='" + Request.QueryString["Duzenle"] + "'");
                
                txtKulAd.Text = drDuzenle["KullaniciAdi"].ToString();
                txtMail.Text = drDuzenle["Mail"].ToString();
                txtKonu.Text = drDuzenle["Konu"].ToString();
                txtMesaj.Text = drDuzenle["Mesaj"].ToString();
                 txtCevap.Text = drDuzenle["MesajCevap"].ToString();
                lblBaslik.Text = Baslik + " Güncelle";
                pnlMesaj.Visible = true;
                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblMesajlar Where MsjId='" + Request.QueryString["Sil"] + "'");
                lblBasarili.Text = msj.basarili(Baslik, "Silindi");
                pnlBasarili.Visible = true;
                pnlHata.Visible = false;
                pnlKontrol.Visible = false;

            }

            Listele();
        }

        Listele();
        
    }

    private void Listele()
    {
    
        DataTable dt = db.GetDataTable("Select * From tblMesajlar Where Onay=0  ORDER BY MsjId DESC");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
        
        

     
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

      
             if (btnKaydet.Text == "Güncelle")
            {
                db.execute("Update tblMesajlar Set  MesajCevap='" + txtCevap.Text + "',Onay=1  Where MsjId='" + Request.QueryString["Duzenle"] + "'");
                Response.Redirect(Link + "?Durum=Guncelle");
            }


    }
    protected void btniptal_Click(object sender, EventArgs e)
    {
        pnlMesaj.Visible = false;
    }
}