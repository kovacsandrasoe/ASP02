using ASP02.Data;
using ASP02.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASP02.Models
{
    public enum SalaryCategories
    {
        Low, Middle, High
    }

    [ModelBinder(BinderType = typeof(WorkerModelBinder))]
    public class WorkerModel
    {
        [Required(ErrorMessage = "Ez a mező kötelező")]
        [NamePieceValidation]
        [DisplayName("Név")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ez a mező kötelező")]
        [DisplayName("Munkakör")]
        [MaxLength(50)]
        public string Job { get; set; }

        [Required(ErrorMessage = "Ez a mező kötelező")]
        [Range(100000, 900000, ErrorMessage = "100e és 900e közötti érték lehet")]
        [DisplayName("Fizetés")]
        public int Salary { get; set; }
        public SalaryCategories SalaryCategory { get; set; }

        public string Alias
        {
            get
            {
                MD5 hashcreator = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(this.Name);
                byte[] hash = hashcreator.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
