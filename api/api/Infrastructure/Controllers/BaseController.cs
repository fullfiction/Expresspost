using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Core.Models;
using api.Core.Store;
using api.Infrastructure.Extensions;
using api.Infrastructure.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Controllers
{
    public abstract class BaseController<TEntity, TListOut, TFilterIn, TSingleOut, TCreateIn, TUpdateIn> : ControllerBase where TEntity : Entity where TFilterIn : IBaseFilterIn<TEntity>
    {
        protected readonly UnitOfWork _uow;
        protected readonly Store<TEntity> _store;
        protected readonly IMapper _mapper;

        public BaseController(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _store = _uow.GetStore<TEntity>();
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<ResultModel<TListOut>>> GetAsync([FromQuery] TFilterIn filter, [FromQuery] PagingIn paging, [FromQuery] SortingIn<TEntity> sorting)
        {
            var queryable = _store.Context.Set<TEntity>().AsQueryable();
            queryable = filter.Apply(queryable);
            queryable = sorting.Apply(queryable);
            var count = await queryable.CountAsync();
            var entities = await queryable.Skip(paging.Start).Take(paging.End).ToListAsync();
            var result = _mapper.Map<List<TListOut>>(entities);
            return result.AsApiResult<TListOut>(count);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ResultModel<TSingleOut>>> GetAsync(int id)
        {
            var entity = await _store.GetByIdAsync(id);
            if (entity == null)
                return Result<TSingleOut>.Failed(ErrorDescriber.DataNotFound()).AsApiResult();
            var result = _mapper.Map<TSingleOut>(entity);
            return result.AsApiResult();
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<ResultModel<TSingleOut>>> UpdateAsync(long id, TUpdateIn input)
        {
            var entityToUpdate = await _store.GetByIdAsync(id, true);
            if (entityToUpdate == null)
                return Result<TSingleOut>.Failed(ErrorDescriber.DataNotFound()).AsApiResult();
            _mapper.Map(input, entityToUpdate);
            var updateResult = _store.Update(entityToUpdate);
            await _uow.SaveAsync();
            var result = _mapper.Map<TSingleOut>(updateResult);
            return result.AsApiResult();
        }

        [HttpPost]
        public virtual async Task<ActionResult<ResultModel<TSingleOut>>> CreateAsync(TCreateIn input)
        {
            var newEntity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            _mapper.Map(input, newEntity);
            var createResult = _store.Create(newEntity);
            await _uow.SaveAsync();
            var result = _mapper.Map<TSingleOut>(createResult);
            return result.AsApiResult();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<ResultModel<bool>>> DeleteAsync(long id)
        {
            var entityToDelete = await _store.GetByIdAsync(id, true);
            if (entityToDelete == null)
                return Result<bool>.Failed(ErrorDescriber.DataNotFound()).AsApiResult();
            _store.Delete(entityToDelete);
            await _uow.SaveAsync();
            return true.AsApiResult();
        }
    }
}
