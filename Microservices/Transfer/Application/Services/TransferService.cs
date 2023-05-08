using Domain.Core.Bus;
using Transfer.Domain.Interfaces;
using TransferApplication.Interfaces;

namespace Transfer.Application.Services;

    public class TransferService: ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

    public async Task Add(Domain.Models.Transfer transfer)
    {
        await _transferRepository.Add(transfer);
    }

    public async Task<IEnumerable<Domain.Models.Transfer>> GetAll()
    {
        return await _transferRepository.GetAll();
    }
}
