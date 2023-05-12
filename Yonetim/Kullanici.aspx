﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Kullanici.aspx.cs" Inherits="Kullanici" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   

    <style type="text/css">

        .Sekil { float:right; width:100%;
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

.Flu INPUT
{
    background-color:white;
    color:#6999e6;
    padding: 8px 12px 8px 12px;
    text-decoration: none;
    transition: background-color .3s;
    border: 1px solid #ddd;
    text-align:center;
}

.Top{ margin-top:10px; }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!--------  Orta Alan  ------------------>
<div class="container-fluid">
<div class="row">

<!--------  Orta Alan Üst Başlık ------------------>
<div class=" col-sm-3 col-md-2"></div>
<div class=" col-sm-9  col-md-10">
  <h2 class=" page-header Baslik slidbar_top"> Kullanıcı Yönetimi</h2>
</div>
<!--------  Orta Alan Üst Başlık Bitti ------------------>
<div class=" col-sm-3 col-md-2"></div>
<div class=" col-sm-9  col-md-4">
<div class="panel panel-primary">
      <div class="panel-heading panel-heading-Height"><h5 class=" AltBaslik"> <asp:Label ID="lblBaslik" runat="server" Text=""></asp:Label> </h5></div>
      <div class="panel-body">
      
      
      <div style="margin-top:5px;">

<div class="col-md-12">
    <asp:Panel ID="pnlBasarili" Visible="false" runat="server">
<div class="alert alert-success fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Başarılı! </strong><asp:Label ID="lblBasarili" runat="server" Text=""></asp:Label> 
  </div>
</asp:Panel>
 <!-------- <div class="alert alert-info fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Info!</strong> This alert box could indicate a neutral informative change or action.
  </div>------>

    <asp:Panel ID="pnlKontrol" Visible="false" runat="server">
         <div class="alert alert-warning fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Uyarı!</strong> <asp:Label ID="lblKontrol" runat="server" Text=""></asp:Label>
  </div>
    </asp:Panel>

    <asp:Panel ID="pnlHata" Visible="false" runat="server">
  <div class="alert alert-danger fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Hatalı! </strong> <asp:Label ID="lblHata" runat="server" Text=""></asp:Label> .
  </div>
</asp:Panel>
 </div>
</div>


<div class="Temizle"></div>
      
<!-----<div style="margin-top:5px;">
<div class="col-md-4 lable_Center">Kategori Adı:</div>
<div class="col-md-8"> <input type="text" class="form-control" placeholder="Search..."> </div>
</div>------->
          <form class="form-horizontal">

<!--------  Ara ------------------>

              <asp:DropDownList ID="DrpAra" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpAra_SelectedIndexChanged" >
            <asp:ListItem Value="0">Seçiniz....</asp:ListItem>
            <asp:ListItem Value="1">Engelli Kullanıcılar</asp:ListItem>
            <asp:ListItem Value="2">Normal Kullanıcılar</asp:ListItem>
        </asp:DropDownList>


  <!--------  Normal ------------------>
          <asp:Panel ID="pnlNormalAra"  Visible="false" runat="server">

              <div class="form-group ">
      <asp:Label  ID="Label1" runat="server" class="col-sm-2 lable_Color">Ara</asp:Label>
    <div class="col-sm-8 ">
        <asp:TextBox ID="txtAra" class="form-control"  placeholder="Kullanıcı Adı & Mail Adresi "  runat="server"></asp:TextBox>

    </div>
                  <div class="col-sm-2">
                      <asp:Button ID="btnAra" Text="Ara" runat="server" class="btn btn-primary Button-Right btn-sm Button-Top" OnClick="btnAra_Click" />
                  </div>
<div class=" Top"></div>
  </div>
              
              

                <asp:DataList ID="DtListNormalAra" Visible="true" Width="100%" runat="server">

         <HeaderTemplate>
                <table class="table table-hover ">
 
          <thead >
      <tr class="Tablo-bg Sekil">
        
          <th style="width:25%;" >Profil</th>
          <th style="width:35%;" >Kullanıcı Adı</th>
        <th style="width:35%;" >Mail</th>
        <th style="width:5%;">Engelle</th>
       <%-- <th  style="width:5%;">Sil</th>--%>
        
      </tr>
    </thead>
                    </table>
         </HeaderTemplate>

         <itemtemplate>
             <table class="table table-hover ">
                 <tbody>
                     <tr>
                         <td style="width:20%;">
                             <img class="thumbnail" width="70" height="90" src="../images/yuklenen/Profil/kucuk/<%#Eval("ResimYolu") %>"  />
                         </td>
                         <td style="width:35%;"><%#Eval("AdSoyad") %></td>
                        <td style="width:40%;"><%#Eval("Mail") %></td>
                         <td style="width:5%;"><a href="Kullanici.aspx?Engelle=<%#Eval("KullaniciId") %>">
                             <img src="images/addcross.png"></a></td>
                         <%--<td style="width:5%;"><a href="Kullanici.aspx?Sil=<%#Eval("BannerId") %>" onclick='return confirm("Silmek istediğinizden emin misiniz?");'>
                             <img src="images/trash.png"></a></td>--%>
                     </tr>

                 </tbody>
             </table> 
      </itemtemplate>
     
          </asp:DataList>

  <!---- page ------>
        
      <cc1:CollectionPager ID="CollectionPager2" runat="server" BackNextDisplay="Buttons"
BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="PostBack"
QueryStringKey="Sayfa"
ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
ShowLabel="False" ShowPageNumbers="True" SliderSize="15"  UseSlider="True">
        </cc1:CollectionPager>

<!---- page ------>
          </asp:Panel>
          <!--------  Normal Bitti ------------------>


 <!--------  ENGEL ------------------>
          <asp:Panel ID="pnlEngelliAra"  Visible="false" runat="server">

              <div class="form-group ">
      <asp:Label  ID="Label2" runat="server" class="col-sm-2 lable_Color">Ara</asp:Label>
    <div class="col-sm-8 ">
        <asp:TextBox ID="txtAra2" class="form-control"  placeholder="Kullanıcı Adı & Mail Adresi "  runat="server"></asp:TextBox>

    </div>
                  <div class="col-sm-2">
                      <asp:Button ID="btnAra2" Text="Ara" runat="server" class="btn btn-primary Button-Right btn-sm Button-Top" OnClick="btnAra2_Click"  />
                  </div>
<div class=" Top"></div>
  </div>
              
              

                <asp:DataList ID="DtListEngelliAra" Visible="true" Width="100%" runat="server">

         <HeaderTemplate>
                <table class="table table-hover ">
 
          <thead >
      <tr class="Tablo-bg Sekil">
        
          <th style="width:25%;" >Profil</th>
          <th style="width:35%;" >Kullanıcı Adı</th>
        <th style="width:35%;" >Mail</th>
        <th style="width:5%;">Engelle</th>
       <%-- <th  style="width:5%;">Sil</th>--%>
        
      </tr>
    </thead>
                    </table>
         </HeaderTemplate>

         <itemtemplate>
             <table class="table table-hover ">
                 <tbody>
                     <tr>
                         <td style="width:20%;">
                             <img class="thumbnail" width="70" height="90" src="../images/yuklenen/Profil/kucuk/<%#Eval("ResimYolu") %>"  />
                         </td>
                         <td style="width:35%;"><%#Eval("AdSoyad") %></td>
                        <td style="width:40%;"><%#Eval("Mail") %></td>
                         <td style="width:5%;"><a href="Kullanici.aspx?EngelKaldir=<%#Eval("KullaniciId") %>">
                             <img src="images/add.png"></a></td>
                         <%--<td style="width:5%;"><a href="Kullanici.aspx?Sil=<%#Eval("BannerId") %>" onclick='return confirm("Silmek istediğinizden emin misiniz?");'>
                             <img src="images/trash.png"></a></td>--%>
                     </tr>

                 </tbody>
             </table> 
      </itemtemplate>
     
          </asp:DataList>

  <!---- page ------>
        
      <cc1:CollectionPager ID="CollectionPager3" runat="server" BackNextDisplay="Buttons"
BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="PostBack"
QueryStringKey="Sayfa"
ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
ShowLabel="False" ShowPageNumbers="True" SliderSize="15"  UseSlider="True">
        </cc1:CollectionPager>

<!---- page ------>
          </asp:Panel>
          <!--------  ENGEL Bitti ------------------>



          <!--------  Ara Bitti ------------------>


              <br/>
              <br />
             
          </form>

      
      </div>
    </div>

</div>
<!--------  Orta Alan Sağ ------------------>
<div class=" col-sm-3 col-md-2"></div>
<div class=" col-sm-9 col-md-6">


   <div class="panel panel-primary">
     <div class="panel-heading panel-heading-Height"><h5 class=" AltBaslik"> Kullanici Listele&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
         </h5></div>
      <div class=" panel panel-body">
      <div class=" col-sm-6 col-md-12">
      
           <div class="form-group">
      <asp:Label  ID="Label4" runat="server" class="col-sm-3 lable_Color">Kullanıcı Listele</asp:Label>
    <div class="col-sm-9 ">
        <asp:DropDownList ID="DrpList" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpList_SelectedIndexChanged">
            <asp:ListItem Value="0">Seçiniz....</asp:ListItem>
            <asp:ListItem Value="1">Engelli Kullanıcılar</asp:ListItem>
            <asp:ListItem Value="2">Normal Kullanıcılar</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
          <br />
          <br />
          
          <!--------  Engelle ------------------>
          <asp:Panel ID="pnlEngelle" Visible="true" runat="server">
                <asp:DataList ID="Dtlist" Visible="true" Width="100%" runat="server">

         <HeaderTemplate>
                <table class="table table-hover ">
 
          <thead >
      <tr class="Tablo-bg Sekil">
        
          <th style="width:25%;" >Profil</th>
          <th style="width:35%;" >Kullanıcı Adı</th>
        <th style="width:35%;" >Mail</th>
        <th style="width:5%;">Engelle</th>
       <%-- <th  style="width:5%;">Sil</th>--%>
        
      </tr>
    </thead>
                    </table>
         </HeaderTemplate>

         <itemtemplate>
             <table class="table table-hover ">
                 <tbody>
                     <tr>
                         <td style="width:20%;">
                             <img class="thumbnail" width="70" height="90" src="../images/yuklenen/Profil/kucuk/<%#Eval("ResimYolu") %>"  />
                         </td>
                         <td style="width:35%;"><%#Eval("AdSoyad") %></td>
                        <td style="width:40%;"><%#Eval("Mail") %></td>
                         <td style="width:5%;"><a href="Kullanici.aspx?Engelle=<%#Eval("KullaniciId") %>">
                             <img src="images/addcross.png"></a></td>
                         <%--<td style="width:5%;"><a href="Kullanici.aspx?Sil=<%#Eval("BannerId") %>" onclick='return confirm("Silmek istediğinizden emin misiniz?");'>
                             <img src="images/trash.png"></a></td>--%>
                     </tr>

                 </tbody>
             </table> 
      </itemtemplate>
     
          </asp:DataList>

  <!---- page ------>
        
      <cc1:CollectionPager ID="Sayfalama" runat="server" BackNextDisplay="Buttons"
BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="PostBack"
QueryStringKey="Sayfa"
ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
ShowLabel="False" ShowPageNumbers="True" SliderSize="15"  UseSlider="True">
        </cc1:CollectionPager>

<!---- page ------>
          </asp:Panel>
          <!--------  Engelle Bitti ------------------>


           <!--------  Engel Kaldır ------------------>
          <asp:Panel ID="pnlKaldir" Visible="false" runat="server">
                <asp:DataList ID="DtListEngelKaldir" Visible="true" Width="100%" runat="server">

         <HeaderTemplate>
                <table class="table table-hover ">
 
          <thead >
      <tr class="Tablo-bg Sekil">
        
          <th style="width:20%;" >Profil</th>
          <th style="width:35%;" >Kullanıcı Adı</th>
        <th style="width:35%;" >Mail</th>
        <th style="width:10%;">EngelKaldır</th>
        <%--<th  style="width:5%;">Sil</th>--%>
        
      </tr>
    </thead>
                    </table>
         </HeaderTemplate>

         <itemtemplate>
             <table class="table table-hover ">
                 <tbody>
                     <tr>
                         <td style="width:20%;">
                             <img class="thumbnail" width="70" height="90" src="../images/yuklenen/Profil/kucuk/<%#Eval("ResimYolu") %>"  />
                         </td>
                         <td style="width:35%;"><%#Eval("AdSoyad") %></td>
                        <td style="width:35%;"><%#Eval("Mail") %></td>
                         <td style="width:10%;"><a href="Kullanici.aspx?EngelKaldir=<%#Eval("KullaniciId") %>">
                             <img src="images/add.png"></a></td>
                         <%--<td style="width:5%;"><a href="Kullanici.aspx?Sil=<%#Eval("BannerId") %>" onclick='return confirm("Silmek istediğinizden emin misiniz?");'>
                             <img src="images/trash.png"></a></td>--%>
                     </tr>

                 </tbody>
             </table> 
      </itemtemplate>
     
          </asp:DataList>

  <!---- page ------>
        
      <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="Buttons"
BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="PostBack"
QueryStringKey="Sayfa"
ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
ShowLabel="False" ShowPageNumbers="True" SliderSize="15"  UseSlider="True">
        </cc1:CollectionPager>

<!---- page ------>
          </asp:Panel>
          <!--------  Engel Kaldır Bitti ------------------>


</div>
      </div>
    </div>

</div>
<!--------  Orta Alan Sağ Bitti ------------------>

</div>
</div>

</asp:Content>

