using eForm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eForm.Repository.Interface
{
    public interface IMasterDataRepository
    {
        List<MasterVendor> GetAllMasterVendor();
        List<MasterCurrency> GetAllMasterCurrency();
        List<MasterLanguage> GetAllMasterLanguage();
        List<MasterUoM> GetAllMasterUoM();
        List<PurchaseOrder> GetAllPurchaseOrder();
        MasterVendor GetAllMasterVendorByID(int ID);
        MasterCurrency GetAllMasterCurrencyByID(int ID);
        MasterLanguage GetAllMasterLanguageByID(int ID);
        MasterUoM GetAllMasterUoMByID(int ID);
        PurchaseOrder GetAllPurchaseOrderByID(string Number);
    }
}
