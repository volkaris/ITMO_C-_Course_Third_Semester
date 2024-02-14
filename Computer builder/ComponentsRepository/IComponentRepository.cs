namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsRepository;

public interface IComponentRepository<T>
    where T : class
{
    void Add(T item);
    T GetItem(string name);
}