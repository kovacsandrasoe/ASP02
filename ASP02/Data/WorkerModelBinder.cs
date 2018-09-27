using ASP02.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP02.Data
{
    public class WorkerModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext ==null)
            {
                throw new ArgumentException(nameof(bindingContext));
            }

            var name = bindingContext.ValueProvider.GetValue("name");
            var job = bindingContext.ValueProvider.GetValue("job");
            var salary = bindingContext.ValueProvider.GetValue("salary");

            WorkerModel model = new WorkerModel()
            {
                Name = name.FirstValue,
                Job = job.FirstValue,
                Salary = int.Parse(salary.FirstValue)
            };

            if (model.Salary < 300000)
            {
                model.SalaryCategory = SalaryCategories.Low;
            }
            else if (model.Salary < 600000)
            {
                model.SalaryCategory = SalaryCategories.Middle;
            }
            else
            {
                model.SalaryCategory = SalaryCategories.High;
            }

            bindingContext.Result = 
                ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }
    }
}
