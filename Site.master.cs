using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{

    dbislem db = new dbislem();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = 0;
        Response.Cache.SetNoStore();
        Response.AppendHeader("Pragma", "no-cache");



        if (Request.Cookies["Cerezim"] != null)
        {
            HttpCookie yakalacerez = Request.Cookies["Cerezim"];
            Session["KullaniciId"] = yakalacerez.Values["KullaniciId"];
            Session["AdSoyad"] = yakalacerez.Values["AdSoyad"];
            Session["ResimYolu"] = yakalacerez.Values["ResimYolu"];
            Session["Mail"] = yakalacerez.Values["Mail"];
           
        }


        if (Session["KullaniciId"] != null && Session["Engel"] != "1")
        {

            pnlKullanici.Visible = true;
            ltrKullanici.Text = Session["AdSoyad"].ToString();
            ImageProfil.ImageUrl = "../images/yuklenen/Profil/kucuk/" + Session["ResimYolu"].ToString();
        }
        else
        {
            
            pnlKullanici.Visible = false;
        }

        MenuListele();
        Sosyal();
        TestListele();
        VideoListele();

        DataRow drAyarlar = db.GetDataRow("Select * From tblAyarlar Where AyarId=1");

        if (drAyarlar != null)
        {
            ImageLogo.ImageUrl = "../images/yuklenen/Logo/buyuk/" + drAyarlar["Logo"].ToString();
            ImageLogo.AlternateText = drAyarlar["Site"].ToString();

            ImageLogo2.ImageUrl = "../images/yuklenen/Logo/buyuk/" + drAyarlar["Logo"].ToString();
            ImageLogo2.AlternateText = drAyarlar["Site"].ToString();

            lblAltHak.Text = drAyarlar["YasalHak"].ToString();

            Session["Key"] = drAyarlar["MetaKey"].ToString();
           //Session["Desc"] = drAyarlar["MetaDesc"].ToString();

           // Page.MetaKeywords = drAyarlar["MetaKey"].ToString();
            Page.MetaDescription = drAyarlar["MetaDesc"].ToString();


        }
    }

    private void Sosyal()
    {
        DataTable dt = db.GetDataTable("SELECT * FROM tblAyarlar ");

        Link.DataSource = dt;
        Link.DataBind();

        SosyalLink.DataSource = dt;
        SosyalLink.DataBind();

        rptFace.DataSource = dt;
        rptFace.DataBind();
    }


    private void MenuListele()
    {
        
        DataTable dt =db.GetDataTable("SELECT * FROM tblKat ");
           
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
    }

    private void TestListele()
    {
        //DataRow TestId = db.GetDataRow("Select * From tblTest");
        //Session["TestId"]=TestId["TestId"].ToString();

        DataTable dt = db.GetDataTable("SELECT * FROM tblTest ");

        rptTest.DataSource = dt;
        rptTest.DataBind();
    }

    private void VideoListele()
    {
        //DataRow TestId = db.GetDataRow("Select * From tblVideoKat");
        //Session["VideoKatId"] = TestId["VideoKatId"].ToString();

        DataTable dt = db.GetDataTable("SELECT * FROM tblVideoKat ");

        RptVideoKat.DataSource = dt;
        RptVideoKat.DataBind();

        rptVideo.DataSource = dt;
        rptVideo.DataBind();
    }

  


     protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       DataTable dt =db.GetDataTable ("SELECT * FROM tblAltKat where KatId="+ Convert.ToInt32(DataBinder.Eval(e.Item.DataItem,"KatId")));
        Repeater Repeater2 = (Repeater)e.Item.FindControl("Repeater2");
        Repeater2.DataSource = dt;
        Repeater2.DataBind();

        
    }

     public string urun(string ID, string baslik)
     {

         string git = db.linkYonlendir("Detay", ID, baslik);

         return git;
     }

     public string Test(string ID, string baslik)
     {

         string git = db.linkYonlendir("Test", ID, baslik);

         return git;
     }

     public string Video(string ID, string baslik)
     {

         string git = db.linkYonlendir("Video", ID, baslik);

         return git;
     }
    

    protected void BtnGiris_Click(object sender, EventArgs e)
    {
        DataRow drMail = db.GetDataRow("Select * From tblKullanici Where Mail='" + txtMail.Text + "' ");
        Session["Engel"] = drMail["Engel"].ToString();
        if (drMail != null)
        {
            if (Session["Engel"].ToString() != "1")
            {
                DataRow dr = db.GetDataRow("Select * From tblKullanici Where Sifre='" + txtSifre.Text + "' ");

                if (dr != null)
                {
                    Session["KullaniciId"] = dr["KullaniciId"].ToString();
                    Session["AdSoyad"] = dr["AdSoyad"].ToString();
                    Session["ResimYolu"] = dr["ResimYolu"].ToString();
                    Session["Mail"] = dr["Mail"].ToString();
                    //Session["Engel"] = dr["Engel"].ToString();


                    if (chHatirla.Checked)
                    {
                        HttpCookie cerez = new HttpCookie("Cerezim");
                        cerez.Values.Add("KullaniciId", dr["KullaniciId"].ToString());
                        cerez.Values.Add("AdSoyad", dr["AdSoyad"].ToString());
                        cerez.Values.Add("ResimYolu", dr["ResimYolu"].ToString());
                        cerez.Values.Add("Mail", dr["Mail"].ToString());

                        cerez.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(cerez);

                    }

                    Response.Redirect(Page.Request.Url.ToString(), true);

                }
                else
                {
                    Response.Write("<script>alert('Mail Adresi veya Sifre Hatalı')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Bu Mail Adresi Engellenmiştir...')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Bu Mail Adresi Sistemde Kayıtlı Değil...')</script>");
        }




    }
    protected void btnSingOut_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["Cerezim"] != null)
        {
            Response.Cookies["Cerezim"].Expires = DateTime.Now.AddDays(-1);
        }
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    protected void btnUnuttum_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow drAyar = db.GetDataRow("Select * From tblAyarlar Where AyarId=1");


            DataRow dr = db.GetDataRow("Select * From tblKullanici Where Mail='" + txtMailSifre.Text + "'");

            if (dr != null)
            {
                MailMessage msg = new MailMessage();
                msg.IsBodyHtml = true;
                msg.To.Add(txtMailSifre.Text);
                msg.From = new MailAddress(drAyar["Mail"].ToString(), drAyar["Site"].ToString(), System.Text.Encoding.UTF8);

                msg.Subject = "Kullanıcı Bilgileri Maili";
                msg.Body = "Şifreniz: " + dr["Sifre"].ToString() + "";
                SmtpClient smp = new SmtpClient("");
                smp.Credentials = new NetworkCredential(drAyar["Mail"].ToString(), drAyar["Sifre"].ToString());
                smp.Port = 587;

                smp.Host = drAyar["Host"].ToString();
                smp.EnableSsl = true;
                smp.Send(msg);

                Response.Write("<script>alert('Kullanıcı Bilgileriniz Mail Adresinize Gönderilmiştir...')</script>");

            }
            else
            {
               Response.Write("<script>alert('Girmiş Olduğunuz Mail Adresi Bulunmamaktadır...')</script>");


            }
        }
        catch (Exception)
        {

            Response.Write("<script>alert('Bir Hata ile Karşılaştı Lüfen tekrar deneyin...')</script>");
           
        }
    }
   

    
}
