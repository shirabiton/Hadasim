using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[\p{L}\p{M}\s'-]{2,30}$", ErrorMessage = "The city name must be 2-30 characters long and can contain Hebrew or English letters, spaces, apostrophes, or hyphens.")]
        public string Name { get; set; }
    }
}
