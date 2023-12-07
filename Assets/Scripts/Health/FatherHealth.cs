using System;
using UniRx;
using UnityEngine;

public class FatherHealth : MonoBehaviour
{
    public ReactiveProperty<int> health = new ReactiveProperty<int>();
    public ReactiveProperty<int> actualHealth = new ReactiveProperty<int>();
    private void Awake()
    {
        actualHealth.Value = health.Value;
    }
    public  void LoseHealth(int amount)
    {
        actualHealth.Value -= amount;
        if(actualHealth.Value < 0)
        {
            Destroy(gameObject);
        }
    }
}