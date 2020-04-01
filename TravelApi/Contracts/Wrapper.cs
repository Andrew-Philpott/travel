namespace Contracts
{
    public interface IRepositoryWrapper
    {
        // IReviewRepository Review { get; }
        IDestinationRepository Destination { get; }
        void Save();
    }
}