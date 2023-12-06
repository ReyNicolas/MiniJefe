using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] List<IHealth> healths;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healths[0].LoseHealth(100);
            healths.RemoveAt(0);
        }
    }
}
