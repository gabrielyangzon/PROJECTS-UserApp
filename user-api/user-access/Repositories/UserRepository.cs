using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_data.types.Models;

namespace user_access.Repositories
{


    public class UserRepository 
    {
   
        private USER_CONTEXT _ctx;

        public UserRepository(USER_CONTEXT ctx) 
        {
            this._ctx = ctx;
        }

        public async Task Add(User user)
        {
            try
            {
                this._ctx.Add(user);
                await this._ctx.SaveChangesAsync();

            }catch(Exception ex)
            {

            }
        }


        public async Task Update(User user)
        {
           _ctx.Update(user);
           await _ctx.SaveChangesAsync();
        }


        public async Task Delete(Guid userId)
        {
            User user = this.GetById(userId).Result;

            _ctx.Remove(user);
            await _ctx.SaveChangesAsync();    
        }

        public async Task<List<User>> GetAll()
        {
            return await this._ctx.User.AsNoTracking().ToListAsync();
        }  
        
        public async Task<User> GetById(Guid id)
        {
            return await _ctx.User.FirstOrDefaultAsync(c => c.Id.Equals(id));
  
        }

    }
}
