using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text.RegularExpressions;

public partial class AnaSayfaicerik : System.Web.UI.Page
{


    string Baslik = "AnaSayfaicerik";
    string Link = "AnaSayfaicerik.aspx";



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
                DataRow drDuzenle = db.GetDataRow("Select * From tblAnaicerik where AnaicerikId='" + Request.QueryString["Duzenle"] + "'");
                txtBaslik.Text = drDuzenle["Baslik"].ToString();
                txticerik.Text = drDuzenle["icerik"].ToString();
              

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblAnaicerik Where AnaicerikId='" + Request.QueryString["Sil"] + "'");
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


        DataTable dt = db.GetDataTable("Select * From tblAnaicerik ORDER BY AnaicerikId DESC");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

            if (btnKaydet.Text == "Kaydet")
            {

                db.execute(" INSERT INTO tblAnaicerik(Baslik,icerik) Values( '" + txtBaslik.Text + "','" + txticerik.Text + "'  )");
                        Response.Redirect(Link + "?Durum=Kaydet");
                
            }
            else if (btnKaydet.Text == "Güncelle")
            {
                db.execute("Update tblAnaicerik Set  Baslik='" + txtBaslik.Text + "' , icerik='" + txticerik.Text + "'  Where AnaicerikId='" + Request.QueryString["Duzenle"] + "'");
                Response.Redirect(Link + "?Durum=Guncelle");
            }

    }

    public string metin_kisalt_yan(string metin)
    {

        metin = Regex.Replace(metin, @"<(.\n)*?>", string.Empty);

        if (metin.Length > 250) metin = metin.Substring(0, 250);

        metin = metin + "...";

        return metin;

    } 


}