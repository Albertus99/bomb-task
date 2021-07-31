using System;
using UnityEngine;

public abstract class Explosive : MonoBehaviour
{
    private bool detonated;
    protected void Detonate()
    {
        if(detonated) return;
        
        detonated = true;
        Detonation();
    }

    protected abstract void Detonation();
}