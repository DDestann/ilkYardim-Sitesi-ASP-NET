using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class AltKategori : System.Web.UI.Page
{


    string Baslik = "Alt Kategori";
    string Link = "AltKategori.aspx";



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
                DataRow drDuzenle = db.GetDataRow("SELECT  tblAltKat.*,  tblKat.* FROM    tblAltKat INNER JOIN "+
                         " tblKat ON  tblAltKat.KatId =  tblKat.KatId where  tblAltKat.AltSanalId='" + Request.QueryString["Duzenle"] + "'");
                drpKat.SelectedValue = drDuzenle["KatId"].ToString();
                txtAltKatAd.Text = drDuzenle["AltKatAdi"].ToString();
                CKicerik.Text = drDuzenle["AltKatIcerik"].ToString();
                txtAltKatId.Text = drDuzenle["AltKatId"].ToString();
                txtAltKatId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblAltKat Where AltSanalId='" + Request.QueryString["Sil"] + "'");
                lblBasarili.Text = msj.basarili(Baslik, "Silindi");
                pnlBasarili.Visible = true;
                pnlHata.Visible = false;
                pnlKontrol.Visible = false;

            }

            Listele();
            drpKatListele();
        }

        Listele();
        
    }

    private void drpKatListele()
    {
        DataTable dtKat = db.GetDataTable("Select * From tblKat");
        drpKat.DataTextField = "KatAdi";
        drpKat.DataValueField = "KatId";
        drpKat.DataSource = dtKat;
        drpKat.DataBind();
        drpKat.Items.Insert(0,new ListItem("Kategori Seçiniz...","0"));
    }

    private void Listele()
    {


        DataTable dt = db.GetDataTable("SELECT tblAltKat.*, tblKat.* FROM    tblAltKat INNER JOIN " +
                         "tblKat ON tblAltKat.KatId = tblKat.KatId ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }


    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (drpKat.SelectedValue!="0")
        {
            if (drpKat.SelectedValue != "0" && txtAltKatAd.Text != "" && txtAltKatId.Text != "")
            {
                if (btnKaydet.Text == "Kaydet")
                {
                    DataTable dtKontrol = db.GetDataTable("Select * From tblAltKat where AltKatAdi='" + txtAltKatAd.Text + "' ");
                    if (dtKontrol.Rows.Count == 0)
                    {
                        DataTable dtKontrol1 = db.GetDataTable("Select * From tblAltKat where AltKatId='" + txtAltKatId.Text + "'  ");
                        if (dtKontrol1.Rows.Count == 0)
                        {
                            db.execute(" INSERT INTO tblAltKat(AltKatId,KatId,AltKatAdi,AltKatIcerik) Values('" + txtAltKatId.Text + "' ,'" + drpKat.SelectedValue + "','" + txtAltKatAd.Text + "','" + CKicerik.Text + "')");
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
                    db.execute("Update tblAltKat Set   AltKatId='" + txtAltKatId.Text + "' ,KatId='" + drpKat.SelectedValue + "' , AltKatAdi='" + txtAltKatAd.Text + "', AltKatIcerik='" + CKicerik.Text + "' Where AltSanalId='" + Request.QueryString["Duzenle"] + "'");
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
        else
        {
            lblHata.Text = msj.alanBos(Baslik);
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            pnlKontrol.Visible = false;
        }

    }
}