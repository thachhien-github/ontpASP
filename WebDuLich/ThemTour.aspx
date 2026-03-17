<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ThemTour.aspx.cs" Inherits="WebDuLich.ThemTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">

     <h2>Trang thêm tour</h2>
     <hr />
      
     <div class="form-group">
         <label>Địa điểm</label> 
         <asp:DropDownList ID="ddlDiadiem" runat="server" CssClass="form-control" ></asp:DropDownList>
     </div>
      <div class="form-group">
          <label>Tên tour</label> 
          <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvTen" runat="server" ErrorMessage="Chua nhap ten tour" Text="(*)" ControlToValidate="txtTen" ForeColor="#CC3300" ></asp:RequiredFieldValidator>
     </div>
      <div class="form-group">
          <label>Chương trình</label> 
          <asp:TextBox ID="txtChuongTrinh" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
     </div>
     <div class="form-inline">
          <label>Số ngày</label> 
          <asp:TextBox ID="txtSoNgay" runat="server" CssClass="form-control"></asp:TextBox>
         <asp:CompareValidator ID="cvSoNgay" runat="server" ErrorMessage="So ngay khong hop le" ControlToValidate="txtSoNgay" ForeColor="#CC3300" Operator="GreaterThan" Type="Integer" ValueToCompare="0">(*)</asp:CompareValidator>
          <label>Đơn giá</label> 
          <asp:TextBox ID="txtDongia" runat="server" CssClass="form-control"></asp:TextBox>
     </div>
     
     <div class="form-group">
          <label>Hình ảnh đại diện</label> 
          <asp:FileUpload ID="FHinh" runat="server" CssClass="form-control" />
     </div>
     <asp:Button ID="btXuLy" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btXuLy_Click" /> <br />

    <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="#cc3300"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" />
  

</asp:Content>
