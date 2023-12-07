using UnityEngine;

public class ChildToFatherHealth: IHealth
{
    [SerializeField] FatherHealth fatherHealth;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool active;

    public void Initialize(FatherHealth fatherHealth)
    {
        this.fatherHealth = fatherHealth;
        SetActiveCondition(false);
    }

    public void SetActiveCondition(bool value)
    {
        active = value;

        spriteRenderer.color
            = active
            ? Color.white
            : Color.black;

    }

    public override void LoseHealth(int amount)
    {
        if(!active) return;

        fatherHealth.LoseHealth(amount);
    }
}
