using UnityEngine;
using UniRx.Triggers;
using UniRx;
using Unity.VisualScripting;

public class ProjectileLogic : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] string enemyTag;
    private void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * projectileData.speed;
        this.OnCollisionEnter2DAsObservable()
            .Where(IsMyEnemyTag)
            .Subscribe(DoDamage);

        this.OnCollisionEnter2DAsObservable()
            .Where(collision=> !IsMyEnemyTag(collision))
            .Subscribe(_=>Destroy(gameObject));

    }

    private void DoDamage(Collision2D collision)
    {
      if(collision.gameObject.TryGetComponent<IHealth>(out IHealth healthLogic))
        {
            healthLogic.LoseHealth(projectileData.damage);
        }
        Destroy(gameObject);
    }

    private bool IsMyEnemyTag(Collision2D collision) =>
        collision.gameObject.CompareTag(enemyTag);
}
