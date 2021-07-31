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
        indicatorTransform.localScale = Vector3.one * Mathf.Lerp(0.2f, 0.5f, hp / targetHaveHealth.BaseHealth);
        indicatorRenderer.material.SetColor(color, Color.Lerp(Color.red, Color.green, hp / targetHaveHealth.BaseHealth));
    }
}
