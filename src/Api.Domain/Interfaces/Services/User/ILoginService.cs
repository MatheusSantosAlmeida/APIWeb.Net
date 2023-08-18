using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object?> FindByLogin(LoginDto user);
    }
}
