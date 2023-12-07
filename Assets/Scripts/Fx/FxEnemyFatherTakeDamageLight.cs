using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UniRx;
using System;

public class FxEnemyFatherTakeDamageLight : MonoBehaviour
{
    [SerializeField] FatherHealth fatherHealth;
    [SerializeField] Light2D lightFX;
    [SerializeField] int intensity;
    IDisposable disposable;

    private void Awake()
    {
        disposable = fatherHealth.actualHealth
             .Where(value => (value < fatherHealth.health.Value)&& value>0)
             .Subscribe(_ => SetLight());
    }
    private void OnDestroy()
    {
        disposable.Dispose();
    }


    void SetLight()
    {
        StartCoroutine(SetLightCor());
    }

    IEnumerator SetLightCor()
    {
        lightFX.intensity = intensity;
        yield return new WaitForSeconds(.2f);
        lightFX.intensity = 0;
    }
}
