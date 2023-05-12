<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">


.Kayit-Header{
    background-color: #5cb85c;
      color:white !important;
      text-align: center;
      font-size: 30px;
      padding:35px 50px;

}


.Kayit_bg {
    border-radius: 5px;
    background-color: #f9f9f9;
    padding: 20px;
}

        .Lable-Top {
            text-align:center;
           margin-top:16px;
            font-size:14px;
            font-weight:bold;
        }

        .Top{ margin-top:13px;}

        .Top2{ margin-top:20px;}


        .Profil-bg{
          background-color: #f9f9f9;
            width:auto;
        }

        .Profil{
            list-style-type: none;
    margin: 0;
    padding: 0;
     background-color: #f9f9f9;
    /*height:700px;*/

        }

        .Profil-Bilgi{
            list-style-type: none;
    margin: 0;
    padding: 0;
    background-color: #f9f9f9;

    /*height:700px;*/

        }
        .Bilgi-Color {

            color:#287ac1;
            font-size:12px;
            font-weight:bold;
          margin-left:15px;
        }

        .Profil-img{

            width:125px; 
            height:150px;
            margin:20px 30px;

        }

       

     .Menu-nav   ul {
         
    list-style-type: none;
    margin: 0;
    padding: 0;
   width:215px;
   /*height:700px;*/
    background-color: #f9f9f9;
}

.Menu-nav  li a {
    display: block;
    color: #000;
    padding: 8px 0 8px 16px;
    text-decoration: none;
}

.Menu-nav  li a.active {
    background-color: #4CAF50;
    color: white;
}

.Menu-nav  li a:hover:not(.active) {
    background-color: #555;
    color: white;
}



    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="container-fluid Profil-bg">
        <div class="row Hizala">
           
            <div class=" col-sm-4 col-md-2 col-md-offset-2 Menu-nav "> 
                <div class="Top2"></div>
                <ul>
                    <li>
                        <asp:LinkButton ID="btnProfil" runat="server" OnClick="btnProfil_Click">Profilim</asp:LinkButton></li>
                   
                    <li>
                        <asp:LinkButton ID="btnMsj" runat="server" OnClick="btnMsj_Click">Mesaj Gönder</asp:LinkButton></li>
                </ul>

            </div>

            <div class=" col-sm-4 col-md-2  Profil">

             
                <asp:Image ID="ProfilResim" class="img-rounded Profil-img" runat="server" />

             <div class=" col-sm-6 col-md-12">
                 <asp:Label ID="lblKulAd" runat="server" CssClass=" Bilgi-Color"  Text=""></asp:Label>
                 <hr />
                 <asp:Label ID="lblililce" runat="server" CssClass=" Bilgi-Color" Text=""></asp:Label>
                  <hr />
             </div>


            </div>

            <div class=" col-sm-4 col-md-5 Profil-Bilgi">
                <div class=" col-sm-6 col-md-12">


                      <asp:Panel ID="pnlBasarili" Visible="false" runat="server">
<div class="alert alert-success fade in">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Başarılı! </strong><asp:Label ID="lblBasarili" runat="server" Text=""></asp:Label> 
  </div>
