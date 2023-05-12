using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    dbislem db = new dbislem();

    protected void Page_Load(object sender, EventArgs e)
    {
        ///////////////////////

        DataTable dtKat = db.GetDataTable("SELECT * From tblKat");

        if (dtKat != null && dtKat.Rows.Count > 0)
        {
            lblKategori.Text = dtKat.Rows.Count.ToString();
        }
        else
        {
            lblKategori.Text = "-";
        }

        /////////////////////////////////


        DataTable dtAltKat = db.GetDataTable("SELECT * From tblAltKat");

        if (dtAltKat != null && dtAltKat.Rows.Count > 0)
        {
            lblAltKategori.Text = dtAltKat.Rows.Count.ToString();
        }
        else
        {
            lblAltKategori.Text = "-";
        }


        /////////////////////////////////


        DataTable dtVideoKat = db.GetDataTable("SELECT * From tblVideoKat");

        if (dtVideoKat != null && dtVideoKat.Rows.Count > 0)
        {
            lblVideoKat.Text = dtVideoKat.Rows.Count.ToString();
        }
        else
        {
            lblVideoKat.Text = "-";
        }


        /////////////////////////////////


        DataTable dtVideoAltKat = db.GetDataTable("SELECT * From tblVideoAltKat");

        if (dtVideoAltKat != null && dtVideoAltKat.Rows.Count > 0)
        {
            lblVideoAltKat.Text = dtVideoAltKat.Rows.Count.ToString();
        }
        else
        {
            lblVideoAltKat.Text = "-";
        }


        /////////////////////////////////


        DataTable dtTest = db.GetDataTable("SELECT * From tblTest");

        if (dtTest != null && dtTest.Rows.Count > 0)
        {
            lblTest.Text = dtTest.Rows.Count.ToString();
        }
        else
        {
            lblTest.Text = "-";
        }


        /////////////////////////////////


        DataTable dtSoru = db.GetDataTable("SELECT * From tblSoru");

        if (dtSoru != null && dtSoru.Rows.Count > 0)
        {
            lblSoru.Text = dtSoru.Rows.Count.ToString();
        }
        else
        {
            lblSoru.Text = "-";
        }


        /////////////////////////////////


        DataTable dtBanner = db.GetDataTable("SELECT * From tblBanner");

        if (dtBanner != null && dtBanner.Rows.Count > 0)
        {
            lblBanner.Text = dtBanner.Rows.Count.ToString();
        }
        else
        {
            lblBanner.Text = "-";
        }

        /////////////////////////////////


        DataTable dtGaleri = db.GetDataTable("SELECT * From tblGaleri");

        if (dtGaleri != null && dtGaleri.Rows.Count > 0)
        {
            lblGaleri.Text = dtGaleri.Rows.Count.ToString();
        }
        else
        {
            lblGaleri.Text = "-";
        }

        /////////////////////////////////


        DataTable dtAnaResim = db.GetDataTable("SELECT * From tblAnaResim");

        if (dtAnaResim != null && dtAnaResim.Rows.Count > 0)
        {
            lblAnaResim.Text = dtAnaResim.Rows.Count.ToString();
        }
        else
        {
            lblAnaResim.Text = "-";
        }

        /////////////////////////////////


        DataTable dtDuyuru = db.GetDataTable("SELECT * From tblDuyuru");

        if (dtDuyuru != null && dtDuyuru.Rows.Count > 0)
        {
            lblDuyuru.Text = dtDuyuru.Rows.Count.ToString();
        }
        else
        {
            lblDuyuru.Text = "-";
        }


        /////////////////////////////////


        DataTable dtKullanici = db.GetDataTable("SELECT * From tblKullanici");

        if (dtKullanici != null && dtKullanici.Rows.Count > 0)
        {
            lblKullanici.Text = dtKullanici.Rows.Count.ToString();
        }
        else
        {
            lblKullanici.Text = "-";
        }


        /////////////////////////////////


        DataTable dtYonetim = db.GetDataTable("SELECT * From tblYonetim");

        if (dtYonetim != null && dtYonetim.Rows.Count > 0)
        {
            lblYonetici.Text = dtYonetim.Rows.Count.ToString();
        }
        else
        {
            lblYonetici.Text = "-";
        } 


    }
}