using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Test : System.Web.UI.Page
{


    string Baslik = "Test";
    string Link = "Test.aspx";



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
                DataRow drDuzenle = db.GetDataRow("Select * From tblTest where SanalTestId='" + Request.QueryString["Duzenle"] + "'");
                txtTestAd.Text = drDuzenle["TestAdi"].ToString();
                txtTestId.Text = drDuzenle["TestId"].ToString();
                txtTestId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblTest Where SanalTestId='" + Request.QueryString["Sil"] + "'");
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


        DataTable dt = db.GetDataTable("Select * From tblTest ORDER BY SanalTestId DESC");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (txtTestAd.Text != "" && txtTestId.Text != "")
        {
            if (btnKaydet.Text == "Kaydet")
            {
                DataTable dtKontrol = db.GetDataTable("Select * From tblTest where TestAdi='" + txtTestAd.Text + "' ");
                if (dtKontrol.Rows.Count==0)
                {
                    DataTable dtKontrol1 = db.GetDataTable("Select * From tblTest where TestId='" + txtTestId.Text + "' ");
                    if (dtKontrol1.Rows.Count == 0)
                    {
                        db.execute(" INSERT INTO tblTest(TestId,TestAdi) Values( '" + txtTestId.Text + "','" + txtTestAd.Text + "')");
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
                db.execute("Update tblTest Set  TestId='" + txtTestId.Text + "' , TestAdi='" + txtTestAd.Text + "' Where SanalTestId='" + Request.QueryString["Duzenle"] + "'");
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