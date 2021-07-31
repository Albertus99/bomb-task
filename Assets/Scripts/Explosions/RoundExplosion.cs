using UnityEngine;

public class RoundExplosion : Explosion
{
    [SerializeField] private float radius = 5;
    [SerializeField] private float totalDamage = 5000;
    [SerializeField] private int rayCount = 72;
    
    public override void Execute()
    {
        float rayDamage = totalDamage / rayCount;
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 origin = transform.position;
            Vector3 direction = Quaternion.Euler(0, 360 * i / (float) rayCount, 0) * Vector3.forward;

            if (Physics.Raycast(origin, direction, out var hit, radius))
            {
                Debug.DrawLine(origin, hit.point, Color.red, 3);
                if (hit.collider.TryGetComponent<IDamagable>(out var damagable))
                {
                    float falloff = Mathf.Clamp01(1 - (hit.distance / radius));
                    damagable.Damage(falloff * rayDamage);
                }
            }
            else
            {
                Debug.DrawRay(origin, direction * radius, Color.blue, 3);
            }
            
        }
        
        Destroy(gameObject, 3);
    }
}