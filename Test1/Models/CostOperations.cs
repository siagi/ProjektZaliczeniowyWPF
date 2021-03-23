using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class CostOperations
    {
        Database1Entities db;

        public CostOperations()
        {
            db = new Database1Entities();
        }

        #region Get All Costs

        public List<Cost> GetAllCosts()
        {
            List<Cost> CostsList = new List<Cost>();
            try
            {
                var getCost = from cost in db.Costs
                              select cost;
                foreach (var cost in getCost)
                {
                    CostsList.Add(new Cost() {Id = cost.Id, InvoiceNr = cost.InvoiceNr, PurchaseDate = cost.PurchaseDate, Description = cost.Description, CostType = cost.CostType, Supplier = cost.Supplier, SupplierId = cost.SupplierId, OrderId = cost.OrderId, ValueNetto = cost.ValueNetto });
                }

                return CostsList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        #endregion

        #region Add cost

        public bool AddCost(Cost cost)
        {

            bool isAdded = false;

            try
            {
                Cost newCost = new Cost()
                {
                    InvoiceNr = cost.InvoiceNr,
                    PurchaseDate = cost.PurchaseDate,
                    Description = cost.Description,
                    CostType = cost.CostType,
                    Supplier = cost.Supplier,
                    SupplierId = cost.SupplierId,
                    OrderId = cost.OrderId,
                    ValueNetto = cost.ValueNetto,
                    
                };
                db.Costs.Add(newCost);
                var rowEffected = db.SaveChanges();
                isAdded = rowEffected > 0;
                return isAdded;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region Search cost

        public Cost SearchCost(int id)
        {
            Cost cost = null;
            Cost searchingCost = db.Costs.Find(id);

            cost = new Cost()
            {
                InvoiceNr = searchingCost.InvoiceNr,
                PurchaseDate = searchingCost.PurchaseDate,
                Description = searchingCost.Description,
                CostType = searchingCost.CostType,
                Supplier = searchingCost.Supplier,
                SupplierId = searchingCost.SupplierId,
                OrderId = searchingCost.OrderId,
                ValueNetto = searchingCost.ValueNetto,

            };

            return cost;
            
        }

        #endregion

        #region Update Cost

        public bool UpdateCost(Cost costToUpdate)
        {
            bool isUpdated = false;
            try
            {

                Cost cost = db.Costs.Find(costToUpdate.Id);
                cost.InvoiceNr = costToUpdate.InvoiceNr;
                cost.PurchaseDate = costToUpdate.PurchaseDate;
                cost.Description = costToUpdate.Description;
                cost.CostType = costToUpdate.CostType;
                cost.Supplier = costToUpdate.Supplier;
                cost.SupplierId = costToUpdate.SupplierId;
                cost.OrderId = costToUpdate.OrderId;
                cost.ValueNetto = costToUpdate.ValueNetto;

                var rowEffected = db.SaveChanges();
                isUpdated = rowEffected > 0;
                return isUpdated;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Delete cost

        public bool DeleteCost(int id)
        {
            bool isDeleted = false;
            try
            {

                Cost costToDelete = db.Costs.Find(id);
                db.Costs.Remove(costToDelete);
                var rowEffected = db.SaveChanges();
                isDeleted = rowEffected > 0;
                return isDeleted;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

    }
}
