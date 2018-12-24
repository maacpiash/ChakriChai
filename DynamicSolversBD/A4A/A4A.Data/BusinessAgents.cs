using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace A4A.Data
{
    public partial class BusinessAgents
    {
        public long BusinessId { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string ReferredBy { get; set; }
        public string Logo { get; set; }
        public int Status { get; set; }
        public decimal Balance { get; set; }
        public string SecurityCode { get; set; }
        public string Smtpserver { get; set; }
        public int Smtpport { get; set; }
        public string Smtpusername { get; set; }
        [JsonIgnore]
        public string Smtppassword { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
