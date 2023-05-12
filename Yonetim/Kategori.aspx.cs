using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Kategori : System.Web.UI.Page
{


    string Baslik = "Kategori";
    string Link = "Kategori.aspx";



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
                DataRow drDuzenle = db.GetDataRow("Select * From tblKat where SanalId='" + Request.QueryString["Duzenle"] + "'");
                txtKatAd.Text = drDuzenle["KatAdi"].ToString();
                txtKatId.Text = drDuzenle["KatId"].ToString();
                txtKatId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblKat Where SanalId='" + Request.QueryString["Sil"] + "'");
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
        

        DataTable dt = db.GetDataTable("Select * From tblKat ORDER BY SanalId DESC");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (txtKatAd.Text != "" && txtKatId.Text!="")
        {
            if (btnKaydet.Text == "Kaydet")
            {
                DataTable dtKontrol = db.GetDataTable("Select * From tblKat where KatAdi='" + txtKatAd.Text + "' ");
                if (dtKontrol.Rows.Count==0)
                {
                    DataTable dtKontrol1 = db.GetDataTable("Select * From tblKat where KatId='" + txtKatId.Text + "' ");
                    if (dtKontrol1.Rows.Count == 0)
                    {
                        db.execute(" INSERT INTO tblKat(KatId,KatAdi) Values( '" + txtKatId.Text + "','" + txtKatAd.Text + "')");
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
                db.execute("Update tblKat Set  KatId='" + txtKatId.Text + "' , KatAdi='" + txtKatAd.Text + "' Where SanalId='" + Request.QueryString["Duzenle"] + "'");
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