<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="XemTour.aspx.cs" Inherits="WebDuLich.XemTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>Trang xem tour</h2>
    <hr />
  
    <div class="form-inline justify-content-center">
                Chọn địa điểm
                <asp:DropDownList ID="ddlDiadiem" runat="server"
                    CssClass="form-control" AutoPostBack="True">
                </asp:DropDownList>
    </div>
    

    <div class="row" style="margin-top: 10px">
       
                <div class="col-md-4 text-center">
                    <img src="/Hinh_tour/BMT_01.jpg" style="width: 250px" />
                    <br />
                    <asp:Label ID="lbTen" runat="server" Text='<%# Eval("TenTour") %>'></asp:Label>  <br />
                    Giá tour 
                    <asp:Label ID="lbGia" runat="server" ForeColor="#ff6600" Text='0.00đ'></asp:Label>  <br />
                    Số ngày  <asp:Label ID="lbSoNgay" runat="server" ForeColor="#ff6600" Text='2'></asp:Label>
                    Số đêm   <asp:Label ID="lbSoDem" runat="server" ForeColor="#ff6600" Text='1'></asp:Label>
                    <br />
                    <a href="DatTour.aspx?MaTour=<%# Eval("MaTour") %>" class="btn btn-primary">Đặt tour</a>
                    <a href="ChiTietTour.aspx?MaTour=<%# Eval("MaTour") %>" class="btn btn-success">Xem chi tiết</a>
                </div>
       
    </div>

     

</asp:Content>
