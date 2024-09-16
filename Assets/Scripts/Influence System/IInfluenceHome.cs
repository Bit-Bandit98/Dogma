public interface IInfluenceHome<T>
{
    public NameAndDescription GetDetails();
    public int GetPopulation();
    public T[] GetNeighbours();
}