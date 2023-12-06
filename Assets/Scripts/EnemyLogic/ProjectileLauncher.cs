using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;
    [SerializeField] float speed;
    [SerializeField] int time;
    float timer;

    private void Start()
    {
        timer = time;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = time;
            CreateProjectile();
        }
    }

    public void SetProjectileData(ProjectileData projectileData)
    {
        this.projectileData = projectileData;
    }


    void CreateProjectile()
    {
        Instantiate(projectileData.projectilePrefab, transform.position, Quaternion.identity);
            //.GetComponent<StandardProjectile>()
            //.Initialize(transform.up, null);

    }

}
