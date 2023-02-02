using EfCore6.AppDbContext;
using EfCore6.AppDbContext.SeedWork;

namespace AppDbContext;

public class Parent : Entity, IAggregateRoot
{
    public int Id { get; set; }
    public string Name { get; set; }
    private readonly List<Child> _children;
    public IReadOnlyCollection<Child> Children => _children;
    public Status Status 
    {
        get
        {
            return _children.Count() == 0 
                ? Status.Pending
                : (_children.All(a => a.IsValid()) ? Status.Valid : Status.InValid);
        }
        
        private set { }
    }
    private int _statusId;

}
