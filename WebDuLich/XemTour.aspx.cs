using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebDuLich
{
    public partial class XemTour : System.Web.UI.Page
    {
        // Chuỗi kết nối (Thay đổi tùy theo máy của bạn)
        string strConn = @"Data Source=.;Initial Catalog=QlTourDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiaDiem();
                LoadTour();
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
                ddlDiadiem.DataBind();

                // Thêm một tùy chọn mặc định
                ddlDiadiem.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--- Tất cả địa điểm ---", "0"));
            }
        }

        private void LoadTour()
        {
            int mdd = int.Parse(ddlDiadiem.SelectedValue);
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "SELECT * FROM Tour";
                if (mdd > 0)
                {
                    sql += " WHERE MDD = @mdd";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (mdd > 0) cmd.Parameters.AddWithValue("@mdd", mdd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptTour.DataSource = dt;
                rptTour.DataBind();
            }
        }

        protected void ddlDiadiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTour();
        }
    }
}