﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fantastic.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d > DateTime.Now;

        }
    }
    public class NewLeague
    {
        [Required]
        [Display(Name = "League Name")]
        public string Name { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Temporal Paradox: Unable to create a past league.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Temporal Paradox: League may not end in the past.")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "Match Duration")]
        public int Duration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(End <= Start)
            {
                yield return new ValidationResult("Temporal Paradox: Cannot end before the beginning!", new[] { "Start", "End" });
            }
        }
    }
}
