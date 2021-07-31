using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable
{
    private float health;
    public bool Dead => health <= 0;
    public float Health => health;

    [SerializeField] private float baseHealth = 100;
    
    private void Start()
    {
        health = baseHealth;
    }

    private void FixedUpdate()
    {
        OnIterate();
    }

    protected virtual void OnIterate()
    {
        
    }

    public void Damage(float damage)
    {
        if(Dead) return;
        
        health -= damage;

        if (Dead)
        {
            Destroy(gameObject);
        }
    }
}