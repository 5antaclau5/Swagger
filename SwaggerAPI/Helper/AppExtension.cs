using Api.Models;
using Microsoft.AspNetCore.Http;
using SwaggerAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SwaggerAPI.Helper
{
    public static class AppExtension
    {
        public static ErrorResponse GetErrorResponse(this AppErrorType errorType
            , string code
            , string message = ""
            , string typeDescription = ""
            , string parameter = ""
            , [CallerMemberName] string callerName = null
            , [CallerLineNumber] int callerLineNo = 0
            , string errDetail = ""
        )
        {
            return new ErrorResponse
            {
                Code = code,
                Message = string.IsNullOrEmpty(message) ? errorType.GetDescription() : message,
                Type = $"{errorType.GetCategory()}({callerName}[{callerLineNo}]:{typeDescription})",
                Parameter = parameter,
                DisplayMessage = ErrorMessageMapping.GetErrors(code, errDetail)
            };
        }

        public static string GetDescription(this Enum e)
        {
            Type type = e.GetType();
            var memInfo = type.GetMember(e.ToString());

            if (memInfo[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() is DescriptionAttribute descriptionAttribute)
            {
                return descriptionAttribute.Description;
            }
            return string.Empty; // could also return string.Empty
        }

        public static string GetProducerVersion(this Enum e)
        {
            Type type = e.GetType();
            var memInfo = type.GetMember(e.ToString());

            if (memInfo[0]
                .GetCustomAttributes(typeof(ProducerVersion), false)
                .FirstOrDefault() is ProducerVersion producerVersionAttribute)
            {
                return producerVersionAttribute.Version;
            }
            return string.Empty; // could also return string.Empty
        }

        public static string GetCategory(this Enum e)
        {
            var type = e.GetType();
            var memInfo = type.GetMember(e.ToString());

            if (memInfo[0]
                .GetCustomAttributes(typeof(CategoryAttribute), false)
                .FirstOrDefault() is CategoryAttribute categoryAttribute)
            {
                return categoryAttribute.Category;
            }
            return string.Empty; // could also return string.Empty
        }

        public static void SetResponseSuccess<TData>(this BaseResponse<TData> response, string datasource)
        {
            response.Result = true;
            response.ResponseCode = StatusCodes.Status200OK.ToString();
            response.ResponseMessage = "Success";
            response.ResponseDataSource = datasource;
        }

        public static void SetResponseError<TData>(this BaseResponse<TData> response
            , AppErrorType errorType
            , string code
            , string datasource
            , string message = ""
            , string typeDescription = ""
            , string parameter = ""
            , [CallerMemberName] string callerName = null
            , [CallerLineNumber] int callerLineNo = 0
            , string errDetail = ""
        )
        {
            typeDescription = string.IsNullOrEmpty(typeDescription) ? datasource : typeDescription;
            response.Result = false;
            response.ResponseCode = code;
            response.ResponseMessage = errorType.GetDescription();
            response.ResponseDataSource = datasource;

            response.Error = new ErrorResponse
            {
                Code = $"{code}:{errorType.GetDescription()}",
                Message = string.IsNullOrEmpty(message) ? errorType.GetDescription() : message,
                Type = $"{errorType.GetCategory()}({callerName}[{callerLineNo}]:{typeDescription})",
                Parameter = parameter,
                DisplayMessage = ErrorMessageMapping.GetErrors(code, errDetail)

            };
        }

        public static void SetResponseException<T>(this T response, Exception exception, string responseDataSource) where T : class, new()
        {
            if (response == null)
            {
                response = new T();
            }
            var Result = response.GetType().GetProperty("Result");
            if (Result != null)
            {
                Result.SetValue(response, false);
            }
            var ResponseCode = response.GetType().GetProperty("ResponseCode");
            if (ResponseCode != null)
            {
                ResponseCode.SetValue(response, StatusCodes.Status500InternalServerError.ToString());
            }

            var ResponseMessage = response.GetType().GetProperty("ResponseMessage");
            if (ResponseMessage != null)
            {
                ResponseMessage.SetValue(response, exception.ToString());
            }

            var ResponseDataSource = response.GetType().GetProperty("ResponseDataSource");
            if (ResponseDataSource != null)
            {
                ResponseDataSource.SetValue(response, responseDataSource);
            }
            var IsCalled = response.GetType().GetProperty("IsCalled");
            if (IsCalled != null)
            {
                IsCalled.SetValue(response, false);
            }
            var Data = response.GetType().GetProperties().FirstOrDefault(m => m.Name == "Data");
            if (Data != null)
            {
                Data.SetValue(response, null);
            }
        }

        public static RequestHeader GetHeader(this IHeaderDictionary headers)
        {
            var header = new RequestHeader();
            foreach (var property in header.GetType().GetProperties())
            {
                if (headers.ContainsKey(property.Name))
                {
                    var headerValue = string.Empty;
                    if (headers.TryGetValue(property.Name, out var headerValues))
                    {
                        headerValue = headerValues.FirstOrDefault();
                    }
                    property.SetValue(header, headerValue);
                }
            }
            return header;
        }

        public static void SetResponseHeader(this HttpResponse response, string code, string message, string datasource)
        {
            if (response.Headers.ContainsKey("responsecode"))
            {
                response.Headers.Remove("responsecode");
            }
            response.Headers.Add("responsecode", code);
            if (response.Headers.ContainsKey("responsedatasource"))
            {
                response.Headers.Remove("responsedatasource");
            }
            response.Headers.Add("responsedatasource", datasource);
            if (response.Headers.ContainsKey("responsemessage"))
            {
                response.Headers.Remove("responsemessage");
            }
            response.Headers.Add("responsemessage", message.Replace(Environment.NewLine, string.Empty));
        }
    }
}
