<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Duyuru.aspx.cs" Inherits="Duyuru" %>

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
                    <div class="col-md-12 col-sm-12 col-xs-12 padding-Sifir">
                        <!-- Alt-sayfa-icerik -->

<div class="col-md-12 col-sm-12 col-xs-12 text-left  img-rounded baslik">
                            <h5 style="font-weight: bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; <asp:Literal ID="lblBaslik" runat="server"></asp:Literal></h5>
                        </div>
                       
                        <asp:Panel ID="pnlDuyuru"  runat="server">
                            <asp:DataList ID="DtList" Width="100%" runat="server">
<ItemTemplate>
                                    <p></p>
                                      <div class="panel panel-warning">
      <div class="panel-heading "><a href="<%#Duyurular(Eval("DuyuruId").ToString(),Eval("Baslik").ToString()) %>" ><%#Eval("Baslik") %></a></div>
      <div class="panel-body"><%#metin_kisalt_yan(Eval("icerik").ToString().Trim()) %></div>
    </div>


                        </div>
                                </ItemTemplate>

                            </asp:DataList>

                            <cc1:CollectionPager ID="Sayfalama" runat="server" BackNextDisplay="Buttons"
BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
PageNumbersStyle="" PageNumberStyle="" PageSize="4" PagingMode="PostBack"
QueryStringKey="Sayfa"
ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
ShowLabel="False" ShowPageNumbers="True" SliderSize="15"  UseSlider="True">
        </cc1:CollectionPager>

                        </asp:Panel>



                        <!-- Alt-sayfa-icerik -->
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
<!-- Alt-sayfa-Sonu --> 
</asp:Content>

