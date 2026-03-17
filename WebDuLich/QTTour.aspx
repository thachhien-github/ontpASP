<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="QTTour.aspx.cs" Inherits="WebDuLich.QTTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>Trang quản trị tour</h2>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <div class="form-inline">
                Tên tour
                <asp:TextBox ID="txtTen" runat="server" CssClass="form-control" Width="300"></asp:TextBox>
                <asp:Button ID="btTraCuu" runat="server" Text="Tra cứu" CssClass="btn btn-primary" OnClick="btTraCuu_Click" />
            </div>
        </div>
        <div class="col-md-6 text-right">
            <a href="ThemTour.aspx" class="btn btn-success">Thêm tour mới</a>
        </div>
    </div>

    <div style="margin-top: 20px">
        <asp:GridView ID="gvTour" runat="server" AutoGenerateColumns="False"
            CssClass="table table-bordered table-hover" DataKeyNames="MaTour"
            OnRowDeleting="gvTour_RowDeleting" AllowPaging="True" PageSize="10"
            OnPageIndexChanging="gvTour_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="MaTour" HeaderText="Mã" />
                <asp:TemplateField HeaderText="Hình">
                    <ItemTemplate>
                        <img src='<%# "/Hinh_tour/" + Eval("Hinh") %>' width="80" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TenTour" HeaderText="Tên Tour" />
                <asp:BoundField DataField="Songay" HeaderText="Số ngày" />
                <asp:BoundField DataField="Dongia" HeaderText="Đơn giá" DataFormatString="{0:#,##0}đ" />
                <asp:TemplateField HeaderText="Thao tác">
                    <ItemTemplate>
                        <a href='<%# "SuaTour.aspx?MaTour=" + Eval("MaTour") %>' class="btn btn-warning btn-sm">Sửa</a>
                        <asp:LinkButton ID="btnXoa" runat="server" CommandName="Delete"
                            CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Bạn có chắc chắn muốn xóa tour này?');">Xóa</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
