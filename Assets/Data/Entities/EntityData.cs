using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptables/Entity Data")]
public class EntityData : ScriptableObject
{
    public GameObject entityPrefab;
    public List<SkillData> skillDatas = new List<SkillData>();
    public string pieceName;
    public int life;
    public int armor;    
}