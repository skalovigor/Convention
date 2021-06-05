namespace Convention.DAL
{
    internal class UnitOfWorkAccessor : IUnitOfWorkAccessor
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkAccessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;
    }
}