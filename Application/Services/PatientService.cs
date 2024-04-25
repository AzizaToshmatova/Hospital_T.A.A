using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Application.Services
{
    
        public class PatientService : IBaseService<Patient>
        {
            private readonly IBaseRepository<Patient> _PatientRepository;
        private object Patient;

        public PatientService(IBaseRepository<Patient> clientRepository)
            {
            _PatientRepository = clientRepository;
            }

            public async Task<Patient> CreateAsync(Patient client, CancellationToken token = default)
            {
                return await _PatientRepository.CreateAsync(client, token);
            }



        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var client = await _PatientRepository.GetAsync(id, token);

            if (client == null)
                return false;

            return await _PatientRepository.DeleteAsync(client, token);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(CancellationToken token = default)
            {
                return await _PatientRepository.GetAllAsync(token);
            }

            public async Task<Patient> GetAsync(Guid id, CancellationToken token = default)
            {
                return await _PatientRepository.GetAsync(id, token);
            }



        public async Task<bool> UpdateAsync(Patient clients, CancellationToken token = default)
            {
                var existingPatient = await GetAsync(clients.Id);

                if (existingPatient is null)
                {
                    return false;
                }

            existingPatient.Name = clients.Name;
            existingPatient.Phone = clients.Phone;
            existingPatient.Email = clients.Email;

            return await _PatientRepository.UpdateAsync(existingPatient, token);

            }
        }
    }


