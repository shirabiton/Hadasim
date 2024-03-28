using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto 
{
    public class CorornaVaccineDto
    {
        public int Id { get; set; }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value.Date >= DateTime.Today)
                {
                    _date = value;
                }
                else
                {
                    throw new ArgumentException("Date of vaccine cannot be a past date.");
                }
            }
        }
        public int ManufacturerId { get; set; }
        public int MemberId { get; set; }
    }
}
