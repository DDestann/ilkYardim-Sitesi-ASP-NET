using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Yonetim : System.Web.UI.Page
{


    string Baslik = "Yönetici";
    string Link = "Yonetim.aspx";



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
                }
                else if (Request.QueryString["Durum"] == "Guncelle")
                {
                    lblBasarili.Text = msj.basarili(Baslik, "Güncellendi");
                    pnlBasarili.Visible = true;
                    pnlHata.Visible = false;
                    
                }
            }
            else if (Request.QueryString["Duzenle"] != null && Request.QueryString["Duzenle"].ToString() != "")
            {
                DataRow drDuzenle = db.GetDataRow("Select * From tblYonetim where SanalYoneticiId='" + Request.QueryString["Duzenle"] + "'");
                txtAd.Text = drDuzenle["YoneticiAdi"].ToString();
                txtMail.Text=drDuzenle["YoneticiMail"].ToString();
                txtSifre.Text=drDuzenle["Sifre"].ToString();

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblYonetim Where SanalYoneticiId='" + Request.QueryString["Sil"] + "'");
                lblBasarili.Text = msj.basarili(Baslik, "Silindi");
                pnlBasarili.Visible = true;
                pnlHata.Visible = false;

            }

            Listele();
        }


        
    }

    private void Listele()
    {
        DataTable dt = db.GetDataTable("Select * From tblYonetim");
        Dtlist.DataSource = dt;
        Dtlist.DataBind();
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (txtYoneticiId.Text!="")
        {
            if (txtAd.Text != "")
            {
                if (txtAd.Text != "" && txtMail.Text != "")
                {
                    if (txtAd.Text != "" && txtMail.Text != "" && txtSifre.Text != "" && txtYoneticiId.Text != "")
                    {
                        if (btnKaydet.Text == "Kaydet")
                        {
                            db.execute(" INSERT INTO tblYonetim(YoneticiId,YoneticiAdi,YoneticiMail,Sifre) Values('" + txtYoneticiId.Text + "' ,'" + txtAd.Text + "' , '" + txtMail.Text + "' ,'" + txtSifre.Text + "' )");
                            Response.Redirect(Link + "?Durum=Kaydet");
                        }
                        else if (btnKaydet.Text == "Güncelle")
                        {
                            db.execute("Update tblYonetim Set YoneticiId='" + txtYoneticiId.Text + "',  YoneticiAdi='" + txtAd.Text + "' , YoneticiMail='" + txtMail.Text + "', Sifre='" + txtSifre.Text + "'  Where SanalYoneticiId='" + Request.QueryString["Duzenle"] + "'");
                            Response.Redirect(Link + "?Durum=Guncelle");
                        }


                    }
                    else
                    {
                        lblHata.Text = msj.alanBos(Baslik);
                        pnlHata.Visible = true;
                        pnlBasarili.Visible = false;
                    }
                }
                else
                {
                    lblHata.Text = msj.alanBos(Baslik);
                    pnlHata.Visible = true;
                    pnlBasarili.Visible = false;
                }
            }
            else
            {
                lblHata.Text = msj.alanBos(Baslik);
                pnlHata.Visible = true;
                pnlBasarili.Visible = false;
            }
        }
        else
        {
            lblHata.Text = msj.alanBos(Baslik);
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
        }

  
    }
}