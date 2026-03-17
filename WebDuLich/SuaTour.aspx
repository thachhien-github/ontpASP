<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="SuaTour.aspx.cs" Inherits="WebDuLich.SuaTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>Trang chỉnh sửa thông tin tour</h2>
    <hr />

    <div class="form-group">
        <label>Địa điểm</label>
        <asp:DropDownList ID="ddlDiadiem" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Tên tour</label>
        <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTen" runat="server" ErrorMessage="Chưa nhập tên tour" Text="(*)" ControlToValidate="txtTen" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label>Chương trình</label>
        <asp:TextBox ID="txtChuongTrinh" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
    </div>
    <div class="form-inline mb-3">
        <label>Số ngày</label>
        &nbsp;
        <asp:TextBox ID="txtSoNgay" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
        &nbsp;
        <asp:CompareValidator ID="cvSoNgay" runat="server" ErrorMessage="Số ngày không hợp lệ" ControlToValidate="txtSoNgay" ForeColor="#CC3300" Operator="GreaterThan" Type="Integer" ValueToCompare="0">(*)</asp:CompareValidator>

        <label class="ml-3">Đơn giá</label>
        &nbsp;
        <asp:TextBox ID="txtDongia" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Hình ảnh hiện tại</label>
        <br />
        <asp:Image ID="imgHienTai" runat="server" Width="150px" CssClass="img-thumbnail" />
        <asp:HiddenField ID="hfHinhCu" runat="server" />
        <br />
        <br />
        <label>Thay đổi hình ảnh (nếu cần)</label>
        <asp:FileUpload ID="FHinh" runat="server" CssClass="form-control" />
    </div>

    <asp:Button ID="btCapNhat" runat="server" Text="Cập nhật" CssClass="btn btn-warning" OnClick="btCapNhat_Click" />
    <a href="QTTour.aspx" class="btn btn-secondary">Quay lại</a>
    <br />

    <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="#cc3300"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" />
</asp:Content>
