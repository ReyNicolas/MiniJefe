using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FxEnemyTakeDamageLight : MonoBehaviour
{
    [SerializeField] EnemyLogic enemyLogic;
    [SerializeField] Light2D lightFX;
    [SerializeField] int intensity;


    private void Awake()
    {
        enemyLogic.onTakeDamage += SetLight;
    }

    private void OnDestroy()
    {
        enemyLogic.onTakeDamage -= SetLight;
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
