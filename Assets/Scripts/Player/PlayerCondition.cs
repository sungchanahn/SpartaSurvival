using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition UICondition;

    Condition health { get { return UICondition.Health; } }
    Condition hunger { get { return UICondition.Hunger; } }
    Condition stamina { get { return UICondition.Stamina; } }

    [SerializeField] private float noHungerStaminaDecay;
    public event Action OnTakeDamage;

    private void Update()
    {
        hunger.Subtract(hunger.PassiveValue * Time.deltaTime);
        stamina.Add(stamina.PassiveValue * Time.deltaTime);

        if (hunger.CurValue < 0.0f)
        {
            stamina.Subtract(noHungerStaminaDecay * Time.deltaTime);
        }

        if (health.CurValue < 0.0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("플레이어가 사망했습니다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        OnTakeDamage?.Invoke();
    }

    public void UseStamina(float amount)
    {
        stamina.Subtract(amount);
    }

    public bool CanUseStamina(float useStamina)
    {
        if (stamina.CurValue < useStamina)
        {
            return false;
        }

        return true;
    }
}