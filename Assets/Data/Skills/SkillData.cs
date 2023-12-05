using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptables/Skill")]
public abstract class SkillData : ScriptableObject
{
    public SkillsTypes skillType;
    public ExecutionsTypes executionType;
    public int cost;
    public int timeToComplete;
}

[CreateAssetMenu(fileName = "MoveSkillData", menuName = "Scriptables/Skill/MoveSkill Data")]
public class MoveSkillData : SkillData
{
    private void Awake()
    {
        skillType = SkillsTypes.Move;
    }
}

[CreateAssetMenu(fileName = "ProjectileSkillData", menuName = "Scriptables/Skill/ProjectileSkill Data")]
public class ProjectileSkillData: SkillData
{
    public ProjectileData ProjectileData;

    private void Awake()
    {
        skillType = SkillsTypes.Projectile;
    }
}

[CreateAssetMenu(fileName = "AreaSkillData", menuName = "Scriptables/Skill/AreaSkill Data")]
public class AreaSkill: SkillData
{
    public float radius;

    private void Awake()
    {
        skillType = SkillsTypes.Area;
    }
}
public enum SkillsTypes
{
   Projectile,
   Area,
   Move
}
public enum ExecutionsTypes
{
    ToEquip,
    Activation,
    Instant,
}
