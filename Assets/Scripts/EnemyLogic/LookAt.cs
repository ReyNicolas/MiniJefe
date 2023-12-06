using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    private void OnEnable()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.up = playerTransform.position - transform.position;
    }
}
