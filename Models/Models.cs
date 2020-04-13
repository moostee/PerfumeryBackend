using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PerfumeResponse 
    {
        public string requestId { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public Task<List<PerfumeModel>> PerfumeModel{ get; set; }
    }
    public class PerfumeModel
    {
        public string name { get; set; }
        public float price { get; set; }
        public string make { get; set; }
        public string description { get; set; }
        public string  picture { get; set; }
        public Gender gender { get; set; }
        public int quantity { get; set; }
        public float subTotal { get; set; }
    }

    public enum Gender
    {
         male,
         female
    }
}
