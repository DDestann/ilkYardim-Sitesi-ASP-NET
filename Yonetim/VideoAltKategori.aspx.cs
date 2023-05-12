using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;

public partial class VideoAltKategori : System.Web.UI.Page
{


    string Baslik = "Video Alt Kategori";
    string Link = "VideoAltKategori.aspx";
    string ResimYolu = "";
    string SilinecekResim = "";


    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();
    resimislemleri Resim = new resimislemleri();

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
                DataRow drDuzenle = db.GetDataRow("SELECT  tblVideoAltKat.*, tblVideoKat.* FROM  tblVideoAltKat INNER JOIN "+
                         "tblVideoKat ON tblVideoAltKat.VideoKatId = tblVideoKat.VideoKatId where tblVideoAltKat.SanalVideoAltKatId='" + Request.QueryString["Duzenle"] + "'");
                drpVideoKat.SelectedValue = drDuzenle["VideoKatId"].ToString();
                txtVideoAltKatAd.Text = drDuzenle["VideoAdi"].ToString();
                txtVideoLink.Text = drDuzenle["videoLink"].ToString();
                ImageEskiResim.ImageUrl = Resim.resimGetirPanel("Video", "kucuk") + drDuzenle["VideoResimYolu"].ToString();
                pnlEskiResim.Visible = true;
                txtAltKatId.Text = drDuzenle["VideoAltKatId"].ToString();
                txtAltKatId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                DataRow drResim = db.GetDataRow("Select VideoResimYolu From tblVideoAltKat where SanalVideoAltKatId='" + Request.QueryString["Sil"] + "'");
                SilinecekResim = drResim["VideoResimYolu"].ToString();

                FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Video", "buyuk")) + SilinecekResim);
                fi.Delete();

                FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Video", "kucuk")) + SilinecekResim);
                fi2.Delete();

                FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Video", "orjinal")) + SilinecekResim);
                fi3.Delete();


                db.execute("Delete From tblVideoAltKat Where SanalVideoAltKatId='" + Request.QueryString["Sil"] + "'");
                lblBasarili.Text = msj.basarili(Baslik, "Silindi");
                pnlBasarili.Visible = true;
                pnlHata.Visible = false;
                pnlKontrol.Visible = false;
                pnlEskiResim.Visible = false;

                


            }

            Listele();
            drpKatListele();
        }

        Listele();
        
    }

    private void drpKatListele()
    {
        DataTable dtKat = db.GetDataTable("Select * From tblVideoKat");
        drpVideoKat.DataTextField = "VideoKatAdi";
        drpVideoKat.DataValueField = "VideoKatId";
        drpVideoKat.DataSource = dtKat;
        drpVideoKat.DataBind();
        drpVideoKat.Items.Insert(0, new ListItem("Video Kategori Seçiniz...", "0"));
    }

    private void Listele()
    {


        DataTable dt = db.GetDataTable("SELECT  tblVideoAltKat.*, tblVideoKat.* FROM  tblVideoAltKat INNER JOIN " +
                         "tblVideoKat ON tblVideoAltKat.VideoKatId = tblVideoKat.VideoKatId  ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }


    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (drpVideoKat.SelectedValue!="0")
        {
            if (drpVideoKat.SelectedValue != "0" && txtVideoAltKatAd.Text != "" && txtAltKatId.Text != "" && txtVideoLink.Text != "")
            {
                if (btnKaydet.Text == "Kaydet")
                {
                    DataTable dtKontrol = db.GetDataTable("Select * From tblVideoAltKat where VideoAdi='" + txtVideoAltKatAd.Text + "' ");
                    if (dtKontrol.Rows.Count == 0)
                    {
                        DataTable dtKontrol1 = db.GetDataTable("Select * From tblVideoAltKat where VideoAltKatId='" + txtAltKatId.Text + "'  ");
                        if (dtKontrol1.Rows.Count == 0)
                        {
                            if (fluResim.HasFile)
                            {
                                ResimYolu = Resim.resimKaydet(fluResim.PostedFile,"Video",300,200);
                                db.execute(" INSERT INTO tblVideoAltKat(VideoAltKatId,VideoKatId,VideoAdi,VideoLink,VideoResimYolu) Values('" + txtAltKatId.Text + "' ,'" + drpVideoKat.SelectedValue + "','" + txtVideoAltKatAd.Text + "','" + txtVideoLink.Text + "' ,'" + ResimYolu + "' )");
                                Response.Redirect(Link + "?Durum=Kaydet");
                            }
                            else
                            {
                                lblHata.Text = msj.alanBos(Baslik + " Resmi");
                                pnlHata.Visible = true;
                                pnlBasarili.Visible = false;
                                pnlKontrol.Visible = false;
                                pnlEskiResim.Visible = false;
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
                    if (fluResim.HasFile)
                    {
                        DataRow drResim = db.GetDataRow("Select VideoResimYolu From tblVideoAltKat Where SanalVideoAltKatId='" + Request.QueryString["Duzenle"] + "'");
                        SilinecekResim = drResim["VideoResimYolu"].ToString();

                        FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Video", "buyuk")) + SilinecekResim);
                        fi.Delete();

                        FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Video", "kucuk")) + SilinecekResim);
                        fi2.Delete();

                        FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Video", "orjinal")) + SilinecekResim);
                        fi3.Delete();


                        ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "Video", 300, 200);

                        db.execute(" UPDATE tblVideoAltKat Set VideoAltKatId='" + txtAltKatId.Text + "',VideoKatId='" + drpVideoKat.SelectedValue + "',VideoAdi='" + txtVideoAltKatAd.Text + "',VideoLink='" + txtVideoLink.Text + "',VideoResimYolu='" + ResimYolu + "' Where SanalVideoAltKatId='" + Request.QueryString["Duzenle"] + "' ");
                        Response.Redirect(Link + "?Durum=Guncelle");

                    }
                    else
                    {
                        db.execute(" UPDATE tblVideoAltKat Set VideoAltKatId='" + txtAltKatId.Text + "',VideoKatId='" + drpVideoKat.SelectedValue + "',VideoAdi='" + txtVideoAltKatAd.Text + "',VideoLink='" + txtVideoLink.Text + "' Where SanalVideoAltKatId='" + Request.QueryString["Duzenle"] + "' ");
                        Response.Redirect(Link + "?Durum=Guncelle");
                    }
                    //db.execute("Update tblAltKat Set   AltKatId='" + txtAltKatId.Text + "' ,KatId='" + drpKat.SelectedValue + "' , AltKatAdi='" + txtAltKatAd.Text + "', AltKatIcerik='" + CKicerik.Text + "' Where AltSanalId='" + Request.QueryString["Duzenle"] + "'");
                    //Response.Redirect(Link + "?Durum=Guncelle");
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
            lblHata.Text = msj.alanBos(Baslik + " Kategori");
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            pnlKontrol.Visible = false;
        }

    }
}