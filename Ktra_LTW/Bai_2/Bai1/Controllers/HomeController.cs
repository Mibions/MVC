using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Bai1.Models;

namespace Bai1.Controllers
{
    //
    public class HomeController : Controller
    {
        private string conStr = @"Data Source=PIOTISK\SQLEXPRESS_19;Initial Catalog=QL_DTDD1;User ID=sa;Password=Clmm!@#$";
        private SqlConnection con;
        private void connection()
        {
            con = new SqlConnection(conStr);
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Show_Employee()
        {
            List<Models.Employee> listEmployee = new List<Models.Employee>();
            //// Cách 1 sử dụng dễ dàng với dữ liệu đơn giản
            connection();
            con.Open();
            using (var command = con.CreateCommand())
            {
                command.CommandText = "Select * From SanPham";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var emp = new Employee();
                    emp.masp = (int)reader["MaSP"];
                    emp.tensp = reader["TenSP"].ToString();
                    emp.duongdan = reader["DuongDan"].ToString();
                    emp.gia = (double)reader["Gia"];
                    emp.mota = reader["MoTa"].ToString();
                    emp.maloai = (int)reader["MaLoai"];
                    listEmployee.Add(emp);
                }
            }
            //// Cách 2 sử dụng khi đòi hỏi phải thao tác và xử lý dữ liệu từ bảng nên dùng Datatable
            //using (SqlConnection connect = new SqlConnection())
            //{
            //    connect.ConnectionString = conStr;
            //    string sql = "Select * from SanPham";
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            //    da.Fill(dt);
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        var emp = new Employee();
            //        emp.masp = (int)row["MaSP"];
            //        emp.tensp = row["TenSP"].ToString();
            //        emp.duongdan = row["DuongDan"].ToString();
            //        emp.gia = (double)row["Gia"];
            //        emp.mota = row["MoTa"].ToString();
            //        emp.maloai = (int)row["MaSP"];
            //        listEmployee.Add(emp);
            //    }
            //}
            return View(listEmployee);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Employee(Employee obj)
        {
                connection();
                con.Open();
                string insertQuery = "SET IDENTITY_INSERT SanPham ON; INSERT INTO SanPham (MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai) VALUES (@MaSP, @TenSP, @DuongDan, @Gia, @MoTa, @MaLoai)";
                using (SqlCommand command = new SqlCommand(insertQuery, con))
                {
                    command.Parameters.AddWithValue("@MaSP", obj.masp);
                    command.Parameters.AddWithValue("@TenSP", obj.tensp);
                    command.Parameters.AddWithValue("@DuongDan", obj.duongdan);
                    command.Parameters.AddWithValue("@Gia", obj.gia);
                    command.Parameters.AddWithValue("@MoTa", obj.mota);
                    command.Parameters.AddWithValue("@MaLoai", obj.maloai);
                    command.ExecuteNonQuery();
                }
                con.Close();
                return RedirectToAction("AddEmployee","Home");
        }

    }
}      