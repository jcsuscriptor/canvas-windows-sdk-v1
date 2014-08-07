﻿using System.Net;
using System.Net.Http.Headers;
using Canvas.v1.Wrappers.Contracts;

namespace Canvas.v1.Wrappers
{
    /// <summary>
    /// The Box response returned from the API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> : IApiResponse<T> where T : class
    {
        /// <summary>
        /// The object representation of a successful response
        /// </summary>
        public T ResponseObject { get; set;  }

        /// <summary>
        /// The full response string from the request
        /// </summary>
        public string ContentString { get; set; }

        /// <summary>
        /// Status of the response
        /// </summary>
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Status code of the HTTP response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The error associated with an Error status
        /// This will be null in all other cases
        /// </summary>
        public ApiError Error { get; set; }

        /// <summary>
        /// Headers returned as part of the response
        /// </summary>
        public HttpResponseHeaders Headers { get; set; }
    }

    /// <summary>
    /// The available Response statuses
    /// </summary>
    public enum ResponseStatus
    {
        Unknown,
        Success,
        Pending,
        Error,
        Unauthorized
    }
}
