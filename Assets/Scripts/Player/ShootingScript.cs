using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform muzzlePosition; // Позиция ствола оружия
    public Transform firePoint; // Точка, откуда производится выстрел
    public float damage;
    public AudioController AudioController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка нажатия кнопки огня
        {
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

