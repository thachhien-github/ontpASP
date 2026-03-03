using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebDuLich.Models
{
    public class TourDAO : DataProvider
    {
        public List<Tour> getAll()
        {
            List<Tour> ds = new List<Tour>();
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Tour", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Tour tour = new Tour {
                    MaTour = int.Parse(rd["matour"].ToString()),
                    TenTour = rd["tentour"].ToString(),
                    ChuongTrinh = rd["chuongtrinh"].ToString(),
                    SoNgay = int.Parse(rd["songay"].ToString()),
                    Dongia = int.Parse(rd["dongia"].ToString()),
                    MDD = int.Parse(rd["mdd"].ToString()),
                    Hinh = rd["hinh"].ToString()
                }; 
                ds.Add(tour);
            }
            return ds;
        }

        public List<Tour> getByDiaDiem(int mdd)
        {
            List<Tour> ds = new List<Tour>();
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Tour where mdd=@mdd", conn);
            cmd.Parameters.AddWithValue("@mdd", mdd);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Tour tour = new Tour
                {
                    MaTour = int.Parse(rd["matour"].ToString()),
                    TenTour = rd["tentour"].ToString(),
                    ChuongTrinh = rd["chuongtrinh"].ToString(),
                    SoNgay = int.Parse(rd["songay"].ToString()),
                    Dongia = int.Parse(rd["dongia"].ToString()),
                    MDD = int.Parse(rd["mdd"].ToString()),
                    Hinh = rd["hinh"].ToString()
                };
                ds.Add(tour);
            }
            return ds;
        }

        public List<Tour> getTheoTen(string tentour)
        {
            List<Tour> ds = new List<Tour>();
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Tour where tentour like @tentour", conn);
            cmd.Parameters.AddWithValue("@tentour", "%" + tentour + "%");
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Tour tour = new Tour
                {
                    MaTour = int.Parse(rd["matour"].ToString()),
                    TenTour = rd["tentour"].ToString(),
                    ChuongTrinh = rd["chuongtrinh"].ToString(),
                    SoNgay = int.Parse(rd["songay"].ToString()),
                    Dongia = int.Parse(rd["dongia"].ToString()),
                    MDD = int.Parse(rd["mdd"].ToString()),
                    Hinh = rd["hinh"].ToString()
                };
                ds.Add(tour);
            }
            return ds;
        }

        public int Update(Tour item)
        {
            try
            {
                SqlConnection conn = getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("update tour set dongia=@dongia, songay=@songay where matour=@matour", conn);               
                cmd.Parameters.AddWithValue("@matour", item.MaTour);
                cmd.Parameters.AddWithValue("@dongia", item.Dongia);
                cmd.Parameters.AddWithValue("@songay", item.SoNgay);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete(Tour item)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from tour where matour=@matour", conn);
            cmd.Parameters.AddWithValue("@matour", item.MaTour);
            return cmd.ExecuteNonQuery();
        }
        public int Insert(Tour item)
        {
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Tour(tentour,chuongtrinh,songay," +
                "dongia,mdd,hinh) values(@tentour,@chuongtrinh,@songay,@dongia,@mdd,@hinh)", conn);
            cmd.Parameters.AddWithValue("@tentour", item.TenTour);
            cmd.Parameters.AddWithValue("@chuongtrinh", item.ChuongTrinh);
            cmd.Parameters.AddWithValue("@songay", item.SoNgay);
            cmd.Parameters.AddWithValue("@dongia", item.Dongia);
            cmd.Parameters.AddWithValue("@mdd", item.MDD);
            cmd.Parameters.AddWithValue("@hinh", item.Hinh);
            return cmd.ExecuteNonQuery();
        }
       
    }
}