using Severis.DataAccess.Models.Context;
using Severis.DataAccess.Repository;

namespace Severis.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        OemRepository Oem { get; }
        ModelRepository Model { get; }
        UploadFileJobRepository UploadFileJob { get; }
        UploadFileErrorMessageRepository UploadFileErrorMessage { get; }
        EstimateTotalVehicleProductionRepository EstimateTotalVehicleProduction { get; }
        int Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BS_OE_BudgetContext _context;
        public OemRepository Oem { get; private set; }
        public UploadFileJobRepository UploadFileJob { get; private set; }
        public ModelRepository Model { get; private set; }
        public UploadFileErrorMessageRepository UploadFileErrorMessage { get; private set; }
        public EstimateTotalVehicleProductionRepository EstimateTotalVehicleProduction { get; private set; }

        public UnitOfWork(BS_OE_BudgetContext context)
        {
            _context = context;
            Oem = new OemRepository(_context);
            UploadFileJob = new UploadFileJobRepository(_context);
            Model = new ModelRepository(_context);
            UploadFileErrorMessage = new UploadFileErrorMessageRepository(_context);
            EstimateTotalVehicleProduction = new EstimateTotalVehicleProductionRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
