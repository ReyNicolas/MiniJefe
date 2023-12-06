using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] Transform fatherTransform;
    [SerializeField] int speed;

    private void Update()
    {
        transform.up = transform.position - fatherTransform.position;
        transform.RotateAround(fatherTransform.localPosition, Vector3.back, Time.deltaTime * speed);
    }
}
