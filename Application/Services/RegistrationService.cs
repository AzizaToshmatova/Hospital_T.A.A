using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Application.Services
{

    public class RegistrationService : IBaseService<Registration>
    {
        private readonly IBaseRepository<Registration> _RegistrationRepository;
        private object Registration;

        public RegistrationService(IBaseRepository<Registration> RegistrationRepository)
        {
            _RegistrationRepository = RegistrationRepository;
        }

        public async Task<Registration> CreateAsync(Registration Registration, CancellationToken token = default)
        {
            return await _RegistrationRepository.CreateAsync(Registration, token);
        }



        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var Registration = await _RegistrationRepository.GetAsync(id, token);

            if (Registration == null)
                return false;

            return await _RegistrationRepository.DeleteAsync(Registration, token);
        }

        public async Task<IEnumerable<Registration>> GetAllAsync(CancellationToken token = default)
        {
            return await _RegistrationRepository.GetAllAsync(token);
        }

        public async Task<Registration> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _RegistrationRepository.GetAsync(id, token);
        }



        public async Task<bool> UpdateAsync(Registration Registrations, CancellationToken token = default)
        {
            var existingRegistration = await GetAsync(Registrations.Id);

            if (existingRegistration is null)
            {
                return false;
            }

            existingRegistration.Date = Registrations.Date;

            return await _RegistrationRepository.UpdateAsync(existingRegistration, token);

        }
    }
}


