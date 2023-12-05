using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Scriptables/Projectile Data")]
public class ProjectileData : ScriptableObject
{
    [Header("References")]
    public GameObject projectilePrefab;
    public AudioClip audioClip;
    [Header("Values info")]
    public float damage;
    public float penetration;
    public float heat;
    [Header("Mark info")]
    public float markArmorModifier;
    public float markHeatModifier;
    public float markRadius;
    public int markSecondsAlive;
}
