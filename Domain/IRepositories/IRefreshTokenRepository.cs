using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public   interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task DeleteAsync(RefreshToken refreshToken);
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId);
    }
}
