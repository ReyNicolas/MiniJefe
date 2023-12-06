using UnityEngine;
using UniRx;

public abstract class IHealth : MonoBehaviour
{
    public ReactiveProperty<int> health = new ReactiveProperty<int>();
    public  ReactiveProperty<int> actualHealth = new ReactiveProperty<int>();

    public abstract void LoseHealth(int amount);



}