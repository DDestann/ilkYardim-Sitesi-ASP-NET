using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form : System.Web.UI.Page
{
    dbislem db = new dbislem();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");


        Page.Title = "Form " + Session["Title"].ToString();

        Listele();
    }

    private void Listele()
    {
        DataTable dt = db.GetDataTable("Select * From tblMesajlar Where Onay=1 ORDER BY MsjId DESC ");

        Sayfalama.DataSource = dt.DefaultView;
        Sayfalama.BindToControl = DtList;
        DtList.DataSource = Sayfalama.DataSourcePaged;
        DtList.DataBind();
    }



    protected void btnMsjGonder_Click(object sender, EventArgs e)
    {
        if (txtKullaniciAdi.Text != "")
        {
            if (txtMail.Text != "")
            {
                if (txtKonu.Text != "")
                {
                    if ( txtMsj.Text != "")
                    {
                        db.execute("Insert Into tblMesajlar(KullaniciAdi,Mail,Konu,Mesaj,GTarih,Onay) Values('" + txtKullaniciAdi.Text + "','" + txtMail.Text + "','" + txtKonu.Text + "','" + txtMsj.Text + "','" + DateTime.Now.ToString() + "' ,'" + "0" + "' )");
                        lblBasarili.Text = "Mesajınız Admin Onayına Başarıyla Gönderilmiştir...";
                        pnlBasarili.Visible = true;
                        pnlHata.Visible = false;

                        txtMsj.Text = "";
                        txtKonu.Text = "";

                    }
                    else
                    {
                        lblHata.Text = "Mesaj Göndermek için Mesaj Alanını Boş Bırakmayınız";
                        pnlBasarili.Visible = false;
                        pnlHata.Visible = true;

                    }
                }
                else
                {
                    lblHata.Text = "Mesaj Göndermek için Konu Alanını Boş Bırakmayınız";
                    pnlBasarili.Visible = false;
                    pnlHata.Visible = true;
                }
            }
            else
            {
                lblHata.Text = "Mesaj Göndermek için EMail Alanını Boş Bırakmayınız";
                pnlBasarili.Visible = false;
                pnlHata.Visible = true;
            }
        }
        else
        {
            lblHata.Text = "Mesaj Göndermek için Rumuz Alanını Boş Bırakmayınız";
            pnlBasarili.Visible = false;
            pnlHata.Visible = true;
        }


    }
}