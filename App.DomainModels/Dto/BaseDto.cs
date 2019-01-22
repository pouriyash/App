using App.DomainModels.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.DomainModels.Dto
{
    public abstract class BaseDto<TDTO,TEntity,TKey>
        where TDTO: class, new()
        where TEntity : BaseEntity<TKey>, new()
    {
        [Display(Name = "ردیف")]
        public TKey Id { get; set; }

        public TEntity ToEntity()
        {
            return Mapper.Map<TEntity>(CastToDerivedClass(this));
        }

        public TEntity ToEntity(TEntity entity)
        {
            return Mapper.Map(CastToDerivedClass(this), entity);
        }

        public static TDTO FromEntity(TEntity model)
        {
            return Mapper.Map<TDTO>(model);
        }

        protected TDTO CastToDerivedClass(BaseDto<TDTO, TEntity, TKey> baseInstance)
        {
            return Mapper.Map<TDTO>(baseInstance);
        }
    }
}
