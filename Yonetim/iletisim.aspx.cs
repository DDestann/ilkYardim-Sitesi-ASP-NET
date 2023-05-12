using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class iletisim : System.Web.UI.Page
{


    string Baslik = "iletişim";
    string Link = "iletisim.aspx";



    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title =Baslik + " || İSTANBUL İLK YARDIM ";

       
        lblBaslik.Text = Baslik +" Ekle";



        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Durum"] != null && Request.QueryString["Durum"].ToString() != "")
            {
                if (Request.QueryString["Durum"] == "Kaydet")
                {
                    lblBasarili.Text = msj.basarili(Baslik, "Kaydedildi");
                    pnlBasarili.Visible = true;
                    pnlHata.Visible = false;
                    pnlKontrol.Visible = false;
                }
                else if (Request.QueryString["Durum"] == "Guncelle")
                {
                    lblBasarili.Text = msj.basarili(Baslik, "Güncellendi");
                    pnlBasarili.Visible = true;
                    pnlHata.Visible = false;
                    pnlKontrol.Visible = false;
                    
                }
            }
            else if (Request.QueryString["Duzenle"] != null && Request.QueryString["Duzenle"].ToString() != "")
            {
                DataRow drDuzenle = db.GetDataRow("Select * From tblIletisim where IletisimId='" + Request.QueryString["Duzenle"] + "'");
                txtAdSoyad.Text = drDuzenle["AdSoyad"].ToString();
                txtMail.Text = drDuzenle["Mail"].ToString();
                txtTel.Text=drDuzenle["Tel"].ToString();

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblIletisim Where IletisimId='" + Request.QueryString["Sil"] + "'");
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


        DataTable dt = db.GetDataTable("Select * From tblIletisim ORDER BY IletisimId DESC");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

            if (btnKaydet.Text == "Kaydet")
            {

                db.execute(" INSERT INTO tblIletisim(AdSoyad,Mail,Tel) Values( '" + txtAdSoyad.Text + "','" + txtMail.Text + "' ,'" + txtTel.Text + "'  )");
                        Response.Redirect(Link + "?Durum=Kaydet");
                
            }
            else if (btnKaydet.Text == "Güncelle")
            {
                db.execute("Update tblIletisim Set  AdSoyad='" + txtAdSoyad.Text + "' , Mail='" + txtMail.Text + "',Tel='" + txtTel.Text + "'  Where IletisimId='" + Request.QueryString["Duzenle"] + "'");
                Response.Redirect(Link + "?Durum=Guncelle");
            }


        

    }
}