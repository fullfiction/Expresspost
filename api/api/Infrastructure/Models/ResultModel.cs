using System;

namespace api.Infrastructure.Models
{
    public class ResultModel<TData>
    {
        public bool Succeed { get; set; }
        public string Error { get; set; }
        public TData Data { get; set; }
    }
}
