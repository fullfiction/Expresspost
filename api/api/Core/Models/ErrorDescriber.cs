using System;
using api.Core.Store.Entities;

namespace api.Core.Models
{
    public static class ErrorDescriber
    {
        public static Error Default() => new Error(ErrorCode.Default, "Something went wrong");

        public static Error InvalidUsername() => new Error(ErrorCode.InvalidUsername, "Invalid username");

        public static Error InvalidPassword() => new Error(ErrorCode.InvalidPassword, "Invalid password");

        public static Error DataNotFound() => new Error(ErrorCode.DataNotFound, "Data not found");
    }
}
