using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Shopping.WebApi.Extensions;

public sealed class ApiResult<TData> where TData : class
{
    public ApiResult(bool isSuccess,
        HttpStatusCode statusCode,
        TData data,
        string message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToString();
        Data = data;
    }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public TData Data { get; set; }

    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    #region Implicit Operators

    public static implicit operator ApiResult<TData>(TData data)
    {
        return new ApiResult<TData>(true, HttpStatusCode.OK, data);
    }

    public static implicit operator ApiResult<TData>(OkResult result)
    {
        return new ApiResult<TData>(true, HttpStatusCode.OK, null);
    }

    public static implicit operator ApiResult<TData>(OkObjectResult result)
    {
        return new ApiResult<TData>(true, HttpStatusCode.OK, (TData)result.Value);
    }

    public static implicit operator ApiResult<TData>(BadRequestResult result)
    {
        return new ApiResult<TData>(false,HttpStatusCode.BadRequest, null);
    }

    public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }

        return new ApiResult<TData>(false, HttpStatusCode.BadRequest, null, message);
    }

    public static implicit operator ApiResult<TData>(ContentResult result)
    {
        return new ApiResult<TData>(true, HttpStatusCode.OK, null, result.Content);
    }

    public static implicit operator ApiResult<TData>(NotFoundResult result)
    {
        return new ApiResult<TData>(false, HttpStatusCode.OK, null);
    }

    public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
    {
        return new ApiResult<TData>(false, HttpStatusCode.OK, (TData)result.Value);
    }

    #endregion Implicit Operators
}