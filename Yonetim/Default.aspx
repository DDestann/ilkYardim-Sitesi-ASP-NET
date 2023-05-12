<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .W400{
            width:400px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    





       <!--------  Orta Alan  ------------------>
<div class="container-fluid ">
<div class="row">

<!--------  Orta Alan Üst Başlık ------------------>
<div class=" col-sm-3 col-md-2"></div>
<div class=" col-sm-9  col-md-10">
  <h2 class=" page-header Baslik slidbar_top">Sistemde Kayıtlı Tüm Dosyalar  </h2>
</div>
<!--------  Orta Alan Üst Başlık Bitti ------------------>
<div class=" col-sm-3 col-md-2"></div>
<div class=" col-sm-9  col-md-10">
<div class="panel panel-primary">
      <div class="panel-heading panel-heading-Height"><h5 class=" AltBaslik"> <asp:Label ID="lblBaslik" runat="server" Text="Sistemde Kayıtlı Tüm Dosyalar"></asp:Label> </h5></div>
      <div class="panel-body">
      
      
      <div style="margin-top:5px;">

<div class="col-md-12">
   
  
  <table class="table table-hover ">
    
      <tbody>

          <tr>
              <td class="h3">Kayıtlı Kategori Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblKategori" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı AltKategori Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblAltKategori" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı VideoKat Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblVideoKat" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı VideoAltKat Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblVideoAltKat" runat="server"></asp:Label>
              </td>
          </tr>


          <tr>
              <td class="h3">Kayıtlı Banner Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblBanner" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı Galeri Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblGaleri" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı AnaResim Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblAnaResim" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı Duyuru Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblDuyuru" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı Kullanıcı Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblKullanici" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı Test Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblTest" runat="server"></asp:Label>
              </td>
          </tr>

          <tr>
              <td class="h3">Kayıtlı Soru Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblSoru" runat="server"></asp:Label>
              </td>
          </tr>


          <tr>
              <td class="h3">Kayıtlı Yönetici Sayısı </td>
              <td class="h4">
                  <asp:Label ID="lblYonetici" runat="server"></asp:Label>
              </td>
          </tr>

      </tbody>

  </table>



 </div>
</div>


<div class="Temizle"></div>
      
      
      </div>
    </div>

</div>

</div>
</div>




</asp:Content>

