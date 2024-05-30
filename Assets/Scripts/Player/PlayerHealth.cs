using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float value;

    public Slider Slider;

    public float Value => value;

    public void Update()
    {
        Slider.value = value;
        if (value > 100)
        {
            value = 100;
        }
    }
    public void DealDamage(float amount)
    {
        value -= amount;
    }

    public void AddHealth(int addValue)
    {
        value += addValue;
    }
}
