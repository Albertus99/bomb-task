using UnityEngine;

public class Dynamite : CommonExplosive
{
    [SerializeField] private float detonationTime = 5;
    private float detonationStart;
    private void Start()
    {
        detonationStart = Time.time;
    }

    private void Update()
    {
        if (Time.time - detonationStart > detonationTime)
        {
            Detonate();
        }
    }
}