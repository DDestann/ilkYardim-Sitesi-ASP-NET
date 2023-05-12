using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Net.Mail;
using System.Net;


public partial class Unuttum : System.Web.UI.Page
{
    dbislem db = new dbislem();



    string Baslik = "Şifremi Unuttum ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        Page.Title = Baslik + Session["Title"].ToString();

    }


    protected void BtnGonder_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow drAyar = db.GetDataRow("Select * From tblAyarlar Where AyarId=1");


        DataRow dr = db.GetDataRow("Select * From tblKullanici Where Mail='" + txtMail.Text + "'");

        if (dr != null)
        {
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.To.Add(txtMail.Text);
            msg.From = new MailAddress(drAyar["Mail"].ToString(), drAyar["Site"].ToString(), System.Text.Encoding.UTF8);

            msg.Subject = "Kullanıcı Bilgileri Maili";
            msg.Body = "Şifreniz: " + dr["Sifre"].ToString() + "";
            SmtpClient smp = new SmtpClient("");
            smp.Credentials = new NetworkCredential(drAyar["Mail"].ToString(), drAyar["Sifre"].ToString());
            smp.Port = 587;
            
            smp.Host = drAyar["Host"].ToString();
            smp.EnableSsl = true;
            smp.Send(msg);

            pnlHata.Visible = false;
            pnlBasarili.Visible = true;
            lblBasarili.Text = "Kullanıcı Bilgileriniz Mail Adresinize Gönderilmiştir";

            //Response.Write("<script>alert('Kullanıcı Bilgileriniz Mail Adresinize Gönderilmiştir...')</script>");

        }
        else
        {
            //Response.Write("<script>alert('Girmiş Olduğunuz Mail Adresi Bulunmamaktadır...')</script>");

            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            lblHata.Text = "Girmiş Olduğunuz Mail Adresi Bulunmamaktadır...";

        }
        }
        catch (Exception)
        {
            
            pnlHata.Visible = true;
            pnlBasarili.Visible = false;
            lblHata.Text = "Bir Hata ile Karşılaştı Lüfen tekrar deneyin";
        }
    }
}