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

    }

}
