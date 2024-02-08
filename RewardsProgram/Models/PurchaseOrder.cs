using System.Xml.Serialization;

namespace RewardsProgram.Models
{

    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        public int PurchaseOrderNumber { get; set; }
        [XmlElement(ElementName = "ProductName")]
        public string ProductName { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "USPrice")]
        public int USPrice { get; set; }

        [XmlAttribute(AttributeName = "ItemNumber")]
        public string ItemNumber { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Items")]
    public class Items
    {
        public int PurchaseOrderNumber { get; set; }

        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "PurchaseOrder")]
    public class PurchaseOrder
    {

        [XmlElement(ElementName = "Items")]
        public Items Items { get; set; }

        [XmlAttribute(AttributeName = "PurchaseOrderNumber")]
        public int PurchaseOrderNumber { get; set; }

        [XmlAttribute(AttributeName = "CustomerID")]
        public int CustomerID { get; set; }

        [XmlAttribute(AttributeName = "OrderDate")]
        public DateTime OrderDate { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PurchaseOrders")]
    public class PurchaseOrders
    {

        [XmlElement(ElementName = "PurchaseOrder")]
        public List<PurchaseOrder> PurchaseOrder { get; set; }
    }


}
