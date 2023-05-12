using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Yonetim : System.Web.UI.MasterPage
{
    dbislem db = new dbislem();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["YoneticiAdi"] != null && Session["YoneticiId"] != null)
        {
            ltrYonetici.Text = Session["YoneticiAdi"].ToString();

            TumMesajlarListele();
            OkunmamisMesajlarListele();
            OkunmusMesajlarListele();


        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private void OkunmusMesajlarListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblMesajlar Where Onay=1");

        if (dt.Rows.Count > 0)
        {
            lblOkunmusMesajlar.Text = " (" + dt.Rows.Count.ToString() + ")";
        }
    }

    private void OkunmamisMesajlarListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblMesajlar Where Onay=0");

        if (dt.Rows.Count > 0)
        {
            lblOkunmamisMesajlar.Text = " (" + dt.Rows.Count.ToString() + ")";
        }
    }

    private void TumMesajlarListele()
    {
        DataTable dt = db.GetDataTable("Select * From tblMesajlar");

        if (dt.Rows.Count>0)
        {
            lblTumMesajlar.Text = " (" + dt.Rows.Count.ToString() + ")";
        }
      

    }
    protected void btnSingOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("SingOut.aspx");
    }
    protected void btnTumMesajlar_Click(object sender, EventArgs e)
    {
        Response.Redirect("TumMesajlar.aspx");
    }
    protected void btnOkunmamis_Click(object sender, EventArgs e)
    {
        Response.Redirect("OkunmamisMesajlar.aspx");
    }
    protected void btnOkunmus_Click(object sender, EventArgs e)
    {
        Response.Redirect("OkunmusMesajlar.aspx");
    }
}
