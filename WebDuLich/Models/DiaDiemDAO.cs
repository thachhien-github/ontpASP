using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebDuLich.Models
{
    public class DiaDiemDAO : DataProvider
    {
        public List<DiaDiem> getAll()
        {
            List<DiaDiem> ds = new List<DiaDiem>();
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from diadiem", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
               ds.Add(new DiaDiem { MDD = int.Parse(rd["mdd"].ToString()), TenDiaDiem = rd["tendiadiem"].ToString()});
            }
            return ds;
        }
    }
}