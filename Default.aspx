<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .Play:hover{
    opacity: 0.5;
    filter: alpha(opacity=50);
}
        .Left{float:left;}

         .img-kucuk { width:160px; height:120px;
        }

         .img-buyuk { width:400px; height:350px;
        }



    </style>




  <script type="text/javascript">
      jQuery(function () {
          jQuery("a.bla-1").YouTubePopUp();
          //jQuery("a.bla-2").YouTubePopUp({ autoplay: 0 }); // Disable autoplay
      });
	</script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Slayt" Runat="Server">

    <!-- Slider -->
  <div class="container hidden-xs">
    <div style="max-width:930px;">
    
    <!-- Insert to your webpage where you want to display the slider -->
    <div id="amazingslider-1" style="display:block;position:relative;margin:16px auto 56px;">

        <ul class="amazingslider-slides" style="display:none;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                     <li>
                         <img src='images/yuklenen/Banner/buyuk/<%#Eval("BannerYolu") %>' alt='<%#Eval("BannerAdi") %>' /></li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>
        
    </div>
    <!-- End of body section HTML codes -->
    
</div>
  </div>

    


  <!-- Slider-Sonu --> 
 
  <!-- Slider-image-Sonu --> 

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 

<!-- içerik Alanı -->

<div class="container-fluid padding-top-16">
  <div class="container padding-Sifir ">
    <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12 padding-Sifirsag">

        <div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
            <h5 style="font-weight:bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; "<asp:Label ID="Label2" runat="server" Text=""></asp:Label>Sitemize Hoş Geldiniz...</h5>
          </div>
<p></p>
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                
                <div class="col-md-6 col-sm-6 col-xs-12 bg-beyaz text-center bg-yuvar" align="center">
                <div class="panel panel-warning h200">
                    <div class="panel-heading "> <%#Eval("Baslik") %> </div>
                    <div class="panel-body"><%#Eval("icerik").ToString() %></div>
                </div>
                    <div class="Temizle"></div>
</div>
                
            </ItemTemplate>
        </asp:Repeater>


        <!------------------------->
 <!------------------------->
      


    </div>

  </div>
  <!---------->
  
     <!---------->

</div>
    
<!-- içerik Alanı-Sonu --> 


<!-- içerik Alanı Resim -->


<div class="container-fluid padding-top-16">

    <!-- içerik Alanı Büyük Resim -->
<!-- içerik Alanı Büyük Resim Sonu -->


  <div class="container padding-Sifir ">
    <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12 padding-Sifirsag">

        <div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
            <h5 style="font-weight:bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; "<asp:Label ID="Label22" runat="server" Text=""></asp:Label>Sertifikalrımız...</h5>
          </div>


        <asp:Repeater ID="Repeater5" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6 col-sm-6 col-xs-12 h360 text-center thumbnail bg-beyaz " align="center">
                        <img class="img-buyuk" src='images/yuklenen/AnaResim/buyuk/<%#Eval("ResimYolu") %>' alt='<%#Eval("ResimAdi") %>'/>
                    </div>
                            </ItemTemplate>
                </asp:Repeater>


        
        <div id="vlightbox1">

                <asp:Repeater ID="Repeater4" runat="server">
                    <ItemTemplate>
                        <div class="col-md-2 col-sm-2 col-xs-12 h100 text-center bg-yuvar" align="center">
                        <a class="vlightbox1" href='images/yuklenen/AnaResim/buyuk/<%#Eval("ResimYolu") %>' title='<%#Eval("ResimAdi") %>'><img class="img-kucuk" src='images/yuklenen/AnaResim/kucuk/<%#Eval("ResimYolu") %>' alt='<%#Eval("ResimAdi") %>'/></a>
                    </div>
                            </ItemTemplate>
                </asp:Repeater>
	</div>
         

        <!------------------------->
 <!------------------------->
      


    </div>

  </div>
  <!---------->
  
     <!---------->

</div>

<!-- içerik Alanı-Resim-Sonu --> 

    <!-- Video-Ikonlar -->
    <div class="container-fluid padding-top-16">
  <div class="container ">
    <div class="col-md-12 col-xs-12 h100 padding-Sifir padding-Sifirsol margin-Sifir padding-bottom-32">
      
  <div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
            <h5 style="font-weight:bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; "<asp:Label ID="Label1" runat="server" Text=""></asp:Label>Son Eklenen ilk Yardım Videoları</h5>
          </div>
 
                
        <asp:Repeater ID="rptTabMenu" runat="server">
            <ItemTemplate>
                 <div class="col-md-4 col-xs-12 padding-bottom-14 padding-top-16 bg-beyaz h-anime cerceve-ust cerceve-sag cerceve-alt">
      
                    <div class="col-md-12 col-xs-12 padding-Sifir thumbnail text-center Play h100 ">
                        <a class="bla-1 " href="<%#Eval("VideoLink") %>">
                            <img src="images/yuklenen/Video/buyuk/<%#Eval("VideoResimYolu") %>" alt="<%#Eval("VideoAdi") %>">
                            <div class="caption text-center padding-top-sifir">
                                <h5><span class="glyphicon glyphicon-facetime-video" aria-hidden="true"></span><%#Eval("VideoAdi") %></h5>
                            </div>
                        </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                     </div>
    </ItemTemplate>
        </asp:Repeater>
                

      </div>


    
  </div>
  <!--- Mobil --->
  
</div>
<!-- Video-Ikonlar-Sonu --> 

<!-- Duyuru-Alan -->
<div class="container-fluid padding-top-16">
  <div class="container padding-Sifir ">
    <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12 padding-Sifirsag">

        <div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
            <h5 style="font-weight:bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; "<asp:Label ID="lblBaslik" runat="server" Text=""></asp:Label>Son Eklenen Duyurular</h5>
          </div>

        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <div class="col-md-4 col-sm-4 col-xs-12 h100 text-center bg-yuvar" align="center">
                <div class="panel panel-warning h200">
                    <div class="panel-heading "><a href="<%#Duyurular(Eval("DuyuruId").ToString(),Eval("Baslik").ToString()) %>"><%#Eval("Baslik") %></a></div>
                    <div class="panel-body"><%#metin_kisalt_yan(Eval("icerik").ToString().Trim()) %></div>
                </div>
                    <div class="Temizle"></div>
</div>
                
            </ItemTemplate>
        </asp:Repeater>


        <!------------------------->
 <!------------------------->
      


    </div>

  </div>
  <!---------->
  
     <!---------->

</div>
<!-- Duyuru-Alan-Sonu --> 



</asp:Content>

