using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;


public partial class KayitOl : System.Web.UI.Page
{
    dbislem db = new dbislem();
    mesajislemleri msj = new mesajislemleri();
    resimislemleri Resim = new resimislemleri();

   string ResimYolu="";
   string Cinsiyet = "";
   string Baslik = "KayıtOl";
   string Link = "KayitOl.aspx";

   protected void Page_Load(object sender, EventArgs e)
   {
       if (Session["Title"] == null)
           Response.Redirect("Default.aspx");

       Page.Title = Baslik + Session["Title"].ToString();


       if (!Page.IsPostBack)
       {
           
          ilListele();

       }
       

   }

   private void ilListele()
   {
       DataTable dt = db.GetDataTable("Select * From tbliller ORDER BY ilAdi ASC ");
       Drpil.DataTextField = "ilAdi";
       Drpil.DataValueField = "ilId";
       Drpil.DataSource = dt;
       Drpil.DataBind();
       Drpil.Items.Insert(0,new ListItem("il Seçiniz..","0"));
       

   }

   private void ilceListele()
   {
       DataTable dt = db.GetDataTable("Select * From tblilceler where ilId='" + Drpil.SelectedValue + "' ORDER BY ilceAdi ASC ");
       Drpilce.DataTextField = "ilceAdi";
       Drpilce.DataValueField = "ilceId";
       Drpilce.DataSource = dt;
       Drpilce.DataBind();
       //Drpilce.Items.Insert(0, new ListItem("ilce Seçiniz..", "0"));


   }


   protected void Drpil_SelectedIndexChanged(object sender, EventArgs e)
   {
       ilceListele();
   }
   protected void BtnKaydet_Click(object sender, EventArgs e)
   {
       
       

       if (rdbtnBay.Checked)
           Cinsiyet = "Bay";
       else
           Cinsiyet = "Bayan";


       if (Drpil.SelectedValue != "0")
       {
           pnlHata.Visible = false;

           if (txtAdSoyad.Text != "")
           {
               pnlHata.Visible = false;

               if (txtMail.Text != "")
               {
                   pnlHata.Visible = false;

                   if (txtSifre.Text != "")
                   {
                       pnlHata.Visible = false;

                       if (txtSifreTekrar.Text != "")
                       {
                           pnlHata.Visible = false;

                           if (txtSifre.Text == txtSifreTekrar.Text)
                           {
                               pnlHata.Visible = false;

                               DataRow drMail = db.GetDataRow("Select * From tblKullanici Where Mail='"+txtMail.Text+"'");

                               if (drMail==null)
                               {
                                   if (fluResim.HasFile)
                                   {
                                       ResimYolu = Resim.resimKaydet(fluResim.PostedFile, "Profil", 250, 200);


                                       db.execute("Insert Into tblKullanici(Sifre,AdSoyad,Mail,Cinsiyet,DTarih,ilId,ilceId,ResimYolu,Onay,Engel,KTarih)" +
                           " Values('" + txtSifre.Text + "','" + txtAdSoyad.Text + "','" + txtMail.Text + "','" + Cinsiyet + "','" + txtDTarih.Text + "','" + Drpil.SelectedValue + "','" + Drpilce.SelectedValue + "','" + ResimYolu + "','" + 1 + "','" + 0 + "','" + DateTime.Now.ToString() + "'  )");

                                       pnlHata.Visible = false;
                                       pnlBasarili.Visible = true;
                                       lblBasarili.Text = "Üyeliğiniz Tamamlanmıştır...Giriş Yapabilirsiniz...";

                                   }
                                   else
                                   {
                                       lblHata.Text = msj.alanBos(" Profil Resmi ");
                                       pnlHata.Visible = true;
                                       pnlBasarili.Visible = false;
                                       pnlKontrol.Visible = false;
                                   }

                               }
                               else
                               {
                                   lblHata.Text = msj.Kontrol(" Mail Adresi");
                                   pnlHata.Visible = true;
                                   pnlBasarili.Visible = false;
                                   pnlKontrol.Visible = false;
                               }


                           }
                           else
                           {
                               lblHata.Text = msj.hataliSifre(" ");
                               pnlHata.Visible = true;
                               pnlBasarili.Visible = false;
                               pnlKontrol.Visible = false;
                           }


                       }
                       else
                       {
                           lblHata.Text = msj.alanBos(" Şifre Tekrar ");
                           pnlHata.Visible = true;
                           pnlBasarili.Visible = false;
                           pnlKontrol.Visible = false;
                       }
                   }
                   else
                   {
                       lblHata.Text = msj.alanBos(" Şifre ");
                       pnlHata.Visible = true;
                       pnlBasarili.Visible = false;
                       pnlKontrol.Visible = false;
                   }


               }
               else
               {
                   lblHata.Text = msj.alanBos(" e-mail Adresi ");
                   pnlHata.Visible = true;
                   pnlBasarili.Visible = false;
                   pnlKontrol.Visible = false;
               }

           }
           else
           {
               lblHata.Text = msj.alanBos(" Ad Soyad ");
               pnlHata.Visible = true;
               pnlBasarili.Visible = false;
               pnlKontrol.Visible = false;
           }


       }
       else
       {
           lblHata.Text = msj.alanBos(" il ");
           pnlHata.Visible = true;
           pnlBasarili.Visible = false;
           pnlKontrol.Visible = false;
       }



   }
   
}
