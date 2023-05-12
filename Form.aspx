<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Form.aspx.cs" Inherits="Form" %>

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

            
        .Lable-bg{background:#f5f6f0;}
        .alert-border{border-color:#f5f6f0;}

        .Top2{ margin-top:10px; }

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



    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!-- Alt-sayfa -->
<div class="container-fluid padding-top-16">
  <div class="container padding-Sifir">
    <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12 padding-bottom-32">
      <div class="col-md-12 col-sm-12 col-xs-12 h270 bg-beyaz padding-top-16 padding-bottom-16 img-rounded">
        <div class="col-md-8 col-sm-8 col-xs-12 padding-Sifir"> 
    <!-- Alt-sayfa-icerik -->
          <div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
            <h5 style="font-weight:bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; "Soru? && Cevap!</h5>
          </div>
          <div class="col-md-12 col-sm-12 col-xs-12 text-left padding-top-16"> 
            <!--xxxxxxxxx--> 

              <asp:DataList ID="DtList" Width="100%" runat="server">
                  <ItemTemplate>
             <div class="alert alert-info Lable-bg Lable-Color2 alert-border">
           
            Rumuz:&nbsp;<%#Eval("KullaniciAdi") %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Tarih:&nbsp;<%#Eval("GTarih") %><br />Konu:&nbsp;<%#Eval("Konu") %><br />Soru:&nbsp;<%#Eval("Mesaj") %><hr />Cevap:&nbsp;<%#Eval("MesajCevap") %></div>
                  </ItemTemplate>
              </asp:DataList>
           
            <!--xxxxxxxxx--> 
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



          </div>
          

          <!-- Alt-sayfa-icerik --> 
        </div>
        <div class="col-md-4 col-sm-4 col-xs-12 padding-Sifirsag">
          <div class="col-md-12 col-sm-12 col-xs-12 text-center img-rounded baslik2">
            <h5 style="font-weight:bold !important;">Mesaj Gönder&nbsp;<span class="glyphicon glyphicon-tags" aria-hidden="true"></span></h5>
          </div>
          <div class="col-md-12 col-sm-12 col-xs-12  padding-top-16 padding-bottom-16 h270 bg-test1">
            <p>
                <ul class="list-group">
              <li class="list-group-item">
                 <asp:Panel ID="pnlBasarili" Visible="false" runat="server">
<div class="alert alert-success fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Başarılı! </strong><asp:Label ID="lblBasarili" runat="server" Text=""></asp:Label> 
  </div>
</asp:Panel>

                 <asp:Panel ID="pnlHata" Visible="false" runat="server">
  <div class="alert alert-danger fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Hatalı! </strong> <asp:Label ID="lblHata" runat="server" Text=""></asp:Label> .
  </div>
</asp:Panel>

                 <asp:Panel ID="pnlGonder" runat="server">  

                         <div class="form-group Top">
                         <asp:Label ID="Label10" runat="server" CssClass="col-md-12 Lable-Top Lable-Color3" Text="">Rumuz</asp:Label>
                            <div class="col-md-12">
                             <asp:TextBox ID="txtKullaniciAdi" CssClass="form-control Top" placeholder="Kullanici Adi" runat="server"></asp:TextBox>
                         </div>
                     </div>
                         <div class="form-group Top">
                         <asp:Label ID="Label11" runat="server" CssClass="col-md-12 Lable-Top Lable-Color3" Text="e-Mail Adresi">e-Mail</asp:Label>
                         <div class="col-md-12">
                             <asp:TextBox ID="txtMail" CssClass="form-control Top" TextMode="Email" placeholder="Mail" runat="server"></asp:TextBox>
                         </div>
                     </div>

                        <div class="form-group Top">
                         <asp:Label ID="Label4" runat="server" CssClass="col-md-12 Lable-Top Lable-Color3" Text="">Konu</asp:Label>
                         <div class="col-md-12">
                             <asp:TextBox ID="txtKonu" CssClass="form-control Top" placeholder="Konu" runat="server"></asp:TextBox>
                         </div>
                     </div>

                        <div class="form-group Top">
                         <asp:Label ID="Label6" runat="server" CssClass="col-md-12 Lable-Top Lable-Color3" Text="">Mesaj</asp:Label>
                         <div class="col-md-12">
                             <asp:TextBox ID="txtMsj" CssClass="form-control Top" placeholder="Mesajınız" TextMode="MultiLine" runat="server"></asp:TextBox>
                         </div>
                     </div>
                        <div class="Temizle"></div>
                        <div class="Top2">
                          <asp:Button ID="btnMsjGonder" CssClass="btn btn-primary btn-block Top"  runat="server" Text="Mesaj Gönder" OnClick="btnMsjGonder_Click" />
                        </div>
                    </asp:Panel>
                  </li>
                    </ul>
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- Alt-sayfa-Sonu --> 
</asp:Content>

