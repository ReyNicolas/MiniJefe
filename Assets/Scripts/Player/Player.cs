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
    bool doingDash;
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



    private void Update()
    {
        shootTimer.Value -= Time.deltaTime;
        dashTimer.Value -= Time.deltaTime;
        Move();
        Aim();
    }

    void Move()
    {
        if (doingDash) return;
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
        if (shootTimer.Value > 0 || doingDash) return;
        shootTimer.Value = projectileData.cooldown;
        Instantiate(projectileData.projectilePrefab, aimTransform.position, aimTransform.rotation);
    }

    public void Dash(CallbackContext callbackContext)
    {
        if (dashTimer.Value > 0) return;
        rb.velocity = rb.velocity.normalized * playerData.DashForce;
        dashTimer.Value = playerData.DashCooldown;
        doingDash = true;
        animator.SetTrigger("Dash");        
    }

    void EndDash()
    {
        doingDash = false;
    }
}
