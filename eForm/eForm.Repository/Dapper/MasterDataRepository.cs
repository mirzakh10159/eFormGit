using Dapper;
using eForm.Model;
using eForm.Repository.Base;
using eForm.Repository.Interface;
using eForm.Repository.SQLQuery;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eForm.Repository.Dapper
{
    public class MasterDataRepository : BaseRepository, IMasterDataRepository
    {

        public MasterDataRepository(string connectionString) :
            base(connectionString)
        { }

        public MasterDataRepository(IConfiguration configuration) :
            base(configuration)
        { }

        public List<MasterCurrency> GetAllMasterCurrency()
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterCurrency>(MasterDataQuery.GetAllMasterCurrency, commandTimeout: timeout).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public MasterCurrency GetAllMasterCurrencyByID(int ID)
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterCurrency>(MasterDataQuery.GetMasterCurrencyByID, new { ID = ID }, commandTimeout: timeout).SingleOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<MasterLanguage> GetAllMasterLanguage()
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterLanguage>(MasterDataQuery.GetAllMasterLanguage, commandTimeout: timeout).ToList();
                }
            }
            catch
            {
                return null;
            }

        }

        public MasterLanguage GetAllMasterLanguageByID(int ID)
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterLanguage>(MasterDataQuery.GetMasterLanguageByID, new { ID = ID }, commandTimeout: timeout).SingleOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<MasterUoM> GetAllMasterUoM()
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterUoM>(MasterDataQuery.GetAllMasterUoM, commandTimeout: timeout).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public MasterUoM GetAllMasterUoMByID(int ID)
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterUoM>(MasterDataQuery.GetMasterUoMByID, new { ID = ID }, commandTimeout: timeout).SingleOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<MasterVendor> GetAllMasterVendor()
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterVendor>(MasterDataQuery.GetAllMasterVendor, commandTimeout: timeout).ToList();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public MasterVendor GetAllMasterVendorByID(int ID)
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<MasterVendor>(MasterDataQuery.GetMasterVendorByID, new { ID = ID }, commandTimeout: timeout).SingleOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<PurchaseOrder> GetAllPurchaseOrder()
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<PurchaseOrder>(MasterDataQuery.GetAllPurchaseOrder, commandTimeout: timeout).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public PurchaseOrder GetAllPurchaseOrderByID(string Number)
        {
            try
            {
                using (var connection = Connection)
                {
                    return connection.Query<PurchaseOrder>(MasterDataQuery.GetAllPurchaseOrderByNumber, new { PONumber = Number }, commandTimeout: timeout).SingleOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
