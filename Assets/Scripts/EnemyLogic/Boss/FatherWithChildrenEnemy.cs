using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherWithChildrenEnemy : MonoBehaviour
{
    [SerializeField] List<Transform> transformsToSpawnChilds = new List<Transform>();
    [SerializeField] GameObject childPrefab;
    [SerializeField] FatherHealth myHealthLogic;
    [SerializeField] int changeChildActiveDamageTime;
    [SerializeField] int rotationDegreesPerSecond;
    List<ChildToFatherHealth> childrenHealth = new List<ChildToFatherHealth>();
    float activeTimer;
    Vector3 vRotation;
    private void OnEnable()
    {
        childrenHealth.ForEach(ch => Destroy(ch));
        childrenHealth.Clear();

        transformsToSpawnChilds.ForEach(tsc => CreateChild(tsc));
        vRotation = new Vector3(0, 0, rotationDegreesPerSecond);
    }

    private void Update()
    {
        activeTimer -= Time.deltaTime;
        if (activeTimer < 0)
        {
            activeTimer = changeChildActiveDamageTime;
            SetChildActiveDamage();
        }

        transform.Rotate(vRotation * Time.deltaTime);
    }

    void SetChildActiveDamage()
    {
        childrenHealth.ForEach((ch) => ch.SetActiveCondition(false));

        childrenHealth[UnityEngine.Random.Range(0, childrenHealth.Count)].SetActiveCondition(true);
    }

    void CreateChild(Transform spawnTransform)
    {
        var childHealth = Instantiate(childPrefab, spawnTransform).GetComponent<ChildToFatherHealth>();
        childHealth.Initialize(myHealthLogic);
        childrenHealth.Add(childHealth);
    }


}
