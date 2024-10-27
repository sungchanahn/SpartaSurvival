using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float CurValue;
    public float MaxValue;
    public float StartValue;
    public float PassiveValue;
    public Image UIBar;

    private void Start()
    {
        CurValue = StartValue;
    }

    private void Update()
    {
        UIBar.fillAmount = GetPercentage();
    }

    public void Add(float amount)
    {
        CurValue = Mathf.Min(CurValue + amount, MaxValue);
    }

    public void Subtract(float amount)
    {
        CurValue = Mathf.Max(CurValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return CurValue / MaxValue;
    }
}