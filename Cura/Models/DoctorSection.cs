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

    }
}
