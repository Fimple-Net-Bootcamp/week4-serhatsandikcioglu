﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;
using VirtualPetCare.Shared.DTOs;

namespace VirtualPetCare.Shared.Model
{
    public record CustomResponse<T>
    {
        [JsonPropertyName("data")] public T Data { get; set; }

        [Newtonsoft.Json.JsonIgnore] public int StatusCode { get; set; }

        [Newtonsoft.Json.JsonIgnore] public bool Succeeded { get; private set; }

        [Newtonsoft.Json.JsonIgnore] public object[] Args { get; private set; }

        [JsonPropertyName("error")] public ErrorDTO Error { get; set; }

        public override string ToString()
        {
            return Succeeded ? "Succeeded" : $"Failed : {JsonConvert.SerializeObject(Error)}";
        }
        public static CustomResponse<T> Success(int statusCode, T data)
        {
            return new CustomResponse<T> { Data = data, StatusCode = statusCode, Succeeded = true };
        }

        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Succeeded = true };
        }
        public static CustomResponse<T> Fail(int statusCode, string error)
        {
            return new CustomResponse<T>
            {
                StatusCode = statusCode,
                Error = new ErrorDTO { Details = new List<string> { error } },
                Succeeded = false
            };
        }
    }
}
