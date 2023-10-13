using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_1.Models;


namespace Bai_1.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Login()
        {
            Register user = (Register)Session["user"];
            return View(user);
        }

        public ActionResult Register()
        {
            List<SelectListItem> loaiHinhList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Đơn Vị Sự Ngiệp Nhà Nước" },
                new SelectListItem { Text = "Đơn Vị Hút Hầm Cầu" },
                new SelectListItem { Text = "Đơn Vị Sửa Máy Lạnh" },
                new SelectListItem { Text = "Dơn Vị Thu Gom Rác" }
            };
            ViewBag.LoaiHinhList = loaiHinhList;
            Models.Register rg = new Register();
            return View(rg);
        }

        [HttpPost]
        public ActionResult Register(Register rg)
        {
            Session["user"] = new Register()
            {
                Ten_Don_Vi_Tuyen = rg.Ten_Don_Vi_Tuyen,
                So_Luong_Nhan_Vien = rg.So_Luong_Nhan_Vien,
                Loai_Hinh_Doanh_Nghiep = rg.Loai_Hinh_Doanh_Nghiep,
                Dia_Chi = rg.Dia_Chi,
                Nguoi_Lien_He = rg.Nguoi_Lien_He,
                So_Dien_Thoai = rg.So_Dien_Thoai,
                So_Fax = rg.So_Fax,
                Email = rg.Email,
                Dia_Chi_Website = rg.Dia_Chi_Website,
                Ten_Dang_Nhap = rg.Ten_Dang_Nhap,
                Mat_Khau = rg.Mat_Khau,
                Xac_Nhan_Mat_Khau = rg.Xac_Nhan_Mat_Khau,
                Nhan_Thu_Dien_Tu = rg.Nhan_Thu_Dien_Tu,
            };

            return RedirectToAction("Login", "Home");
        }

    }
}