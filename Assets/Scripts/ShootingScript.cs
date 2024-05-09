using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public LayerMask targetLayer; // Маска слоя для определения целей
    public Transform muzzlePosition; // Позиция ствола оружия
    public Transform firePoint; // Точка, откуда производится выстрел
    public float force = 10f; // Сила выстрела

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка нажатия кнопки огня
        {
            RaycastHit hit;
            // Создание луча от точки стрельбы в направлении взгляда камеры
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity, targetLayer))
            {
                // Если луч попал в цель
                Debug.Log("Попал во что-то!");
            }
            else
            {
                // Если луч ни во что не попал
                Debug.Log("Missed!");
            }
        }
    }
}

