using CrouseServiceAdvertisement.Configuration;
using CrouseServiceAdvertisement.DTO;
using CrouseServiceAdvertisement.Models;
using CrouseServiceAdvertisement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CrouseServiceAdvertisement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly ILogger<AdvertisementController> _logger;
        private readonly IAdvertisementService _adsService;

        public AdvertisementController(ILogger<AdvertisementController> logger, IAdvertisementService adsService)
        {
            _logger = logger;
            _adsService = adsService;
        }

        /// <summary>
        /// لیست آگهی ها را برمی گرداند
        /// </summary>
        /// <response code="200">List of <see cref="AdsOutputEntity"/> </response>
        [HttpPost]
        [Authorize]
        //[Authorize(Policy = "AdsSearch")]
        //public async  Task<ActionResult<List<AdsOutputEntity>>> GetAds([FromBody] AdsSearchEntity input)
        public IActionResult GetAds([FromBody] AdsSearchEntity input)
        {
            string prsNo = User.Claims.Where(m => m.Type == CrouseClaimTypes.uid).FirstOrDefault().Value;

            //Check Role  0: Applicant  1: Admin
            int role = 0;//Applicant

           // if (User.IsInRole("EmploymentAdvertisement.HCD"))
            //{
            //    role = 1;
            //}
            //---------------
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _adsService.GetAds(input, role, Int32.Parse(prsNo));

                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Advertisement/GetAds");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAds function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/GetAds");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/GetAds");
        }
        /// <summary>
        /// لیست آگهی هابه همراه جزییات را برای سیستم سایت برمی گرداند. این آگهی ها حتما تایید شده و منقضی نشده هستند
        /// </summary>
        /// <response code="200">List of <see cref="AdsMasterDetailsOutputEntity"/> </response>
        [HttpPost]
        public IActionResult GetNotExpiredAds([FromBody] AdsSearchEntity input)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _adsService.GetNotExpiredAds(input);

                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Advertisement/GetNotExpiredAds");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetNotExpiredAds function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/GetNotExpiredAds");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/GetNotExpiredAds");
        }
        /// <summary>
        /// لیست آگهی ها را برای سیستم جذب برمی گرداند. این آگهی ها حتما تایید شده  هستند
        /// </summary>
        /// <response code="200">List of <see cref="AdsOutputEntity"/> </response>
        [HttpPost]
        public IActionResult GetConfirmedAds([FromBody] AdsSearchEntity input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _adsService.GetConfirmedAds(input);

                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Advertisement/GetConfirmedAds");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetConfirmedAds function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/GetConfirmedAds");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/GetConfirmedAds");
        }
        /// <summary>
        /// جزییات یک آگهی را بر می گرداند
        /// </summary>
        /// <response code="200">List of <see cref="AdsMasterDetailsOutputEntity"/> </response>

        [HttpPost]
        // [Authorize(Policy = "AdsSearch")]
        [Authorize]
        public IActionResult GetAdsDetails([FromBody] int AdsID)
        {
            string prsNo = User.Claims.Where(m => m.Type == CrouseClaimTypes.uid).FirstOrDefault().Value;

            //Check Role  0: Applicant  1: Admin
            int role = 0;//Applicant

            //if (User.IsInRole("EmploymentAdvertisement.HCD"))
            //{
            //    role = 1;
            //}
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _adsService.GetAdsDetails(AdsID,role, Int32.Parse(prsNo));

                    if (result == null)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Advertisement/GetAdsDetails");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsDetails function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/GetAdsDetails");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/GetAdsDetails");
        }
        ///// <summary>
        ///// جزییات یک آگهی را برای استفاده در وب سایت بر می گرداند
        ///// </summary>
        ///// <response code="200">List of <see cref="AdsMasterDetailsOutputEntity"/> </response>

        //[HttpPost]
        //public IActionResult GetAdsDetailsWithoutAuth([FromBody] int AdsID)
        //{
            
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var result = _adsService.GetAdsDetailsWithoutAuth(AdsID);

        //            if (result == null)
        //            {
        //                return Problem(
        //                            type: ErrorTypes.not_found,
        //                            statusCode: (int)HttpStatusCode.NotFound,
        //                            title: "موردی یافت نشد.",
        //                            detail: "",
        //                            instance: "/Advertisement/GetAdsDetailsWithoutAuth");

        //            }
        //            return Ok(result);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "internal server error occured in GetAdsDetailsWithoutAuth function.");
        //            return Problem(
        //                type: ErrorTypes.server_unexpected_error,
        //                statusCode: (int)HttpStatusCode.InternalServerError,
        //                title: "خطای داخلی در سرور",
        //                detail: "",
        //                instance: "/Advertisement/GetAdsDetailsWithoutAuth");
        //        }
        //    }
        //    return Problem(
        //       type: ErrorTypes.invalid_request,
        //       statusCode: (int)HttpStatusCode.BadRequest,
        //       title: "درخواست نامعتبر است.",
        //       detail: "",
        //       instance: "/Advertisement/GetAdsDetails");
        //}
        /// <summary>
        /// اضافه کردن آگهی
        /// </summary>
        /// <response code="200">integer(Ads Id) </response>

        [HttpPost]
        //[Authorize(Policy = "AdsAdd")]
        [Authorize]
        public IActionResult AddAds([FromBody] AdsMasterDetailsInputEntity adsMasterDetailsInputEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string prsNo = User.Claims.Where(m => m.Type == CrouseClaimTypes.uid).FirstOrDefault().Value;
                    //string prsNo = "114689";
                   
                   

                        var result = _adsService.AddAds(adsMasterDetailsInputEntity, Int32.Parse(prsNo));

                        if (result == -1)
                        {
                            return Problem(
                                        type: ErrorTypes.not_found,
                                        statusCode: (int)HttpStatusCode.NotFound,
                                        title: "موردی یافت نشد. ثبت داده انجام نشد",
                                        detail: "",
                                        instance: "/Advertisement/AddAds");

                        }
                        return Ok(result);
                    
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in AddAds function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/AddAds");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/AddAds");
        }
        /// <summary>
        /// ویرایش آگهی
        /// </summary>
        /// <response code="200">integer(Ads Id) </response>

        [HttpPost]
        [Authorize]
        //[Authorize(Policy = "AdsEdit") ]
        public IActionResult EditAds([FromBody] AdsMasterDetailsEditEntity adsMasterDetailsEditEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   string prsNo = User.Claims.Where(m => m.Type == CrouseClaimTypes.uid).FirstOrDefault().Value;
                   // string prsNo = "114689";

                    var result = _adsService.EditAds(adsMasterDetailsEditEntity, Int32.Parse(prsNo));

                    if (result == -1)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد. ویرایش انجام نشد",
                                    detail: "",
                                    instance: "/Advertisement/EditAds");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in EditAds function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/EditAds");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/EditAds");
        }

        /// <summary>
        /// تایید آگهی
        /// </summary>
        /// <response code="200">integer(Ads Id) </response>

        [HttpPost]
        [Authorize]
        //[Authorize(Policy = "ConfirmAds") ]
        public IActionResult ConfirmAds([FromBody] AdsConfirmInputEntity adsConfirmInputEntity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string prsNo = User.Claims.Where(m => m.Type == CrouseClaimTypes.uid).FirstOrDefault().Value;
                    // string prsNo = "114689";

                    var result = _adsService.ConfirmAds(adsConfirmInputEntity, Int32.Parse(prsNo));

                    if (result == -1)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد. ویرایش انجام نشد",
                                    detail: "",
                                    instance: "/Advertisement/ConfirmAds");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in ConfirmAds function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Advertisement/ConfirmAds");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Advertisement/ConfirmAds");
        }
    }
}
