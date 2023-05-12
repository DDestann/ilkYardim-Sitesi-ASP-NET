using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;


public partial class KulGiris : System.Web.UI.Page
{
    dbislem db = new dbislem();



    string Baslik = "Kullanıcı Girişi";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        Page.Title = Baslik + Session["Title"].ToString();

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


        //if (Session["KullaniciId"] != null)
        //{

        //    pnlKullanici.Visible = true;
        //    ltrKullanici.Text = Session["AdSoyad"].ToString();
        //    ImageProfil.ImageUrl = "../images/yuklenen/Profil/kucuk/" + Session["ResimYolu"].ToString();
        //}
        //else
        //{

        //    pnlKullanici.Visible = false;
        //}
        


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
                    Session["Engel"] = dr["Engel"].ToString();

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

                    Response.Redirect("Profil.aspx");






                }
                else
                {
                    //Response.Write("<script>alert('Mail Adresi veya Sifre Hatalı')</script>");
                    pnlHata.Visible = true;
                    lblHata.Text = "Mail Adresi veya Sifre Hatalı";
                }
            }

            else
            {
                //Response.Write("<script>alert('Bu Mail Adresi Sistemde Kayıtlı Değil...')</script>");
                pnlHata.Visible = true;
                lblHata.Text = "Bu Mail Adresi Engellenmiştir...";

            }


        }
        else
        {
            //Response.Write("<script>alert('Bu Mail Adresi Sistemde Kayıtlı Değil...')</script>");
            pnlHata.Visible = true;
            lblHata.Text = "Bu Mail Adresi Sistemde Kayıtlı Değil..";

        }
    }
}