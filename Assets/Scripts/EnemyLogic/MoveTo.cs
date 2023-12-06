using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] int speed;
    int distance;
    Action actionOnEndMoveTO;
    Transform transformToMove;


    public void SetTransformToMove(Transform aTransform,int distance, Action anAction)
    {
        this.distance = distance;
        transformToMove = aTransform;
        actionOnEndMoveTO = anAction;
    }

    private void Update()
    {
        if(transformToMove == null) return;
        transform.position = Vector2.MoveTowards(transform.position, transformToMove.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, transformToMove.position) <= distance)
        {
            actionOnEndMoveTO();
        }
    }

}
