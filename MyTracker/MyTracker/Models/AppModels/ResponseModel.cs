using MyTracker.Models.Enums;

namespace MyTracker.Models.AppModels
{
    public class ResponseModel
    {
        public required string Message { get; set; }
        public required string Status { get; set; }
        public object? Data { get; set; } = null;
    }
}
