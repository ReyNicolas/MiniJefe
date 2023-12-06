using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] int speed;
    Action actionOnEndMoveTO;
    Transform transformToMove;


    public void SetTransformToMove(Transform aTransform, Action anAction)
    {
        transformToMove = aTransform;
        actionOnEndMoveTO = anAction;
    }

    private void Update()
    {
        if(transformToMove == null) return;
        transform.position = Vector2.MoveTowards(transform.position, transformToMove.position, speed * Time.deltaTime);

        if (transform.position == transformToMove.position)
        {
            actionOnEndMoveTO();
        }
    }

}
