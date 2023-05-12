using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Soru : System.Web.UI.Page
{


    string Baslik = "Soru";
    string Link = "Soru.aspx";



    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();

    string Cevap = "";

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
                DataRow drDuzenle = db.GetDataRow("SELECT  tblSoru.*,  tblTest.* FROM    tblSoru INNER JOIN "+
                         " tblTest ON  tblSoru.TestId =  tblTest.TestId where  tblSoru.SanalSoruId='" + Request.QueryString["Duzenle"] + "'");
                drpKonu.SelectedValue = drDuzenle["TestId"].ToString();
                txtSoruId.Text = drDuzenle["SoruId"].ToString();
                txtSoru.Text = drDuzenle["Soru"].ToString();
                txtA.Text = drDuzenle["A"].ToString();
                txtB.Text = drDuzenle["B"].ToString();
                txtC.Text = drDuzenle["C"].ToString();
                txtD.Text = drDuzenle["D"].ToString();

                if (drDuzenle["Cevap"].ToString()=="A")
                    rdbA.Checked = true;
                else if (drDuzenle["Cevap"].ToString() == "B")
                    rdbB.Checked = true;
                else if (drDuzenle["Cevap"].ToString() == "C")
                    rdbC.Checked = true;
                else if (drDuzenle["Cevap"].ToString() == "D")
                    rdbD.Checked = true;


                txtSoruId.Enabled = false;

                lblBaslik.Text = Baslik + " Güncelle";

                btnKaydet.Text = "Güncelle";
            }

            if (Request.QueryString["Sil"] != null && Request.QueryString["Sil"].ToString() != "")
            {
                db.execute("Delete From tblSoru Where SanalSoruId='" + Request.QueryString["Sil"] + "'");
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
        DataTable dtKat = db.GetDataTable("Select * From tblTest");
        drpKonu.DataTextField = "TestAdi";
        drpKonu.DataValueField = "TestId";
        drpKonu.DataSource = dtKat;
        drpKonu.DataBind();
        drpKonu.Items.Insert(0, new ListItem("Konu Seçiniz...", "0"));
    }

    private void Listele()
    {


        DataTable dt = db.GetDataTable("SELECT  tblSoru.*,  tblTest.* FROM    tblSoru INNER JOIN " +
                         " tblTest ON  tblSoru.TestId =  tblTest.TestId ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = Dtlist;
        Dtlist.DataSource = Sayfalama.DataSourcePaged;
        Dtlist.DataBind();
     
    }


    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        if (drpKonu.SelectedValue != "0")
        {
            if (drpKonu.SelectedValue != "0" && txtSoru.Text != "" && txtSoruId.Text != "" && txtA.Text != "" && txtB.Text != "" && txtC.Text != "" && txtD.Text != "")
            {
                if (btnKaydet.Text == "Kaydet")
                {
                    if (rdbA.Checked)
                        Cevap ="A";
                    else if (rdbB.Checked)
                        Cevap ="B";
                    else if (rdbC.Checked)
                        Cevap ="C";
                    else if (rdbD.Checked)
                        Cevap ="D";

                    db.execute(" INSERT INTO tblSoru(SoruId,TestId,Soru,A,B,C,D,Cevap) Values('" + txtSoruId.Text + "' ,'" + drpKonu.SelectedValue + "','" + txtSoru.Text + "','" + txtA.Text + "','" + txtB.Text + "','" + txtC.Text + "','" + txtD.Text + "','" + Cevap + "'    )");
                            Response.Redirect(Link + "?Durum=Kaydet");
                        
                    
                }
                else if (btnKaydet.Text == "Güncelle")
                {
                    if (rdbA.Checked)
                        Cevap = "A";
                    else if (rdbB.Checked)
                        Cevap = "B";
                    else if (rdbC.Checked)
                        Cevap = "C";
                    else if (rdbD.Checked)
                        Cevap = "D";



                    db.execute("Update tblSoru Set   SoruId='" + txtSoruId.Text + "' ,TestId='" + drpKonu.SelectedValue + "' , Soru='" + txtSoru.Text + "', A='" + txtA.Text + "', B='" + txtB.Text + "', C='" + txtC.Text + "', D='" + txtD.Text + "', Cevap='" + Cevap + "' Where SanalSoruId='" + Request.QueryString["Duzenle"] + "'");
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