using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP02.Validation
{
    public class NamePieceValidationAttribute
        : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string ertek =  value as string;
            return ertek.Split(' ').Length == 2;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Csak vezetéknév és keresztnév lehet!";
        }
    }
}
