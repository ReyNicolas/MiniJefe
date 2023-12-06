using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Scriptables/Projectile Data")]
public class ProjectileData : ScriptableObject
{
    [Header("References")]
    public GameObject projectilePrefab;
    [Header("Values info")]
    public int speed;
    public int damage;
    public int cooldown;
}
