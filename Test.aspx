<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .Cevap { color:#3c7e26; font-weight:bold; float:right;
        }
         .Cevap2 { color:#2d4d22; font-weight:bold; float:right;
        }
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
                            <h5 style="font-weight: bold !important;"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>&nbsp; <asp:Literal ID="lblBaslik"  runat="server"></asp:Literal></h5>
                        </div>
                        <div class="col-md-12 col-sm-18 col-xs-12 text-left padding-top-16">
                            <!--xxxxxxxxx-->


                            <asp:GridView AutoGenerateColumns="false" GridLines="None" ID="GridView1" Width="100%" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <div class="panel panel-warning">
                                <div class="panel-heading"><%#Eval("Soru") %></div>
                                <div class="panel-body">
                          <asp:Label ID="lblSoruId" Visible="false" runat="server" Text='<%#Eval("SoruId") %>'></asp:Label>
                        <asp:RadioButton ID="Soru1A" Text='<%#Eval("A") %>' GroupName="Sorular" runat="server" />
                        <br></br>
                        <asp:RadioButton ID="Soru1B"  Text='<%#Eval("B") %>' GroupName="Sorular" runat="server" />
                        <br></br>
                        <asp:RadioButton ID="Soru1C"  Text='<%#Eval("C") %>' GroupName="Sorular" runat="server" />
                        <br></br>
                        <asp:RadioButton ID="Soru1D"  Text='<%#Eval("D") %>' GroupName="Sorular" runat="server" />
                        <br>
                            <asp:Panel ID="pnlCevap" Visible="false"  runat="server">
                                <asp:Label ID="lblcvp" CssClass="Cevap" runat="server" Text='<%#Eval("Cevap") %>'></asp:Label><asp:Label ID="Label1" runat="server" CssClass="Cevap2" Text="Cevap= "></asp:Label></asp:Panel>
                        </br>

                         </div>
                            </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                            <asp:Button ID="btnCevap" class="btn btn-warning btn-block" runat="server" Text="Cevaplar" OnClick="btnCevap_Click" />


                           

                               
           
            <!--xxxxxxxxx-->




                        </div>


                        <!-- Alt-sayfa-icerik -->
                    </div>
                    <div class="col-md-4 col-sm-4 col-xs-12 padding-Sifirsag">
                        <div class="col-md-12 col-sm-12 col-xs-12 text-center img-rounded baslik2">
                            <h5 style="font-weight: bold !important;">Doğru&nbsp;&&nbsp;Yanlış <span class="glyphicon glyphicon-tags" aria-hidden="true"></span></h5>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12  padding-top-16 padding-bottom-16 h270 bg-test1">
                            <ul class="list-group">
                                <li class="list-group-item">
                                    <asp:Label ID="lblDogru" runat="server" Text="Dogru Sayısı: "></asp:Label>
                                </li>
                                <li class="list-group-item">
                                    <asp:Label ID="lblYanlis" runat="server" Text="Yanlış Sayısı: "></asp:Label>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
<!-- Alt-sayfa-Sonu --> 
</asp:Content>

