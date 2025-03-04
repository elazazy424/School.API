﻿using MediatR;
using School.Core.Bases;
using School.Core.Features.ApplicationUser.Queries.Results;

namespace School.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
