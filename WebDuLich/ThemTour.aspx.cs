using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebDuLich
{
    public partial class ThemTour : System.Web.UI.Page
    {
        // Chuỗi kết nối tới database
        string strConn = @"Data Source=.;Initial Catalog=QlTourDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiaDiem();
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

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string tenHinh = "no_image.jpg"; // Giá trị mặc định nếu không upload ảnh

                    // 1. Xử lý Upload hình ảnh
                    if (FHinh.HasFile)
                    {
                        // Lấy tên file và lưu vào thư mục Hinh_tour
                        tenHinh = Path.GetFileName(FHinh.FileName);
                        string path = Server.MapPath("~/Hinh_tour/") + tenHinh;
                        FHinh.SaveAs(path);
                    }

                    // 2. Lưu vào Database
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        string sql = "INSERT INTO Tour (TenTour, ChuongTrinh, Songay, Dongia, MDD, Hinh) " +
                                     "VALUES (@ten, @ct, @ngay, @gia, @mdd, @hinh)";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                        cmd.Parameters.AddWithValue("@ct", txtChuongTrinh.Text);
                        cmd.Parameters.AddWithValue("@ngay", txtSoNgay.Text);
                        cmd.Parameters.AddWithValue("@gia", txtDongia.Text);
                        cmd.Parameters.AddWithValue("@mdd", ddlDiadiem.SelectedValue);
                        cmd.Parameters.AddWithValue("@hinh", tenHinh);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        // Thông báo thành công và chuyển hướng
                        lbThongBao.Text = "Thêm tour mới thành công!";
                        lbThongBao.ForeColor = System.Drawing.Color.Blue;

                        // Tùy chọn: Chuyển về trang quản lý sau 2 giây
                        Response.AddHeader("REFRESH", "2;URL=QTTour.aspx");
                    }
                }
                catch (Exception ex)
                {
                    lbThongBao.Text = "Lỗi: " + ex.Message;
                }
            }
        }
    }
}