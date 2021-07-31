using UnityEngine;

public abstract class CommonExplosive : Explosive, IDamagable //common explosives implement IDamagable so detonation can cause chain reaction
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