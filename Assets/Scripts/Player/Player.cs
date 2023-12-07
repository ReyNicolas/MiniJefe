using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;
using UnityEngine.Device;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [Header("References info")]
    public PlayerData playerData;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform aimTransform;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerInput playerInput;
    Vector2 aimDirection;
    Vector2 moveDirection;
    ReactiveProperty<float> shootTimer = new ReactiveProperty<float>();
    ReactiveProperty<float> dashTimer = new ReactiveProperty<float>();
    float pushTimer;
    ProjectileData projectileData;

    private void Start()
    {
        Initialize(playerData); // to test
    }
    public void Initialize(PlayerData playerData)
    {
        this.playerData = playerData;
        this.projectileData = playerData.Projectile;
    }

    public void GetPushed(Vector2 force, float time)
    {
        rb.velocity = force;
        pushTimer = time;
    }


    private void Update()
    {
        shootTimer.Value -= Time.deltaTime;
        dashTimer.Value -= Time.deltaTime;
        pushTimer -= Time.deltaTime;
        Move();
        Aim();
    }

    void Move()
    {
        if (pushTimer > 0) return;
         moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();

        moveDirection = moveDirection.normalized;
        rb.velocity = moveDirection * playerData.MoveSpeed;
    }

    void Aim()
    {
        aimDirection = playerInput.actions["Aim"].ReadValue<Vector2>();

        if (aimDirection == Vector2.zero) return;

        aimDirection = aimDirection.normalized;
        aimTransform.localPosition = aimDirection;
        aimTransform.up = aimDirection;
    }

    public void Shoot(CallbackContext callbackContext)
    {
        if (shootTimer.Value > 0) return;
        shootTimer.Value = projectileData.cooldown;
        Instantiate(projectileData.projectilePrefab, aimTransform.position, aimTransform.rotation);
    }

    public void Dash(CallbackContext callbackContext)
    {
        if (dashTimer.Value > 0) return;
        dashTimer.Value = playerData.DashCooldown;
        animator.SetTrigger("Dash");
        
    }
}
