﻿using System.ComponentModel.DataAnnotations;

namespace CadastroNumeros.Domain.Validation;
public class DddValidationAttribute : ValidationAttribute
{
    public static readonly HashSet<int> DDDsValidos = new HashSet<int>
        {
            11, 12, 13, 14, 15, 16, 17, 18, 19,
            21, 22, 24, 27, 28,
            31, 32, 33, 34, 35, 37, 38,
            41, 42, 43, 44, 45, 46, 47, 48, 49,
            51, 53, 54, 55,
            61, 62, 63, 64, 65, 66, 67, 68, 69,
            71, 73, 74, 75, 77, 79,
            81, 82, 83, 84, 85, 86, 87, 88, 89,
            91, 92, 93, 94, 95, 96, 97, 98, 99
        };

    public override bool IsValid(object value)
    {
       if (value is int intValue || (value is string stringValue && int.TryParse(stringValue, out intValue)))
         return DDDsValidos.Contains(intValue);

       return false;
    }
}
