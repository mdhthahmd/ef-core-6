using EfCore6.AppDbContext.SeedWork;

namespace AppDbContext;

public class Child : Entity
{
    private string _description;
    private bool _isValid;
    public bool IsValid() 
    {
        return _isValid == true;
    }

     protected Child() { }
}
