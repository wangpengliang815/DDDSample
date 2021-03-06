﻿using AutoMapper;

using DotnetCoreInfra.SeedWork;

using Ordering.Domain.AggregateModels;
using Ordering.Infrastructure.Repos;

namespace Ordering.DomainService
{
    public class BaseService
    {
        protected readonly IOrderRepository repository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public BaseService(IOrderRepository repository
            , IMapper mapper
            , IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}
