using EfCore6.AppDbContext.SeedWork;

namespace EfCore6.AppDbContext;

public class Status : Enumeration
{
   // Enumeration is from https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs

    public static Status Pending = new(1, nameof(Pending));
    public static Status InValid = new(2, nameof(InValid));
    public static Status Valid = new(3, nameof(Valid));

    public Status(int id, string name)
        : base(id, name)
    { }

      public static IEnumerable<Status> List() =>
        new[] { Pending, InValid, Valid };

}