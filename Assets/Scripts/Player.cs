using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;
using UnityEngine.Device;

public class Player : MonoBehaviour
{    
    public PlayerData playerData;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform aimTransform;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerInput playerInput;
    Vector2 aimDirection;
    Vector2 moveDirection;
    ReactiveProperty<float> skillCooldownTimer = new ReactiveProperty<float>();

    public void Initialize(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    private void Update()
    {
        skillCooldownTimer.Value -= Time.deltaTime;
        Move();
        Aim();
    }

    void Move()
    {
        // moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        moveDirection = moveDirection.normalized;
        rb.velocity = moveDirection * playerData.MoveSpeed;
    }

    void Aim()
    {
        //aimDirection = playerInput.actions["Aim"].ReadValue<Vector2>();
        aimDirection = Input.mousePosition - transform.position;

        if (aimDirection == Vector2.zero) return;

        aimDirection = aimDirection.normalized;
        aimTransform.localPosition = aimDirection;
        aimTransform.up = aimDirection;
    }

    public void UseSkill(SkillData skillData)
    {
        //TODO
        //skillCooldownTimer =  ---- cooldown del skill actual 
    }
}
