<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="KulGiris.aspx.cs" Inherits="KulGiris" %>

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
                     <h4><span class="glyphicon glyphicon-lock"></span>Giriş Yap</h4>  </div>
                 <div class="Kayit_bg">


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

                     <!----------------->
                     <div class="form-group">
                  <label for="usrname"><span class="glyphicon glyphicon-user"></span>e-Mail</label>
                  <asp:TextBox ID="txtMail" class="form-control" TextMode="Email" placeholder="Enter email" runat="server"></asp:TextBox>
              </div>
              <div class="form-group">
                  <label for="psw"><span class="glyphicon glyphicon-eye-open"></span>Şifre</label>
                  <asp:TextBox ID="txtSifre" class="form-control" TextMode="Password" placeholder="Enter Şifre" runat="server"></asp:TextBox>
              </div>
              <div class="checkbox">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:CheckBox ID="chHatirla" Text="Beni Hatırla" runat="server" />
              </div>


                      <asp:Button ID="BtnGiris" CssClass="btn btn-success btn-block glyphicon glyphicon-off" runat="server" Text="GirişYap" OnClick="BtnGiris_Click"  />


                     <div class="modal-footer">
                          <a href="Default.aspx" class="btn btn-danger btn-default pull-left" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Iptal</a>
              <%--<button type="submit" class="btn btn-danger btn-default pull-left" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>İptal</button>--%>
              <p><a href="KayitOl.aspx">Üye Ol</a></p>
              <p><a href="Unuttum.aspx">Şifremi Unuttum?</a></p>
          </div>
  
                    
                     <!----------------->
    </div>

             </div>

            <div class="col-sm-4 col-md-3"></div>

        </div>
    </div>

</asp:Content>

