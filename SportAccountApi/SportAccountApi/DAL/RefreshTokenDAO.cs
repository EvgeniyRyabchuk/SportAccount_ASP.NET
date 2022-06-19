using Microsoft.EntityFrameworkCore;
using SportAccountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAccountApi.DAL
{
    public class RefreshTokenDAO : IStandartDAO<_RefreshToken>
    {
        private readonly DataContext db;
        public RefreshTokenDAO(DataContext db)
        {
            this.db = db;
        }


        public async Task<ICollection<_RefreshToken>> AddAsync(_RefreshToken model)
        {
            await db.RefreshTokens.AddAsync(model);
            await db.SaveChangesAsync(); 
            return await db.RefreshTokens.ToListAsync(); 
        }

        public async Task<ICollection<_RefreshToken>> DeleteAsync(int id)
        {
            _RefreshToken rt = await db.RefreshTokens.FindAsync(id);
            db.RefreshTokens.Remove(rt);
            return await db.RefreshTokens.ToListAsync();  
        }

        public async Task<ICollection<_RefreshToken>> DeleteByTokenAsync(string token)
        {
            _RefreshToken rt = await FindByTokenAsync(token); 
            if(rt == null)
            {
                throw new Exception("Token does not exist"); 
            }
            
            db.RefreshTokens.Remove(rt);
            await db.SaveChangesAsync();
            return await db.RefreshTokens.ToListAsync();
        }

        public async Task<_RefreshToken> FindByTokenAsync(string token)
        {
            return await db.RefreshTokens
                .Where(rt => rt.RefreshToken == token)
                .FirstAsync();
        }

        public Task<_RefreshToken> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<ICollection<_RefreshToken>> GetAllAsync()
        {
            ICollection<_RefreshToken> rt = await db.RefreshTokens.ToListAsync();
            return rt; 
        } 

        public async Task<ICollection<_RefreshToken>> UpdateAsync(_RefreshToken model)
        {
            _RefreshToken origin = await db.RefreshTokens.FindAsync(model.Id);
            if (origin == null)
                throw new System.Exception("refresh token does not exist"); 

            origin.RefreshToken = model.RefreshToken;
            origin.Expired_At = model.Expired_At; 

            await db.SaveChangesAsync(); 
            return await db.RefreshTokens.ToListAsync(); 
        }
    }
}
