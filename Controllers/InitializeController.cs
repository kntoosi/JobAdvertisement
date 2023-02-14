using CrouseServiceAdvertisement.DTO;
using CrouseServiceAdvertisement.Interfaces;
using CrouseServiceAdvertisement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CrouseServiceAdvertisement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class InitializeController : ControllerBase
    {

        private readonly ILogger<InitializeController> _logger;
        private readonly IInitializeService _initService;

        public InitializeController(ILogger<InitializeController> logger, IInitializeService initService)
        {
            _logger = logger;
            _initService = initService;
        }


        [HttpGet("{active:int?}")]
        //[Authorize]
        //[Authorize(Policy = "AdminOnly")]
        //[Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<AdsGenderLSTEntity>>> GetAdsGenderLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.GenderList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsGenderLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsGenderLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsGenderLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsGenderLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsSalaryLSTEntity>>> GetAdsSalaryLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.SalaryList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsSalaryLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsSalaryLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsSalaryLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsSalaryLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsStateLSTEntity>>> GetAdsStateLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.StateList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsStateLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsStateLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsStateLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsStateLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsWrkBenefitLSTEntity>>> GetAdsWrkBenefitLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.WrkBenefitList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsWrkBenefitLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsWrkBenefitLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsWrkBenefitLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsWrkBenefitLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsWrkCategoryLSTEntity>>> GetAdsWrkCategoryLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.WrkCategoryList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsWrkCategoryLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsWrkCategoryLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsWrkCategoryLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsWrkCategoryLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsWrkHistoryLSTEntity>>> GetAdsWrkHistoryLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.WrkHistoryList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsWrkHistoryLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsWrkHistoryLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsWrkHistoryLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsWrkHistoryLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsWrkPlaceLSTEntity>>> GetAdsWrkPlaceLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.WrkPlaceList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsWrkPlaceLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsWrkPlaceLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsWrkPlaceLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsWrkPlaceLST");
        }
        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsJobPositionLSTEntity>>> GetAdsJobPositionLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.JobPositionList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsJobPositionLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsJobPositionLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsJobPositionLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsJobPositionLST");
        }

        [HttpGet("{active:int?}")]
        public async Task<ActionResult<List<AdsSuggestedJobLSTEntity>>> GetAdsSuggestedJobLST(int active = 1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _initService.SuggestedJobList(active);
                    if (result == null || result.Count == 0)
                    {
                        return Problem(
                                    type: ErrorTypes.not_found,
                                    statusCode: (int)HttpStatusCode.NotFound,
                                    title: "موردی یافت نشد.",
                                    detail: "",
                                    instance: "/Initialize/GetAdsSuggestedJobLST");

                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "internal server error occured in GetAdsSuggestedJobLST function.");
                    return Problem(
                        type: ErrorTypes.server_unexpected_error,
                        statusCode: (int)HttpStatusCode.InternalServerError,
                        title: "خطای داخلی در سرور",
                        detail: "",
                        instance: "/Initialize/GetAdsSuggestedJobLST");
                }
            }
            return Problem(
               type: ErrorTypes.invalid_request,
               statusCode: (int)HttpStatusCode.BadRequest,
               title: "درخواست نامعتبر است.",
               detail: "",
               instance: "/Initialize/GetAdsSuggestedJobLST");
        }
    }
}
