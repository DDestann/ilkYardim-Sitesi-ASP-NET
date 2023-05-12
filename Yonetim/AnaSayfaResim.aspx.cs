using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;

public partial class AnaSayfaResim : System.Web.UI.Page
{


    string Baslik = "AnaSayfaResim";
    string Link = "AnaSayfaResim.aspx";
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
                DataRow drDuzenle = db.GetDataRow("Select * From tblAnaResim where AnaResimId='" + Request.QueryString["Duzenle"] + "'");
                txtBannerAd.Text = drDuzenle["ResimAdi"].ToString();
                ImageEskiResim.ImageUrl = Resim.resimGetirPanel("AnaResim", "kucuk") + drDuzenle["ResimYolu"].ToString();
                pnlEskiResim.Visible = true;
                
                

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {

                DataRow drResim = db.GetDataRow("Select ResimYolu From tblAnaResim where AnaResimId='" + Request.QueryString["Sil"] + "'");
                SilinecekResim = drResim["ResimYolu"].ToString();

                FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel("AnaResim", "buyuk")) + SilinecekResim);
                fi.Delete();

                FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("AnaResim", "kucuk")) + SilinecekResim);
                fi2.Delete();

                FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("AnaResim", "orjinal")) + SilinecekResim);
                fi3.Delete();

                db.execute("Delete From tblAnaResim Where AnaResimId='" + Request.QueryString["Sil"] + "'");
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
        DataTable dt = db.GetDataTable("Select * From tblAnaResim");
       
        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();


    }

  
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (txtBannerAd.Text != "")
        {
            if (btnKaydet.Text == "Kaydet")
            {

                DataTable dtKontrol1 = db.GetDataTable("Select * From tblAnaResim where ResimAdi='" + txtBannerAd.Text + "' ");
                    if (dtKontrol1.Rows.Count == 0)
                    {
                        if (fluResim.HasFile)
                        {
                            ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "AnaResim", 930, 200);

                            db.execute(" INSERT INTO tblAnaResim(ResimAdi,ResimYolu) Values( '" + txtBannerAd.Text + "', '" + ResimYolu + "')");
                            Response.Redirect(Link + "?Durum=Kaydet");

                        }
                        else
                        {
                            lblHata.Text = msj.alanBos(Baslik+" Resmi");
                            pnlHata.Visible = true;
                            pnlBasarili.Visible = false;
                            pnlKontrol.Visible = false;
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
                    DataRow drResim = db.GetDataRow("Select  ResimYolu From tblAnaResim where AnaResimId='" + Request.QueryString["Duzenle"] + "'");
                    SilinecekResim=drResim["ResimYolu"].ToString();

                    FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel("AnaResim", "buyuk")) + SilinecekResim);
                    fi.Delete();

                    FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("AnaResim", "kucuk")) + SilinecekResim);
                    fi2.Delete();

                    FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("AnaResim", "orjinal")) + SilinecekResim);
                    fi3.Delete();


                    ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "AnaResim", 500, 200);

                    db.execute(" UPDATE tblAnaResim Set  ResimAdi='" + txtBannerAd.Text + "' ,  ResimYolu='" + ResimYolu + "' where AnaResimId='" + Request.QueryString["Duzenle"] + "'");
                    Response.Redirect(Link + "?Durum=Guncelle");

                }
                else
                {
                    db.execute(" UPDATE tblAnaResim Set  ResimAdi='" + txtBannerAd.Text + "' where  AnaResimId='" + Request.QueryString["Duzenle"] + "' ");
                    Response.Redirect(Link + "?Durum=Guncelle");
                }
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