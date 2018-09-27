using ASP02.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Név")]
        public string Name { get; set; }

        [DisplayName("Munkakör")]
        public string Job { get; set; }

        [DisplayName("Fizetés")]
        public int Salary { get; set; }
        public SalaryCategories SalaryCategory { get; set; }
    }
}
