using System;
using System.Collections.Generic;

namespace Cura.Models
{
    public class DoctorSection : ISection
    {
        public string Title { get; set; }
        public List<Doctor> Doctors { get; set; } 
    }

    public class Doctor
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public int ReviewsCount { get; set; }
    }
}
