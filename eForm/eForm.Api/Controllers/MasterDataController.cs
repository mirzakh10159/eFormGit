using eForm.Api.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eForm.Repository;
using eForm.Repository.Interface;
using eForm.Model;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace eForm.Api.Controllers
{
    public class MasterDataController : BaseController
    {
        private readonly IMasterDataRepository _repo;
        public MasterDataController(IMasterDataRepository repo, BaseControllerConfiguration config)
            : base(config)
        {
            _repo = repo;
        }

        [Route("masterdata/GetAllMasterVendor")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterVendor()
        {
            List<MasterVendor> masterVendor = new List<MasterVendor>();
            masterVendor = _repo.GetAllMasterVendor();
            return new OkObjectResult(masterVendor);
        }

        [Route("masterdata/GetAllMasterVendorByID")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterVendorByID(int ID)
        {
            MasterVendor masterVendor = new MasterVendor();
            masterVendor = _repo.GetAllMasterVendorByID(ID);
            return new OkObjectResult(masterVendor);
        }


        [Route("masterdata/GetAllMasterCurrency")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterCurrency()
        {
            List<MasterCurrency> masterCurrency = new List<MasterCurrency>();
            masterCurrency = _repo.GetAllMasterCurrency();
            return new OkObjectResult(masterCurrency);
        }

        [Route("masterdata/GetAllMasterCurrencyByID")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterCurrencyByID(int ID)
        {
            MasterCurrency masterCurrency = new MasterCurrency();
            masterCurrency = _repo.GetAllMasterCurrencyByID(ID);
            return new OkObjectResult(masterCurrency);
        }

        [Route("masterdata/GetAllMasterLanguage")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterLanguage()
        {
            List<MasterLanguage> masterLanguage = new List<MasterLanguage>();
            masterLanguage = _repo.GetAllMasterLanguage();
            return new OkObjectResult(masterLanguage);
        }

        [Route("masterdata/GetAllMasterLanguageByID")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterLanguageByID(int ID)
        {
            MasterLanguage masterLanguage = new MasterLanguage();
            masterLanguage = _repo.GetAllMasterLanguageByID(ID);
            return new OkObjectResult(masterLanguage);
        }


        [Route("masterdata/GetAllMasterUoM")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterUoM()
        {
            List <MasterUoM> masterUoM = new List<MasterUoM>();
            masterUoM = _repo.GetAllMasterUoM();
            return new OkObjectResult(masterUoM);
        }

        [Route("masterdata/GetAllMasterUoMByID")]
        [HttpGet]
        public async Task<IActionResult> GetAllMasterUoMByID(int ID)
        {
            MasterUoM masterUoM = new MasterUoM();
            masterUoM = _repo.GetAllMasterUoMByID(ID);
            return new OkObjectResult(masterUoM);
        }

        [Route("masterdata/GetAllPurchaseOrder")]
        [HttpGet]
        public async Task<IActionResult> GetAllPurchaseOrder()
        {
            List<PurchaseOrder> masterPo = new List<PurchaseOrder>();
            masterPo = _repo.GetAllPurchaseOrder();
            return new OkObjectResult(masterPo);
        }


        [Route("masterdata/GetAllPurchaseOrderByID")]
        [HttpGet]
        public async Task<IActionResult> GetAllPurchaseOrderByID(string Number)
        {
            PurchaseOrder masterPo = new PurchaseOrder();
            masterPo = _repo.GetAllPurchaseOrderByID(Number);
            return new OkObjectResult(masterPo);
        }

    }
}
