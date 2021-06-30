//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IgnacioQuinteros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Persona
    {
        // TODO: REGEX
        public string Rut { get; set; }
        [StringLength(20)]
        public string Nombres { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [Range(18, 100)]
        public Nullable<byte> Edad { get; set; }

        public string RutOnlyDigits() => String.Join("", String.Join("", Rut.Split('.')).Split('-'));
        public static string DigitsToRut(string digits)
        {
            return digits.Insert(digits.Length-1, "-");
        }

    }
}
