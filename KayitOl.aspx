<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="KayitOl.aspx.cs" Inherits="KayitOl" %>

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

    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4 col-md-3"></div>
             <div class="col-sm-4 col-md-6">
                 <div class="Kayit-Header">
                     <h4><span class="glyphicon glyphicon-plus-sign"></span> Yeni Kayıt</h4>  </div>
                 <div class="Kayit_bg">


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
                         <asp:Label ID="Label4" runat="server" CssClass="col-md-3 Lable-Top" Text="e-Mail Adresi"></asp:Label>
                         <div class="col-md-9">

                             <asp:TextBox ID="txtMail" CssClass="form-control Top" TextMode="Email" placeholder="e-Mail Adresi" runat="server"></asp:TextBox>
                         </div>
                     </div>
                 
                     
                       <div class="form-group Top">
                      <asp:Label ID="Label5" runat="server" CssClass="col-md-3 Lable-Top" Text="Şifre"></asp:Label>
                     <div class="col-md-9">
                     <asp:TextBox ID="txtSifre" CssClass="form-control Top" TextMode="Password" placeholder="Şifre"  runat="server"></asp:TextBox>
                    </div>
                     </div>


                       <div class="form-group Top">
                      <asp:Label ID="Label6" runat="server" CssClass="col-md-3 Lable-Top" Text="Şifre Tekrar"></asp:Label>
                <div class="col-md-9">
                     <asp:TextBox ID="txtSifreTekrar" CssClass="form-control Top" TextMode="Password" placeholder="Şifre Tekrar"  runat="server"></asp:TextBox>
                </div> 
                </div>

                     <div class="form-group Top">
                         <asp:Label ID="Label7" runat="server" CssClass="col-md-3 Lable-Top" Text="Doğum Tarihi"></asp:Label>
                         <div class="col-md-9">
                             <asp:TextBox ID="txtDTarih" CssClass="form-control Top"  placeholder="Doğum Tarihi GG/AA/YY" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDTarih"  runat="server" DefaultView="Years" Enabled="True"></asp:CalendarExtender>
                         </div>
                     </div>



                       <div class="form-group Top">
                          <asp:Label ID="Label8" runat="server" CssClass="col-md-3 Lable-Top" Text="Cinsiyet"></asp:Label>
                      <div class=" col-md-9">
                         <div class="row">
                             <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <div class="checkbox">
                     <asp:RadioButton ID="rdbtnBay" Text="Bay" CssClass="radio" Checked="true" GroupName="Cinsiyet" runat="server" />
                       
                     <asp:RadioButton ID="rdbtnBayan" Text="Bayan" CssClass="radio" GroupName="Cinsiyet" runat="server" />
                            </div>
                                </div>
                                <div class="col-md-1"></div>
                         </div>
                        </div>
                         </div>



                    


  
                     <asp:Button ID="BtnKaydet" CssClass="btn btn-success btn-block Top" runat="server" Text="Kaydet" OnClick="BtnKaydet_Click"  />
                   

    </div>

             </div>

            <div class="col-sm-4 col-md-3"></div>

        </div>
    </div>

</asp:Content>

