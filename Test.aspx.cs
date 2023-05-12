using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
public partial class Test : System.Web.UI.Page
{
    dbislem db = new dbislem();

    string Baslik = "";

    int Dogru = 0;
    int Yanlis = 0;
    //int Secilen_No = 0;
    string Secilen_No = "";
    int count = 0;

   


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Title"] == null)
            Response.Redirect("Default.aspx");

        Page.Title = "Test " + Session["Title"].ToString();
        Page.MetaKeywords = "Test";

      if (!Page.IsPostBack)
      {
          if (Session["KullaniciId"] != "" && Session["KullaniciId"] != null)
          {
              BaslikListele();
              SoruLitele();
          }
          else
          {
              Response.Redirect("KulGiris.aspx");
          }
      }
     
    }


    private void SoruLitele()
    {
        if (Request.QueryString["TestId"] != null && Request.QueryString["TestId"].ToString() != "")
        {
            DataTable Soru = db.GetDataTable("SELECT * FROM tblSoru Where TestId='" + Request.QueryString["TestId"] + "' ORDER BY RAND() LIMIT 20 ");
            GridView1.DataSource = Soru;
            GridView1.DataBind();
           
        }
        else
        {
            Response.Redirect("Default.aspx");
        } 
    }

    private void BaslikListele()
    {
        if (Request.QueryString["TestId"] != null && Request.QueryString["TestId"].ToString() != "")
        {
            DataRow dr = db.GetDataRow("SELECT * FROM tblTest Where TestId=" + Request.QueryString["TestId"]);
            lblBaslik.Text = dr["TestAdi"].ToString();
        }
        
    }



    protected void btnCevap_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow Soru in GridView1.Rows)
        {
            Label lblSoruId = Soru.FindControl("lblSoruId") as Label;
            Label lblcvp = Soru.FindControl("lblcvp") as Label;
            RadioButton Soru1A = Soru.FindControl("Soru1A") as RadioButton;
            RadioButton Soru1B = Soru.FindControl("Soru1B") as RadioButton;
            RadioButton Soru1C = Soru.FindControl("Soru1C") as RadioButton;
            RadioButton Soru1D = Soru.FindControl("Soru1D") as RadioButton;
            Panel pnlCevap = Soru.FindControl("pnlCevap") as Panel;
            #region Soru1

            if (Soru1A.Checked)
            {
                //Secilen_No = 1;
                Secilen_No = "A";

            }
            else if (Soru1B.Checked)
            {
                //Secilen_No = 2;
                Secilen_No = "B";


            }
            else if (Soru1C.Checked)
            {
                // Secilen_No = 3;
                Secilen_No = "C";



            }
            else if (Soru1D.Checked)
            {
                //Secilen_No = 4;
                Secilen_No = "D";

            }

           
            Soru_No(lblSoruId.Text);

            #endregion

            pnlCevap.Visible = true;
        }
        lblDogru.Text = "Doğru Sayısı=" + Dogru.ToString();
        lblYanlis.Text = "Yanış Sayısı=" + Yanlis.ToString();
       
    }

    private void Soru_No(string text)
    {
        MySqlConnection con = new MySqlConnection(Session["Vt"].ToString());
        MySqlCommand cmd = new MySqlCommand("Select * From tblSoru Where SoruId=@SoruId" + count, con);
        cmd.Parameters.AddWithValue("@SoruId" + count, text);
        con.Open();
        MySqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (Secilen_No == dr["Cevap"].ToString())
            {
               // Yanlis = Yanlis + 1;
                Dogru = Dogru + 1;

            }
            else
            {
                //Dogru = Dogru + 1;
                Yanlis = Yanlis + 1;
            }
        }
        con.Close();
        count++;

    }

}