</asp:Panel>


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

                         <!---------- pnl Bilgi----------------->
                    <asp:Panel ID="pnlBilgi" runat="server">

                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             
                    <div class="form-group Top">
                     <asp:Label ID="Label2" CssClass="col-md-3 Lable-Top"  runat="server" Text="il"></asp:Label>
                         <div class="col-md-9">
                     <asp:DropDownList ID="Drpil" CssClass="form-control Top" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="Drpil_SelectedIndexChanged"></asp:DropDownList>
                     </div></div>

                     <div class="Top"></div>

                     <div class="form-group Top">
                         <asp:Label ID="Label3" runat="server" CssClass="col-md-3 Lable-Top" Text="ilçe"></asp:Label>
                          <div class="col-md-9">
                         <asp:DropDownList ID="Drpilce" CssClass="form-control Top" runat="server"></asp:DropDownList>
                     </div></div>

                         </ContentTemplate>
                     </asp:UpdatePanel>

                     <div class="form-group Top">
                         <asp:Label ID="Label1" runat="server" CssClass="col-md-3 Lable-Top" Text="Ad Soyad"></asp:Label>
                         <div class="col-md-9">
                             <asp:TextBox ID="txtAdSoyad" CssClass="form-control Top" placeholder="Ad Soyad" runat="server"></asp:TextBox>
                         </div>
                     </div>    
                     
                       <div class="form-group Top">
                         <asp:Label ID="Label9" runat="server" CssClass="col-md-3 Lable-Top" Text="Profil Resim"></asp:Label>
                         <div class="col-md-9">
                             <asp:FileUpload ID="fluResim" CssClass="form-control Top" runat="server" />
                         </div>
                     </div>
                                  
                     
                       <div class="form-group Top">
                      <asp:Label ID="Label5" runat="server" CssClass="col-md-3 Lable-Top" Text="Şifre"></asp:Label>
                     <div class="col-md-9">
                     <asp:TextBox ID="txtSifre" CssClass="form-control Top"  placeholder="Şifre"  runat="server"></asp:TextBox>
                    </div>
                     </div>


                  

                     <div class="form-group Top">
                         <asp:Label ID="Label7" runat="server" CssClass="col-md-3 Lable-Top" Text="Doğum Tarihi"></asp:Label>
                         <div class="col-md-9">
                             <asp:TextBox ID="txtDTarih" CssClass="form-control Top"  placeholder="Doğum Tarihi GG/AA/YY" runat="server" TargetControlID="txtDTarih"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDTarih"  runat="server" DefaultView="Years"></asp:CalendarExtender>
                         </div>
                     </div>



                       <div class="form-group Top">
                          <asp:Label ID="Label8" runat="server" CssClass="col-md-3 Lable-Top" Text="Cinsiyet"></asp:Label>
                      <div class=" col-md-9">
                         <div class="row">
                             <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <div class="checkbox">
                     <asp:RadioButton ID="rdbtnBay" Text="Bay" CssClass="radio" GroupName="Cinsiyet" runat="server" />
                       
                     <asp:RadioButton ID="rdbtnBayan" Text="Bayan" CssClass="radio" GroupName="Cinsiyet" runat="server" />
                            </div>
                                </div>
                                <div class="col-md-1"></div>
                         </div>
                        </div>
                         </div>

                    <asp:Button ID="BtnDuzenle" CssClass="btn btn-success btn-block Top" runat="server" Text="Profil Düzenle" OnClick="BtnDuzenle_Click" />

                     <asp:Button ID="BtnGuncelle" CssClass="btn btn-success btn-block Top" Visible="false" runat="server" Text="Güncelle" OnClick="BtnGuncelle_Click" />


                    </asp:Panel>
                    <!---------- pnl Bilgi Bitiş----------------->



                      <!---------- Mesaj Gönder----------------->


                    <asp:Panel ID="pnlGonder" Visible="false" runat="server">  

                        

                        <div class="form-group Top">
                         <asp:Label ID="Label4" runat="server" CssClass="col-md-3 Lable-Top" Text="Konu"></asp:Label>
                         <div class="col-md-9">
                             <asp:TextBox ID="txtKonu" CssClass="form-control Top" placeholder="Konu" runat="server"></asp:TextBox>
                         </div>
                     </div>

                        <div class="form-group Top">
                         <asp:Label ID="Label6" runat="server" CssClass="col-md-3 Lable-Top" Text="Mesaj"></asp:Label>
                         <div class="col-md-9">
                             <asp:TextBox ID="txtMsj" CssClass="form-control Top" placeholder="Mesajınız" TextMode="MultiLine" runat="server"></asp:TextBox>
                         </div>
                     </div>
                        <div class="Temizle"></div>
                        <div class="Top2">
                          <asp:Button ID="btnMsjGonder" CssClass="btn btn-primary btn-block Top"  runat="server" Text="Mesaj Gönder" OnClick="btnMsjGonder_Click" />
                        </div>
                    </asp:Panel>
                    <!---------- Mesaj Gönder Bitiş----------------->



                </div>


            </div>




        </div>

        <div class="Top2"></div>
    </div>

    







    <%--<div class="container-fluid">
        <div class="row">
            <div class="col-sm-4 col-md-3"></div>
             <div class="col-sm-4 col-md-6">
                 <div class="Kayit-Header">
                     <h4><span class="glyphicon glyphicon-plus-sign"></span> Yeni Kayıt</h4>  </div>
                 <div class="Kayit_bg">


                   

    </div>

             </div>

            <div class="col-sm-4 col-md-3"></div>

        </div>
    </div>--%>

</asp:Content>

