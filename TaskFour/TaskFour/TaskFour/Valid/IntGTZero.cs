﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace TaskFour.Valid
{
    public class IntGTZero : ValidationRule
    {
        public string Error { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int i))
            {
                if (i > 0)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    Error = "Value must be greater than 0";
                    return new ValidationResult(false, Error);
                }
            }
            Error = "Value must be a correct number";

            return new ValidationResult(false, Error);
        }
    }
}