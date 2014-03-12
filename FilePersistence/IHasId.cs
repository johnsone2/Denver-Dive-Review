namespace FilePersistence
{
    public interface IHasId<T>
    {
        T Id { get; set; }
    }
}