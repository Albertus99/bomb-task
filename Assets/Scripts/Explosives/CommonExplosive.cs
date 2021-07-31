using UnityEngine;

public abstract class CommonExplosive : Explosive, IDamagable
{

    [SerializeField] private Explosion explosion;

    protected override void Detonation()
    {
        var currentExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        currentExplosion.Execute();
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        Detonate();
    }
}