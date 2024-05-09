using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int targetLayer = 8; // Установите номер слоя маски, который вы хотите использовать для врагов

    void Start()
    {
        // Получаем все враги в сцене
        GameObject[] enemies = FindObjectsOfType<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (enemy.CompareTag("Enemy")) // Проверяем, имеет ли объект тег "Enemy"
            {
                // Добавляем врага на слой маски targetLayer
                enemy.layer = targetLayer;
            }
        }
    }
}
