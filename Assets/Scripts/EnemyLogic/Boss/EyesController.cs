using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    [SerializeField] List<EnemyLogic> entities = new List<EnemyLogic>();
    [SerializeField] List<Transform> eyesTransformsPositions = new List<Transform>();
    [SerializeField] List<ProjectileData> projectileDatas = new List<ProjectileData>();
    [SerializeField] Animator animator;
    int positionCounter;

    // Start is called before the first frame update
    void Start()
    {
        entities.ForEach(e => e.onEnemyDead += RemoveEntity);
        SetPhase();
    }

    private void OnDestroy()
    {
        entities.ForEach(e => e.onEnemyDead -= RemoveEntity);
    }

    void RemoveEntity(EnemyLogic enemyLogic)
    {
        entities.Remove(enemyLogic);
        enemyLogic.gameObject.transform.parent = null;
        enemyLogic.onEnemyDead -= RemoveEntity;

        SetPhase();
    }

    void SetPhase()
    {
        animator.SetTrigger("PhaseEyes"+ entities.Count);
        entities.ForEach(e => e.SetPhase("Inactive"));
        entities.ForEach(e => e.SetProjectileData(projectileDatas[entities.Count - 1]));
        MoveEyes();
    }

    void MoveEyes()
    {
        positionCounter = 0;
        for(int i = 0; i< entities.Count; i++)
        {
            entities[i].GetComponent<MoveTo>().SetTransformToMove(eyesTransformsPositions[i], 0,SetEyePhase);
        }
    }

    void SetEyePhase()
    {
        positionCounter++;
        if(positionCounter == entities.Count)
        {
            entities.ForEach(e => e.SetPhase("Phase"+ entities.Count));
        }
    }


}
