using api.Core.Store;
using api.Core.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T : Entity
    {
        protected readonly UnitOfWork _uow;
        protected readonly Store<T> _store;

        public BaseController(UnitOfWork uow)
        {
            _uow = uow;
            _store = _uow.GetStore<T>();
        }
    }
}
