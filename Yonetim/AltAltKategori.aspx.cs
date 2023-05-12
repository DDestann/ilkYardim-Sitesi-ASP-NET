using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class AltAltKategori : System.Web.UI.Page
{


    string Baslik = "Alt Alt Kategori";
    string Link = "AltAltKategori.aspx";



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
                drpAltKatDuzenListele();

                DataRow drDuzenle = db.GetDataRow("SELECT dbo.tblAltAltKat.*, dbo.tblAltKat.*, dbo.tblKat.* FROM  dbo.tblAltAltKat INNER JOIN " +
                         "dbo.tblAltKat ON dbo.tblAltAltKat.AltKatId = dbo.tblAltKat.AltKatId INNER JOIN " +
                        " dbo.tblKat ON dbo.tblAltKat.KatId = dbo.tblKat.KatId where dbo.tblAltAltKat.SanalAltAltKatId='" + Request.QueryString["Duzenle"] + "'");
               
                drpKat.SelectedValue = drDuzenle["KatId"].ToString();
                drpAltKat.SelectedValue = drDuzenle["AltKatId"].ToString();

                txtAltAltKatAd.Text = drDuzenle["AltAltKatAdi"].ToString();
                CKicerik.Text = drDuzenle["AltAltKatIcerik"].ToString();
                txtAltAltKatId.Text = drDuzenle["AltAltKatId"].ToString();
                txtAltAltKatId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";

               
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblAltAltKat Where SanalAltAltKatId='" + Request.QueryString["Sil"] + "'");
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

    private void drpAltKatListele()
    {
        //DataRow drKatId = db.GetDataRow("SELECT dbo.tblAltAltKat.*, dbo.tblAltKat.*, dbo.tblKat.* FROM  dbo.tblAltAltKat INNER JOIN " +
        //                 "dbo.tblAltKat ON dbo.tblAltAltKat.AltKatId = dbo.tblAltKat.AltKatId INNER JOIN " +
        //                " dbo.tblKat ON dbo.tblAltKat.KatId = dbo.tblKat.KatId");

        DataTable dtAltKat = db.GetDataTable("Select * From tblAltKat where KatId='"+drpKat.SelectedValue+"'");
        drpAltKat.DataTextField = "AltKatAdi";
        drpAltKat.DataValueField = "AltKatId";
        drpAltKat.DataSource = dtAltKat;
        drpAltKat.DataBind();
        drpAltKat.Items.Insert(0, new ListItem("Alt Kategori Seçiniz...", "0"));
    }

    private void drpAltKatDuzenListele()
    {
        DataRow drKatId = db.GetDataRow("SELECT dbo.tblAltAltKat.*, dbo.tblAltKat.*, dbo.tblKat.* FROM  dbo.tblAltAltKat INNER JOIN " +
                         "dbo.tblAltKat ON dbo.tblAltAltKat.AltKatId = dbo.tblAltKat.AltKatId INNER JOIN " +
                        " dbo.tblKat ON dbo.tblAltKat.KatId = dbo.tblKat.KatId");

        DataTable dtAltKat = db.GetDataTable("Select * From tblAltKat where KatId='" + drKatId["KatId"] + "'");
        drpAltKat.DataTextField = "AltKatAdi";
        drpAltKat.DataValueField = "AltKatId";
        drpAltKat.DataSource = dtAltKat;
        drpAltKat.DataBind();
        drpAltKat.Items.Insert(0, new ListItem("Alt Kategori Seçiniz...", "0"));
    }

    private void Listele()
    {


        DataTable dt = db.GetDataTable("SELECT dbo.tblAltAltKat.*, dbo.tblAltKat.*, dbo.tblKat.* FROM  dbo.tblAltAltKat INNER JOIN "+
                         "dbo.tblAltKat ON dbo.tblAltAltKat.AltKatId = dbo.tblAltKat.AltKatId INNER JOIN "+
                        " dbo.tblKat ON dbo.tblAltKat.KatId = dbo.tblKat.KatId ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }

   
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (drpKat.SelectedValue!="0")
        {
            if (drpAltKat.SelectedValue!="0")
            {
                if (drpKat.SelectedValue != "0" && drpAltKat.SelectedValue != "0" && txtAltAltKatAd.Text != "" && txtAltAltKatId.Text != "")
                {
                    if (btnKaydet.Text == "Kaydet")
                    {
                        DataTable dtKontrol = db.GetDataTable("Select * From tblAltAltKat where AltAltKatAdi='" + txtAltAltKatAd.Text + "' ");
                        if (dtKontrol.Rows.Count == 0)
                        {
                            DataTable dtKontrol1 = db.GetDataTable("Select * From tblAltAltKat where AltAltKatId='" + txtAltAltKatId.Text + "'  ");
                            if (dtKontrol1.Rows.Count == 0)
                            {
                                db.execute(" INSERT INTO tblAltAltKat(AltAltKatId,AltKatId,AltAltKatAdi,AltAltKatIcerik) Values('" + txtAltAltKatId.Text + "' ,'" + drpAltKat.SelectedValue + "' ,'" + txtAltAltKatAd.Text + "','" + CKicerik.Text + "')");
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
                        db.execute("Update tblAltAltKat Set   AltAltKatId='" + txtAltAltKatId.Text + "' ,AltKatId='" + drpAltKat.SelectedValue + "' , AltAltKatAdi='" + txtAltAltKatAd.Text + "', AltAltKatIcerik='" + CKicerik.Text + "' Where SanalAltAltKatId='" + Request.QueryString["Duzenle"] + "'");
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
        else
        {
            lblHata.Text = msj.alanBos(Baslik);
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            pnlKontrol.Visible = false;
        }

    }
    /////////////
    protected void drpKat_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpAltKatListele();
    }
}