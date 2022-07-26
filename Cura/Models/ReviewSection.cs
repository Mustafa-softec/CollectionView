using System;
using System.Collections.Generic;

namespace Cura.Models
{
    public class ReviewSection: ISection
    {
        public string Title { get; set; }
        public List<Review> Reviews { get; set; }
    }

    public class Review
    {
        public string Comment { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }

}
