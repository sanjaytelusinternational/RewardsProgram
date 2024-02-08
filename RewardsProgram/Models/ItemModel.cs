using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace RewardsProgram.Models
{
    public class ItemModel
    {       
        public List<ItemList>? ListItems { get; set; }
    }

    public class ItemList
    {
        public int CustomerId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalUSPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int RewardPoints { get; set; }
    }

    

}
