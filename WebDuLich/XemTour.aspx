<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="XemTour.aspx.cs" Inherits="WebDuLich.XemTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2 class="text-center">Trang xem tour</h2>
    <hr />

    <div class="form-inline justify-content-center mb-4">
        Chọn địa điểm: &nbsp;
        <asp:DropDownList ID="ddlDiadiem" runat="server"
            CssClass="form-control" AutoPostBack="True"
            DataTextField="TenDiaDiem" DataValueField="MDD"
            OnSelectedIndexChanged="ddlDiadiem_SelectedIndexChanged">
        </asp:DropDownList>
    </div>

    <div class="row">
        <asp:Repeater ID="rptTour" runat="server">
            <ItemTemplate>
                <div class="col-md-4 text-center mb-4">
                    <div class="card p-3 shadow-sm">
                        <img src='<%# "/Hinh_tour/" + Eval("Hinh") %>' style="width: 100%; height: 200px; object-fit: cover;" class="img-thumbnail" />
                        <br />
                        <h5 class="mt-2">
                            <asp:Label ID="lbTen" runat="server" Text='<%# Eval("TenTour") %>' Font-Bold="true"></asp:Label>
                        </h5>
                        Giá tour: 
                        <asp:Label ID="lbGia" runat="server" ForeColor="#ff6600" Text='<%# Eval("Dongia", "{0:#,##0}đ") %>'></asp:Label>
                        <br />
                        Số ngày:
                        <asp:Label ID="lbSoNgay" runat="server" ForeColor="#ff6600" Text='<%# Eval("Songay") %>'></asp:Label>
                        - Số đêm:
                        <asp:Label ID="lbSoDem" runat="server" ForeColor="#ff6600"
                            Text='<%# Convert.ToInt32(Eval("Songay")) - 1 %>'>
                        </asp:Label>
                        <br />
                        <div class="mt-2">
                            <a href='<%# "DatTour.aspx?MaTour=" + Eval("MaTour") %>' class="btn btn-primary btn-sm">Đặt tour</a>
                            <a href='<%# "ChiTietTour.aspx?MaTour=" + Eval("MaTour") %>' class="btn btn-success btn-sm">Xem chi tiết</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
