using System;
using UnityEngine;


public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private MonoBehaviour target;
    private IHaveHealth targetHaveHealth;
    [SerializeField] private Transform indicatorTransform;
    [SerializeField] private MeshRenderer indicatorRenderer;
    private static readonly int color = Shader.PropertyToID("_Color");

    private void Start()
    {
        if (target is IHaveHealth haveHealth)
        {
            targetHaveHealth = haveHealth;
            haveHealth.Health.PermanentSubscribe(OnTargetHealthChange);
            OnTargetHealthChange(haveHealth.Health.Value);
        }
        else
        {
            throw new Exception("HealthIndicator requires interface IHaveHealth on target!");
        }
    }

    private void OnTargetHealthChange(float hp)
    {
        var t = hp / targetHaveHealth.BaseHealth;
        indicatorTransform.localScale = Vector3.one * Mathf.Lerp(0.2f, 0.5f, t);


        indicatorRenderer.material.SetColor(color,
            t < 0.5f
                ? Color.Lerp(Color.red, Color.yellow, t * 2)
                : Color.Lerp(Color.yellow, Color.green, (t - 0.5f) * 2));
    }
}
