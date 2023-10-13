using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai_1.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Không được để trống !")]
        public string Ten_Don_Vi_Tuyen { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        public string Loai_Hinh_Doanh_Nghiep { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập giá trị số từ 0 -> 9 !")]
        public int So_Luong_Nhan_Vien { get; set; }

        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "Không được để trống !")]
        public string Dia_Chi { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        public string Nguoi_Lien_He { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập giá trị số từ 0 -> 9 !")]
        public string So_Dien_Thoai { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập giá trị số từ 0 -> 9 !")]
        public string So_Fax { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Vui Lòng nhập đúng định dạng example@gmai.com !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        public string Dia_Chi_Website { get; set; }

        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "Không được để trống !")]
        public string Ten_Dang_Nhap { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        [RegularExpression(".{6,}", ErrorMessage = "Tối thiểu 6 ký tự !")]
        [DataType(DataType.Password)]
        public string Mat_Khau { get; set; }

        [Required(ErrorMessage = "Không được để trống !")]
        [DataType(DataType.Password)]
        [Compare("Mat_Khau")]
        public string Xac_Nhan_Mat_Khau { get; set; }

        //-----------------------------------------------------------------------------
        [Required(ErrorMessage = "Không được để trống !")]
        public string Nhan_Thu_Dien_Tu { get; set; }

        public Register()
        {
            Ten_Don_Vi_Tuyen = "";
            Loai_Hinh_Doanh_Nghiep = "";
            So_Luong_Nhan_Vien = 0;
            Dia_Chi = "";
            Nguoi_Lien_He = "";
            So_Fax = "";
            Email = "";
            Dia_Chi_Website = "";
            Ten_Dang_Nhap = "";
            Mat_Khau = "";
            Xac_Nhan_Mat_Khau = "";
            Nhan_Thu_Dien_Tu = "";
        }
    }
}