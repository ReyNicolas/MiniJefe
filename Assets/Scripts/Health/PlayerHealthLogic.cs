using System;
using UnityEngine;

public class PlayerHealthLogic : IHealth
{
    Animator animator;
    [SerializeField]  PlayerData playerData;
    [SerializeField]  float inmuneWindow;
    float inmuneTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();       
    }

    private void Start()
    {
        health.Value = playerData.PlayerHealth.Value;
        actualHealth.Value = playerData.PlayerHealth.Value;
    }
    private void Update()
    {
        inmuneTimer -= Time.deltaTime;
    }

    public override void LoseHealth(int amount)
    {
        if (inmuneTimer > 0) return;
        actualHealth.Value -= amount;
        inmuneTimer = inmuneWindow;
        animator.SetTrigger("Hit");
        if (actualHealth.Value <= 0) animator.SetBool("Dead", true);
    }
}
