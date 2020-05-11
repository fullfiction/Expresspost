using System;

namespace api.Core.Models
{
    public static class ErrorDescriber
    {
        public static Error Default() => new Error(ErrorCode.Default, "Something went wrong");

        public static Error InvalidUsername() => new Error(ErrorCode.InvalidUsername, "Invalid username");
    }
}
