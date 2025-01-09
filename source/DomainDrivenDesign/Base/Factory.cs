namespace DomainDrivenDesign;

public static class Factory
{
    public static T Get<T>(Func<T, bool> predicate) where T : class => typeof(T).Assembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(T))).Select(type => Activator.CreateInstance(type) as T).SingleOrDefault(predicate);
}
