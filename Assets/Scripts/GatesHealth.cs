using UnityEngine;

public class GatesHealth : MonoBehaviour
{ 
    public float _value = 100;
    public void DealDamage(float amount)
    {
        _value -= amount;

        if (_value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
 