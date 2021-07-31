using UnityEngine;

public class Bomb : CommonExplosive
{
    [SerializeField] private LayerMask detonationLayers;
    
    private void OnCollisionEnter(Collision other)
    {
        if ((1 << other.gameObject.layer & detonationLayers.value) != 0)
        {
            Detonate();
        }
    }
}