using EFCoreWithSwagger.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string OrderStatus { get; set; }
        public string ProductDescription { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
    }

}
