using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FxLight : MonoBehaviour
{
    [SerializeField] EnemyLogic enemyLogic;
    [SerializeField] Light2D lightFX;


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
        lightFX.intensity = 10;
        yield return new WaitForSeconds(.2f);
        lightFX.intensity = 0;
    }
}
