using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebDuLich
{
    public partial class SuaTour : System.Web.UI.Page
    {
        string strConn = @"Data Source=.;Initial Catalog=QlTourDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiaDiem();
                LoadThongTinTour();
            }
        }

        private void LoadDiaDiem()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DiaDiem", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlDiadiem.DataSource = dt;
                ddlDiadiem.DataTextField = "TenDiaDiem";
                ddlDiadiem.DataValueField = "MDD";
                ddlDiadiem.DataBind();
            }
        }

        private void LoadThongTinTour()
        {
            string maTour = Request.QueryString["MaTour"];
            if (string.IsNullOrEmpty(maTour)) Response.Redirect("QTTour.aspx");

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "SELECT * FROM Tour WHERE MaTour = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maTour);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtTen.Text = dr["TenTour"].ToString();
                    txtChuongTrinh.Text = dr["ChuongTrinh"].ToString();
                    txtSoNgay.Text = dr["Songay"].ToString();
                    txtDongia.Text = dr["Dongia"].ToString();
                    ddlDiadiem.SelectedValue = dr["MDD"].ToString();

                    // Hiển thị ảnh cũ
                    string hinh = dr["Hinh"].ToString();
                    imgHienTai.ImageUrl = "~/Hinh_tour/" + hinh;
                    hfHinhCu.Value = hinh; // Lưu tên ảnh cũ vào HiddenField
                }
            }
        }

        protected void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string tenHinh = hfHinhCu.Value; // Mặc định lấy lại tên ảnh cũ

                // Nếu người dùng chọn ảnh mới
                if (FHinh.HasFile)
                {
                    tenHinh = Path.GetFileName(FHinh.FileName);
                    FHinh.SaveAs(Server.MapPath("~/Hinh_tour/") + tenHinh);
                }

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    string sql = "UPDATE Tour SET TenTour=@ten, ChuongTrinh=@ct, Songay=@ngay, " +
                                 "Dongia=@gia, MDD=@mdd, Hinh=@hinh WHERE MaTour=@ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                    cmd.Parameters.AddWithValue("@ct", txtChuongTrinh.Text);
                    cmd.Parameters.AddWithValue("@ngay", txtSoNgay.Text);
                    cmd.Parameters.AddWithValue("@gia", txtDongia.Text);
                    cmd.Parameters.AddWithValue("@mdd", ddlDiadiem.SelectedValue);
                    cmd.Parameters.AddWithValue("@hinh", tenHinh);
                    cmd.Parameters.AddWithValue("@ma", Request.QueryString["MaTour"]);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("QTTour.aspx");

                    // Tùy chọn: Chuyển về trang quản lý sau 2 giây
                    Response.AddHeader("REFRESH", "2;URL=QTTour.aspx");
                }
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Lỗi cập nhật: " + ex.Message;
            }
        }
    }
}