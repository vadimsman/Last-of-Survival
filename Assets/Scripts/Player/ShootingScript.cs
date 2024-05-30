using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform muzzlePosition; // Позиция ствола оружия
    public Transform firePoint; // Точка, откуда производится выстрел
    public float damage;
    public AudioController AudioController;
    public float KD;
    public float KDExpenditure;

    void Update()
    {
        KD -= KDExpenditure;
        if (KD < 0)
        {
            KD = 0;
        }
        if (Input.GetMouseButton(0) && KD == 0) // Проверка нажатия кнопки огня
        {
            KD = 1;
            RaycastHit hit;
            AudioController.ShootSoundPlay();
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<EnemyHealth>() != null)
                {
                    Debug.Log("POPAL");
                    var enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    enemyHealth.DamageUpdate(damage);
                }
            }
        }
    }
}

