<%@ Application Language="C#" %>

<script runat="server">

    //void Application_BeginRequest(object sender, EventArgs e)
    //{
    //    string Adres = Request.RawUrl;//Önce Adresi alıyoruz(www.aaa.com/Defaut.aspx?Id=1&baslık=Kat1)
    //    if (System.IO.Path.GetExtension(Adres)== ".aspx")//Adres Uzantısı  
    //    {
    //        string[] Parcalar = System.IO.Path.GetFileName(Adres).Split('-');//Dizi Halinde Dosya ismini alarak split ile adres Adını parçalıyoruz
    //        Context.RewritePath("~/Default2.aspx", "", "KategoriAdi=" + Parcalar[0] + "&Id=" + Parcalar[1], true);  
    //    }
        

    //}

    void Application_BeginRequest(Object sender, EventArgs e)
    {
        string DosyaYolu = Request.RawUrl;

        if (DosyaYolu.IndexOf("/Detay-") != -1)
        {
            if (System.IO.Path.GetExtension(DosyaYolu) == ".aspx")
            {
                string[] path = System.IO.Path.GetFileName(DosyaYolu).Split('-');
                Context.RewritePath("Detay.aspx", "", "Id=" + path[1], true);
            }
        }
        else if (DosyaYolu.IndexOf("/Duyuru-") != -1)
        {
            if (System.IO.Path.GetExtension(DosyaYolu) == ".aspx")
            {
                string[] path = System.IO.Path.GetFileName(DosyaYolu).Split('-');
                Context.RewritePath("Detay.aspx", "", "DuyuruId=" + path[1], true);
            }
        }

        else if (DosyaYolu.IndexOf("/Test-") != -1)
        {
            if (System.IO.Path.GetExtension(DosyaYolu) == ".aspx")
            {
                string[] path = System.IO.Path.GetFileName(DosyaYolu).Split('-');
                Context.RewritePath("Test.aspx", "", "TestId=" + path[1], true);
            }
        }

        else if (DosyaYolu.IndexOf("/Video-") != -1)
        {
            if (System.IO.Path.GetExtension(DosyaYolu) == ".aspx")
            {
                string[] path = System.IO.Path.GetFileName(DosyaYolu).Split('-');
                Context.RewritePath("Video.aspx", "", "VideoId=" + path[1], true);
            }
        }
        
    }

   


    void Application_Start(object sender, EventArgs e) 
    {
       

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
       // Session["Vt"] = @"Data Source=DESTAN\SQLEXPRESS;Initial Catalog=istanbulilkyardim.com;Integrated Security=True";

        //Session["Vt"] = "Server=94.73.170.250;Database=db3203297295;Uid=user3203297295; Password=L+l+L+l6248810; Integrateg Security=false;";
        Session["vt"] = ("Server=94.73.170.250;Database=ilkyardim;Uid=ilkyardim;Pwd=L+l+L+l6248810;Integrated Security=False;");
        
        
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
