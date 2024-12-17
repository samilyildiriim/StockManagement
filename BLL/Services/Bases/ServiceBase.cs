using BLL.DAL;

namespace BLL.Services.Bases
{
    public abstract class ServiceBase
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = string.Empty;

        protected readonly Db _Db;

        protected ServiceBase(Db db)
        {
            _Db = db;
        }

        public ServiceBase Success(string message = "") // Success() or Success("Record created successfully.")
        {
            IsSuccessful = true;
            Message = message;
            return this;
        }

        public ServiceBase Error(string message = "")
        {
            IsSuccessful = false;
            Message = message;
            return this;
        }
    }
}