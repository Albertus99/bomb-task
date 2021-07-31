public interface IDamagable
{
    void Damage(float damage);
}

public interface IHaveHealth : IDamagable
{
    public ObservableData<float> Health { get; }
    public float BaseHealth { get; }
}