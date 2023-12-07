using UnityEngine;

public class MoveTillCollision : MonoBehaviour
{
    [SerializeField] int speed = 10;
    [SerializeField] int maxDistance = 15;
    Vector3 vOrigin,vMove;
    private void OnEnable()
    {
        vOrigin = transform.position;
        SetVectorMove();
    }
    private void Update()
    {
        transform.position += vMove.normalized * speed * Time.deltaTime;
        if(Vector2.Distance(transform.position,vOrigin) > maxDistance)
        {
            SetVectorMove();
        }
    }


    void SetVectorMove()
    {
        vMove = new Vector2(0.2f * Random.Range(-5, 6), 0.2f * Random.Range(-5, 6));
    }
}
