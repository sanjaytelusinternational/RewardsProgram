using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RewardsProgram.Models;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RewardsProgram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            DataSet objDataSet;
            string strFileName = string.Empty;
            strFileName = _hostingEnvironment.WebRootPath + "\\CustomerItemData.xml";
            objDataSet = new DataSet();
            objDataSet.ReadXml(strFileName);
            var myData = objDataSet.Tables[0].AsEnumerable().Select(r => new
            {
                //pu = r.Field<int>("PurchaseOrder_Id"),
                PurchaseOrderNumber = r.Field<string>("PurchaseOrderNumber"),
                CustomerID = r.Field<string>("CustomerId"),
                OrderDate = r.Field<string>("OrderDate"),

            });
            var itemList = myData.ToList();
            //Grddata.DataSource = objDataSet;
            //Grddata.DataBind();

            XDocument xdoc1 = XDocument.Load(strFileName);

            PurchaseOrders purchaseOrders;

            using (StreamReader reader = new StreamReader(strFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrders));
                purchaseOrders = (PurchaseOrders)serializer.Deserialize(reader);
            }
            var lstorder = purchaseOrders.PurchaseOrder;



            List<ItemList> lstItem = new List<ItemList>();

            foreach (var _item in lstorder)
            {
                var totalReward = 0;
                var totalCost = (from d in _item.Items.Item
                                 group d by _item.PurchaseOrderNumber//d.PurchaseOrderNumber
                                into g
                                 select g.Sum(x => x.Quantity * x.USPrice)).Single(); //new { Sum = g.Sum(x => x.Quantity * x.USPrice) };

                var firstReward = 0;
                var secondReward = 0;
                if (Convert.ToInt32(totalCost) > 100)
                {
                    firstReward = ((Convert.ToInt32(totalCost) - 100) * 2);
                    secondReward = (((Convert.ToInt32(totalCost) - ((Convert.ToInt32(totalCost) - 100))) - 50) * 1);
                    totalReward = firstReward + secondReward;
                }
                else
                {
                    totalReward = firstReward + (Convert.ToInt32(totalCost) - 50) * 1;
                }
                if (totalReward < 0)
                    totalReward = 0;
                lstItem.Add(new ItemList()
                {
                    CustomerId = _item.CustomerID,
                    PurchaseDate = _item.OrderDate,
                    TotalUSPrice = Convert.ToDecimal(totalCost),
                    RewardPoints = totalReward,
                });
            }
            ItemModel model = new ItemModel(); ;
            model.ListItems = lstItem;

            return View(lstItem);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}