using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    [SerializeField] MoveTo moveTo;
    [SerializeField] EnemyLogic enemyLogic;
    [SerializeField] int radius;
    [SerializeField] int damage;
    [SerializeField] LayerMask playerMask;

    private void OnEnable()
    {
        moveTo.enabled = true;
        moveTo.SetTransformToMove(GameObject.FindWithTag("Player").transform, radius-1,AutoDestroy);
    }

    void AutoDestroy()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, radius, playerMask);

        if(collider2D.TryGetComponent<IHealth>(out IHealth healthLogic))
        {
            healthLogic.LoseHealth(damage);
        }
            enemyLogic.SetDead();
    }
}
