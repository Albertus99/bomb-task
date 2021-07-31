using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHaveHealth
{
    public bool Dead => Health.Value <= 0;
    public ObservableData<float> Health { get; private set; }
    public float BaseHealth { get; private set; }

    [SerializeField] private float baseHealth = 100;
    private ObserveDataToken<float> healthDataToken;

    private void Start()
    {
        Health = new ObservableData<float>(out healthDataToken);
        BaseHealth = baseHealth;
        healthDataToken.Set(baseHealth);
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
        
        healthDataToken.Set(Health.Value - damage);
        if (Dead)
        {
            Destroy(gameObject);
        }
    }
}