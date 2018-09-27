using ASP02.Data;
using ASP02.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        [MaxLength(50)]
        public int Salary { get; set; }
        public SalaryCategories SalaryCategory { get; set; }
    }
}
