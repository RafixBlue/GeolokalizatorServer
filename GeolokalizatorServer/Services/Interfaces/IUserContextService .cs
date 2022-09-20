using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GeolokalizatorServer.Services.Interfaces
{
    public interface IUserContextService
    {
        public ClaimsPrincipal User { get; }

        public int? GetUserId { get; }
    }
}
