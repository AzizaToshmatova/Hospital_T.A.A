using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Application.Services
{

    public class DoctorService : IBaseService<Doctor>
    {
        private readonly IBaseRepository<Doctor> _DoctorRepository;
        private object Doctor;

        public DoctorService(IBaseRepository<Doctor> DoctorRepository)
        {
            _DoctorRepository = DoctorRepository;
        }

        public async Task<Doctor> CreateAsync(Doctor Doctor, CancellationToken token = default)
        {
            return await _DoctorRepository.CreateAsync(Doctor, token);
        }



        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var Doctor = await _DoctorRepository.GetAsync(id, token);

            if (Doctor == null)
                return false;

            return await _DoctorRepository.DeleteAsync(Doctor, token);
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync(CancellationToken token = default)
        {
            return await _DoctorRepository.GetAllAsync(token);
        }

        public async Task<Doctor> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _DoctorRepository.GetAsync(id, token);
        }



        public async Task<bool> UpdateAsync(Doctor Doctors, CancellationToken token = default)
        {
            var existingDoctor = await GetAsync(Doctors.Id);

            if (existingDoctor is null)
            {
                return false;
            }

            existingDoctor.Name = Doctors.Name;
            existingDoctor.Experience = Doctors.Experience;
            existingDoctor.Specialty = Doctors.Specialty;
           

            return await _DoctorRepository.UpdateAsync(existingDoctor, token);

        }
    }
}


