using StokEkstresi.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StokEkstresi.Models.EntityLayer
{
    public class StockDTO : DataAccess
    {
        #region Properties

        public int Id { get; set; }
        public string ProcessType { get; set; }
        public string DocumentNo { get; set; }
        public string Date { get; set; }
        public double EntryQuantity { get; set; }
        public double OutputQuantity { get; set; }
        public double Stock { get; set; }


        #endregion

        #region Method
        public static List<StockDTO> GetListStock(string Code, int StartDate, int FinishDate)
        {
            List<StockDTO> list = new List<StockDTO>();
            using (DataTable dt = DAL.GetStockList(Code, StartDate, FinishDate))
            {
                
                foreach (DataRow row in dt.Rows)
                {
                    StockDTO stock = new StockDTO();
                    {
                        stock.Id = row.Field<int>("ID");
                        stock.ProcessType = row.Field<string>("ProcessType");
                        stock.DocumentNo = row.Field<string>("DocumentNo");
                        stock.Date = row.Field<string>("Date");
                        stock.EntryQuantity = Convert.ToDouble(row["EntryQuantity"]);
                        stock.OutputQuantity = Convert.ToDouble(row["OutputQuantity"]);
                        stock.Stock = (Convert.ToDouble(row["EntryQuantity"]) - Convert.ToDouble(row["OutputQuantity"]));

                    }
                    list.Add(stock);
                }
             
            }
            return list;
        }
        #endregion

    }

    public partial class DataAccessLayer
    {
        public DataTable GetStockList(string pCode, int pStartDate, int pFinishDate)
        {
            return DatabaseContext.ExecuteReader(CommandType.StoredProcedure, "Get_Stock", MethodBase.GetCurrentMethod().GetParameters(), new object[] { pCode, pStartDate, pFinishDate });
        }

    }
}