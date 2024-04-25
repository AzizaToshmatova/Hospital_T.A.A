using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IBaseService<Admin>
    {
        private readonly IBaseRepository<Admin> _AdminRepository;
        private object Admin;

        public AdminService(IBaseRepository<Admin> AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }

        public async Task<Admin> CreateAsync(Admin Admin, CancellationToken token = default)
        {
            return await _AdminRepository.CreateAsync(Admin, token);
        }



        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var Admin = await _AdminRepository.GetAsync(id, token);

            if (Admin == null)
                return false;

            return await _AdminRepository.DeleteAsync(Admin, token);
        }

        public async Task<IEnumerable<Admin>> GetAllAsync(CancellationToken token = default)
        {
            return await _AdminRepository.GetAllAsync(token);
        }

        public async Task<Admin> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _AdminRepository.GetAsync(id, token);
        }



        public async Task<bool> UpdateAsync(Admin Admins, CancellationToken token = default)
        {
            var existingAdmin = await GetAsync(Admins.Id);

            if (existingAdmin is null)
            {
                return false;
            }

           
            existingAdmin.Name = Admins.Name;
            
            

            return await _AdminRepository.UpdateAsync(existingAdmin, token);

        }
    }
}
