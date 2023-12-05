using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{    
    public PlayerData playerData;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] Transform aimTransform;
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerInput playerInput;
    Vector2 aimDirection;
    Vector2 moveDirection;
    float skillCooldownTimer;
    public ReactiveProperty<float> shootTimer = new ReactiveProperty<float>(0);

    //private void Awake()
    //{
    //    shootTimer.Value = shootCooldown;
    //}

    public void Initialize(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    private void Update()
    {
        shootTimer.Value -= Time.deltaTime;
        Move();
        Aim();
    }

    void Move()
    {
        moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();
        moveDirection = moveDirection.normalized;
        rb.velocity = moveDirection * playerData.MoveSpeed;
    }

    void Aim()
    {
       aimDirection = playerInput.actions["Aim"].ReadValue<Vector2>();

        if(aimDirection == Vector2.zero) return;

        aimDirection = aimDirection.normalized;
        aimTransform.localPosition = aimDirection;
        aimTransform.up = aimDirection;
    }

    void UseSkill()
    {
        //TODO
        //skillCooldownTimer =  ---- cooldown del skill actual 
    }
}
