﻿using SharedLibrary.Dtos;
using System.Text.Json.Serialization;

namespace HotelManagement.Core.Dtos;
public class Response<T> where T : class
{
    public T Data { get; private set; }
    public int StatusCode { get; private set; }

    [JsonIgnore]
    public bool IsSuccessfull { get; private set; }

    public ErrorDto Error { get; private set; }

    public static Response<T> Succes(T data, int statusCode)
    {
        return new Response<T>
        {
            Data = data,
            StatusCode = statusCode,
            IsSuccessfull = true
        };
    }

    public static Response<T> Success(int statusCode)
    {
        return new Response<T> { Data = default, StatusCode = statusCode, IsSuccessfull = true };
    }

    public static Response<T> Fail(ErrorDto errorDto, int statusCode)
    {
        return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessfull = false };
    }

    // fail metodu overload'u yazdık
    public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
    {
        var errorDto = new ErrorDto(errorMessage, isShow);
        return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccessfull = false };
    }

}
