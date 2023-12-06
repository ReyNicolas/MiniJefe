using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class EnemyLogic : MonoBehaviour, IEventEntity
{
    public event Action onTakeDamage;
    public event Action onDead;
    public event Action<EnemyLogic> onEnemyDead;
    public event Action onAttack;

    [Header("References info")]
    [SerializeField]protected Animator animator;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] ProjectileData projectileData;

    [Header("State info")]
    [SerializeField] protected bool isDoingAction;
    [SerializeField] protected bool isStunned;
    [SerializeField] float stunnedTime;
    [SerializeField] LayerMask enemiesMask;
    float attackTimer;

    protected CompositeDisposable compositeDisposable = new CompositeDisposable();


    private void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        SubscribeLogic();       
    }
    private void OnDisable()
    {
        compositeDisposable.Dispose();
    }

    void SubscribeLogic()
    {
        ////update
        var update = Observable.EveryUpdate();

        compositeDisposable.Add(update
             .Where(_ => !isDoingAction)
             .Do(_ => attackTimer -=Time.deltaTime)
             .Where(_ => attackTimer<0)
             .Subscribe(_ => Attack()));
    }

    #region Public methods
    public void SetHit()
    {
        animator.SetTrigger("Hit");
        onTakeDamage?.Invoke();
    }

    public void SetDead()
    {
        animator.SetTrigger("Dead");
        onEnemyDead?.Invoke(this);
        Destroy(gameObject, 10f);
    }
    public void SetProjectileData(ProjectileData projectileData)
    {
        this.projectileData = projectileData;
    }

    public void SetPhase(string phaseName)
    {
        animator.SetTrigger(phaseName);
    }

    #endregion

    #region Private methods

    void Attack()
    {
        attackTimer = projectileData.cooldown;
        Instantiate(projectileData.projectilePrefab, transform.position, transform.rotation);
    }
    #endregion

}


public interface IEventEntity
{
    event Action onTakeDamage;
    event Action onDead;
    event Action onAttack;
}
