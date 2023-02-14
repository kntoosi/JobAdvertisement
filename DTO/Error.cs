using System.Collections.Generic;

namespace CrouseServiceAdvertisement.DTO
{
    public struct ErrorTypes
    {
        /// <summary>
        /// درخواست تکراری است
        /// </summary>
        public const string duplicate_request = "duplicate_request";
        /// <summary>
        /// تعداد درخواست بیش از حد انتظار است
        /// </summary>
        public const string high_number_request = "high_number_request";
        /// <summary>
        /// درخواست صحیح (معتبر) نیست
        /// </summary>
        public const string invalid_request = "invalid_request";
        /// <summary>
        /// اجازه دسترسی وجود ندارد
        /// </summary>
        public const string unauthorized = "unauthorized";
        /// <summary>
        /// خطایی سمت سرور رخ داده است
        /// </summary>
        public const string server_error = "server_error";
        /// <summary>
        /// خطای ناخواسته ای سمت سرور رخ داده است
        /// </summary>
        public const string server_unexpected_error = "server_unexpected_error";
        /// <summary>
        /// موردی یافت نشد
        /// </summary>
        public const string not_found = "not_found";
    }

    public class Error
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public short StatusCode { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }

    public class ErrorList
    {
        public List<Error> Errors { get; set; }

        public ErrorList()
        {
            this.Errors = new List<Error>();
        }

        public ErrorList(params Error[] _errors)
        {
            this.Errors = new List<Error>();
            for (int i = 0; i < _errors.Length; i++)
                this.Errors.Add(_errors[i]);
        }
    }
}
