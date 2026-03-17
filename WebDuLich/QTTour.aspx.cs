using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace WebDuLich
{
    public partial class QTTour : System.Web.UI.Page
    {
        // Chuỗi kết nối
        string strConn = @"Data Source=.;Initial Catalog=QlTourDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "SELECT * FROM Tour WHERE TenTour LIKE @ten";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", "%" + txtTen.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTour.DataSource = dt;
                gvTour.DataBind();
            }
        }

        protected void btTraCuu_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void gvTour_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lấy mã tour cần xóa từ DataKeyNames
            int maTour = Convert.ToInt32(gvTour.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "DELETE FROM Tour WHERE MaTour = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maTour);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu sau khi xóa thành công
                    LoadData();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu tour đang có dữ liệu liên quan ở bảng khác (khóa ngoại)
                    Response.Write("<script>alert('Không thể xóa tour này vì dữ liệu đang được sử dụng!');</script>");
                }
            }
        }

        protected void gvTour_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTour.PageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}