﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;

public partial class Ayarlar : System.Web.UI.Page
{


    string Baslik = "Ayarlar";
    string Link = "Ayarlar.aspx";
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
                DataRow drDuzenle = db.GetDataRow("Select * From tblAyarlar where SanalId='" + Request.QueryString["Duzenle"] + "'");
                txtKey.Text = drDuzenle["MetaKey"].ToString();
                txtDesc.Text = drDuzenle["MetaDesc"].ToString();
                txtFlink.Text = drDuzenle["Facebook"].ToString();
                txtiLink.Text = drDuzenle["instegram"].ToString();
                txtYLİnk.Text = drDuzenle["Youtube"].ToString();
                txtGLink.Text = drDuzenle["GooglePlus"].ToString();
                txtMail.Text = drDuzenle["Mail"].ToString();
                txtSifre.Text = drDuzenle["Sifre"].ToString();
                txtSite.Text = drDuzenle["Site"].ToString();
                txtYasalHak.Text = drDuzenle["YasalHak"].ToString();
                txtHost.Text = drDuzenle["Host"].ToString();
                txtId.Text = drDuzenle["AyarId"].ToString();
                txtId.Enabled = false;

                ImageEskiResim.ImageUrl =Resim.resimGetirPanel("Logo","kucuk")+ drDuzenle["Logo"].ToString();
                pnlEskiResim.Visible = true;
                
                

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {

                DataRow drResim = db.GetDataRow("Select Logo From tblAyarlar where SanalId='" + Request.QueryString["Sil"] + "'");
                SilinecekResim = drResim["Logo"].ToString();

                FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Logo", "buyuk")) + SilinecekResim);
                fi.Delete();

                FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Logo", "kucuk")) + SilinecekResim);
                fi2.Delete();

                FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Logo", "orjinal")) + SilinecekResim);
                fi3.Delete();

                db.execute("Delete From tblAyarlar Where SanalId='" + Request.QueryString["Sil"] + "'");
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
        DataTable dt = db.GetDataTable("Select * From tblAyarlar");
       
        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();


    }

  
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (txtKey.Text != "")
        {
            if (txtDesc.Text != "")
            {
                if (btnKaydet.Text == "Kaydet")
                {
                    if (fluResim.HasFile)
                    {
                        ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "Logo", 475, 200);

                        db.execute(" INSERT INTO tblAyarlar(Site,Host,AyarId,MetaKey,MetaDesc,Facebook,instegram,Youtube,GooglePlus,Mail,Sifre,Logo,YasalHak) Values( '" + txtSite.Text + "','" + txtHost.Text + "','" + txtId.Text + "','" + txtKey.Text + "','" + txtDesc.Text + "','" + txtFlink.Text + "','" + txtiLink.Text + "','" + txtYLİnk.Text + "','" + txtGLink.Text + "','" + txtMail.Text + "','" + txtSifre.Text + "', '" + ResimYolu + "', '" + txtYasalHak.Text + "')");
                        Response.Redirect(Link + "?Durum=Kaydet");

                    }
                    else
                    {
                        lblHata.Text = msj.alanBos(Baslik + " Resmi");
                        pnlHata.Visible = true;
                        pnlBasarili.Visible = false;
                        pnlKontrol.Visible = false;
                    }

                }
                else if (btnKaydet.Text == "Güncelle")
                {
                    if (fluResim.HasFile)
                    {
                        DataRow drResim = db.GetDataRow("Select Logo From tblAyarlar where SanalId='" + Request.QueryString["Duzenle"] + "'");
                        SilinecekResim = drResim["Logo"].ToString();

                        FileInfo fi = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Logo", "buyuk")) + SilinecekResim);
                        fi.Delete();

                        FileInfo fi2 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Logo", "kucuk")) + SilinecekResim);
                        fi2.Delete();

                        FileInfo fi3 = new FileInfo(Server.MapPath(Resim.resimGetirPanel("Logo", "orjinal")) + SilinecekResim);
                        fi3.Delete();


                        ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "Logo", 475, 200);

                        db.execute(" UPDATE tblAyarlar Set    Site='" + txtSite.Text + "' , Host='" + txtHost.Text + "' , MetaKey='" + txtKey.Text + "' ,MetaDesc='" + txtDesc.Text + "' , Logo='" + ResimYolu + "', Facebook='" + txtFlink.Text + "' , instegram='" + txtiLink.Text + "' , Youtube='" + txtYLİnk.Text + "', GooglePlus ='" + txtGLink.Text + "', Mail='" + txtMail.Text + "', Sifre ='" + txtSifre.Text + "', YasalHak ='" + txtYasalHak.Text + "'    where SanalId='" + Request.QueryString["Duzenle"] + "'");
                        Response.Redirect(Link + "?Durum=Guncelle");

                    }
                    else
                    {
                        db.execute(" UPDATE tblAyarlar Set Site='" + txtSite.Text + "' , Host='" + txtHost.Text + "' , MetaKey='" + txtKey.Text + "' ,MetaDesc='" + txtDesc.Text + "', Facebook='" + txtFlink.Text + "' , instegram='" + txtiLink.Text + "' , Youtube='" + txtYLİnk.Text + "', GooglePlus ='" + txtGLink.Text + "', Mail='" + txtMail.Text + "', Sifre ='" + txtSifre.Text + "', YasalHak ='" + txtYasalHak.Text + "'  where SanalId='" + Request.QueryString["Duzenle"] + "'");
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
        else
        {
            lblHata.Text = msj.alanBos(Baslik);
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            pnlKontrol.Visible = false;
        }

    }
}