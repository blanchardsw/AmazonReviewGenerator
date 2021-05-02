using System;
using System.Runtime.Serialization;

namespace Amazon_Review_Generator.Models
{
    // Simple data contract for modeling each review to ensure data integrity.
    [DataContract]
    public class Review
    {
        [DataMember]
        public string reviewerID;

        [DataMember]
        public string asin;

        [DataMember]
        public string reviewerName;

        [DataMember]
        public int[] helpful;

        [DataMember]
        public string reviewText;

        [DataMember]
        public decimal overall;

        [DataMember]
        public string summary;

        [DataMember]
        public double unixReviewTime;

        [DataMember]
        public DateTime reviewTime;
    }
}
