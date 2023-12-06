using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] Transform fatherTransform;
    [SerializeField] int speed;

    private void OnEnable()
    {        
        transform.up = transform.position - fatherTransform.position;
    }


    private void Update()
    {
        transform.RotateAround(fatherTransform.localPosition, Vector3.back, Time.deltaTime * speed);
    }
}
