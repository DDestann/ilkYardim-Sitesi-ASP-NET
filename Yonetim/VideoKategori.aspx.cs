using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class VideoKategori : System.Web.UI.Page
{


    string Baslik = "Video Kategori";
    string Link = "VideoKategori.aspx";



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
                DataRow drDuzenle = db.GetDataRow("Select * From tblVideoKat where SanalVideoKatId='" + Request.QueryString["Duzenle"] + "'");
                txtVideoKatAd.Text = drDuzenle["VideoKatAdi"].ToString();
                txtVideoKatId.Text = drDuzenle["VideoKatId"].ToString();
                txtVideoKatId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblVideoKat Where SanalVideoKatId='" + Request.QueryString["Sil"] + "'");
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
        

        DataTable dt = db.GetDataTable("Select * From tblVideoKat ORDER BY SanalVideoKatId DESC");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (txtVideoKatAd.Text != "" && txtVideoKatId.Text!="")
        {
            if (btnKaydet.Text == "Kaydet")
            {
                DataTable dtKontrol = db.GetDataTable("Select * From tblVideoKat where VideoKatAdi='" + txtVideoKatAd.Text + "' ");
                if (dtKontrol.Rows.Count==0)
                {
                    DataTable dtKontrol1 = db.GetDataTable("Select * From tblVideoKat where VideoKatId='" + txtVideoKatId.Text + "' ");
                    if (dtKontrol1.Rows.Count == 0)
                    {
                        db.execute(" INSERT INTO tblVideoKat(VideoKatId,VideoKatAdi) Values( '" + txtVideoKatId.Text + "','" + txtVideoKatAd.Text + "')");
                        Response.Redirect(Link + "?Durum=Kaydet");
                    }
                    else
                    {
                        pnlHata.Visible = false;
                        pnlBasarili.Visible = false;

                        lblKontrol.Text = msj.Kontrol(Baslik);
                        pnlKontrol.Visible = true;
                    }
                }
                else
                {
                    pnlHata.Visible = false;
                    pnlBasarili.Visible = false;

                    lblKontrol.Text = msj.Kontrol(Baslik);
                    pnlKontrol.Visible = true;
                }
            }
            else if (btnKaydet.Text == "Güncelle")
            {
                db.execute("Update tblVideoKat Set  VideoKatId='" + txtVideoKatId.Text + "' , VideoKatAdi='" + txtVideoKatAd.Text + "' Where SanalVideoKatId='" + Request.QueryString["Duzenle"] + "'");
                Response.Redirect(Link + "?Durum=Guncelle");
            }


        }
        else
        {
            lblHata.Text = msj.alanBos(Baslik);
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            pnlKontrol.Visible = false;
        }

    }
}