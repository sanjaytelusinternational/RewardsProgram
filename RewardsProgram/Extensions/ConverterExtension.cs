using Microsoft.AspNetCore.Hosting.Server;
using System.Data;

namespace RewardsProgram.Extensions
{
    public class ConverterExtension
    {
        //protected DataSet ConvertXMLtoDataSet(string FilePath)
        //{
        //    DataSet objDataSet;
        //    string strFileName = string.Empty;
        //    try
        //    {
        //        strFileName = Server.MapPath("Student.xml");
        //        objDataSet = new DataSet();
        //        objDataSet.ReadXml(strFileName);
        //        //Grddata.DataSource = objDataSet;
        //        //Grddata.DataBind();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //    return objDataSet;
        //}

        //public static string MapPath(string path)
        //{
        //    var contentRootPath = (string)AppDomain.CurrentDomain.GetData("ContentRootPath");
        //    var webRootPath = (string)AppDomain.CurrentDomain.GetData("WebRootPath");
        //    return Path.Combine((string)AppDomain.CurrentDomain.GetData("ContentRootPath"),path);
        //}
    }
}
