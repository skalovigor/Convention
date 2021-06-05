namespace Convention.DAL
{
    public interface IUnitOfWorkAccessor
    {
        IUnitOfWork UnitOfWork { get; }
    }
}