using UnityEngine;
using UniRx;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptables/Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    public int PlayerLevel;
    public int MoveSpeed;
    public ReactiveProperty<int> PlayerHealth = new ReactiveProperty<int>(0);

}
