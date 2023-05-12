<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Galeri" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">

        .Lable-Color{
            color:black;
            font-size:14px; font-weight:bold;
        }

        .Lable-Color2{
            color:#6aabd0;
            font-size:12px; font-weight:bold;
        }
        .Lable-Color3{
            color:#6aabd0;
            font-size:14px; font-weight:bold;
        }

        .Lable-bg{background:#f1ecec;}
        .Top2{ margin-top:10px; }

        .img-buyuk { width:640px; height:400px;
        }

         .img-kucuk { width:160px; height:120px;
        }

           .Sayfalama a:link, .Sayfalama a:visited, .Sayfalama a:active
{

    color: #6999e6;
   padding: 10px 12px 10px 12px;
    text-decoration: none;
    transition: background-color .3s;
    border: 1px solid #ddd;
    text-align:center;
    
}

        .Sayfalama a:hover
{
     background-color: #eee;
    padding: 10px 12px 10px 12px;
    text-decoration: none;
    transition: background-color .3s;
    border: 1px solid #ddd;
    
}

.Sayfalama INPUT
{
    background-color:white;
 color:#6999e6;
    padding: 8px 12px 8px 12px;
    text-decoration: none;
    transition: background-color .3s;
    border: 1px solid #ddd;
text-align:center;
}

.Sayfalama INPUT:hover
{
   background-color: #eee;
 color:#6999e6;
    padding: 8px 12px 8px 12px;
    text-decoration: none;
    transition: background-color .3s;
    border: 1px solid #ddd;
text-align:center;
}

.Sayfalama B
{

    background-color: #6999e6;
    color: white;
    padding: 10px 12px 10px 12px;
    text-decoration: none;
    transition: background-color .3s;
    border: 1px solid #ddd;
}

.Play:hover{
    opacity: 0.5;
    filter: alpha(opacity=50);
}


    </style>

    
   
    
	<script type="text/javascript">
	    jQuery(function () {
	        jQuery("a.bla-1").YouTubePopUp();
	        //jQuery("a.bla-2").YouTubePopUp({ autoplay: 0 }); // Disable autoplay
	    });
	</script>
   



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!-- Alt-sayfa -->
<div class="container-fluid padding-top-16">
  <div class="container padding-Sifir">
    <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12 padding-bottom-32">
      <div class="col-md-12 col-sm-12 col-xs-12 h270 bg-beyaz padding-top-16 padding-bottom-16 img-rounded">
        <div class="col-md-12 col-sm-12 col-xs-12 padding-Sifir"> 
          <!-- Alt-sayfa-icerik -->
          <div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
            <h5 style="font-weight:bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; "<asp:Label ID="lblBaslik" runat="server" Text=""></asp:Label>" Videoları</h5>
          </div>
          <div class="col-md-12 col-sm-12 col-xs-12 text-left padding-top-16"> 
            <!--xxxxxxxxx--> 


            <div class="col-sm-12 col-md-12 padding-Sifir margin-Sifir">
              
               
	
         <asp:Repeater ID="Repeater1" runat="server">
             <ItemTemplate>
 <div class="col-sm-4 col-md-4  ">
                 <div class="thumbnail text-center  h200  Play"> <a class="bla-1 " href="<%#Eval("VideoLink") %>" ><img src="images/yuklenen/Video/buyuk/<%#Eval("VideoResimYolu") %>" width="250" height="250" alt="<%#Eval("VideoAdi") %>">
                <div class="caption text-center padding-top-sifir">
                  <h5><span class="glyphicon glyphicon-facetime-video" aria-hidden="true"></span> <%#Eval("VideoAdi") %></h5>
                </div>
                </a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>


</div>
             </ItemTemplate>
         </asp:Repeater>
            
	


            </div>
            
            
            <br>&nbsp;<br>&nbsp;<br>
            
            <!--xxxxxxxxx--> 
            
          </div>
         
          <!-- Alt-sayfa-icerik --> 
        </div>
        
      </div>
    </div>
  </div>
</div>
<!-- Alt-sayfa-Sonu --> 
</asp:Content>

