using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class MemberDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[\p{L}\s'-]{2,20}$", ErrorMessage = "The name must be 2-20 characters long and can contain Hebrew or English letters, spaces, apostrophes, or hyphens.")]
        public string Name { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "The Id number must contain exactly 9 digits.")]
        public string IdNumber { get; set; }
        public int CityId { get; set; }
        [RegularExpression(@"^[\p{L}\p{M}\s'-]{2,30}$", ErrorMessage = "The street name must be 2-30 characters long and can contain Hebrew or English letters, spaces, apostrophes, or hyphens.")]
        public string Street { get; set; }
        [RegularExpression(@"^(?:[1-9]|[1-9][0-9]|[1-9][0-9]{2})$", ErrorMessage = "The house number must be between 1 and 999.")]
        public int HouseNumber { get; set; }
        [RegularExpression(@"^((19|20)\d\d)-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Birth date cannot be a future date.")]
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value.Date < DateTime.Today)
                {
                    _birthDate = value;
                }
                else
                {
                    throw new ArgumentException("Birth date cannot be a future date.");
                }
            }
        }
        public string Phone { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile-phone number must contain exactly 10 digits.")]
        public string MobilePhone { get; set; }

        private DateTime? _dateOfSickness;
        private DateTime? _dateOfRecovery;

        public DateTime? DateOfSickness
        {
            get { return _dateOfSickness; }
            set
            {
                if (value.HasValue && value > DateTime.Today || value < new DateTime(2019, 1, 1))
                {
                    throw new ArgumentException("Date of sickness must be before today and after 2019.");
                }

                if (_dateOfRecovery.HasValue && value.HasValue && value > _dateOfRecovery)
                {
                    throw new ArgumentException("Date of sickness must be before the date of recovery.");
                }

                _dateOfSickness = value;
            }
        }

        public DateTime? DateOfRecovery
        {
            get { return _dateOfRecovery; }
            set
            {
                if (value.HasValue && value > DateTime.Today || value < new DateTime(2019, 1, 1))
                {
                    throw new ArgumentException("Date of recovery must be before today and after 2019.");
                }

                if (_dateOfSickness.HasValue && value.HasValue && value < _dateOfSickness)
                {
                    throw new ArgumentException("Date of recovery must be after the date of sickness.");
                }
                if (value.HasValue && !_dateOfSickness.HasValue)
                {
                    throw new ArgumentException("Date of recovery must full just when date of sickness if full too.");
                }

                _dateOfRecovery = value;
            }
        }




    }
}
