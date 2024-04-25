using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Application.Services
{

    public class PaymentService : IBaseService<Payment>
    {
        private readonly IBaseRepository<Payment> _PaymentRepository;
        private object Payment;

        public PaymentService(IBaseRepository<Payment> PaymentRepository)
        {
            _PaymentRepository = PaymentRepository;
        }

        public async Task<Payment> CreateAsync(Payment Payment, CancellationToken token = default)
        {
            return await _PaymentRepository.CreateAsync(Payment, token);
        }



        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var Payment = await _PaymentRepository.GetAsync(id, token);

            if (Payment == null)
                return false;

            return await _PaymentRepository.DeleteAsync(Payment, token);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken token = default)
        {
            return await _PaymentRepository.GetAllAsync(token);
        }

        public async Task<Payment> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _PaymentRepository.GetAsync(id, token);
        }



        public async Task<bool> UpdateAsync(Payment Payments, CancellationToken token = default)
        {
            var existingPayment = await GetAsync(Payments.Id);

            if (existingPayment is null)
            {
                return false;
            }

            existingPayment.Date = Payments.Date;
            existingPayment.Amount = Payments.Amount;

            return await _PaymentRepository.UpdateAsync(existingPayment, token);

        }
    }
}


