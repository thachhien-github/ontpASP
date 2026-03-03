<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="QTTour.aspx.cs" Inherits="WebDuLich.QTTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    
    <h2>Trang quản trị tour</h2>
    <hr />    
    <div class="row">
         <div class="col-md-6">
              <div class="form-inline">
                   Tên tour <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" Width="300"></asp:TextBox>
                  <asp:Button ID="btTraCuu" runat="server" Text="Tra cứu" CssClass="btn btn-primary" />
              </div>
         </div>
        <div class="col-md-6 text-right">
             <a href="ThemTour.aspx" class="btn btn-success">Thêm tour mới</a>
        </div>
    </div>

    <div style="margin-top:20px">
        
    </div>

  

</asp:Content>
