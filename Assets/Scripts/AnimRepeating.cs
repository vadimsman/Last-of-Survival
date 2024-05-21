using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRepeating : MonoBehaviour
{
    // Путь к анимации разминки руки
    public string animationName = "HandIdle";

    void Start()
    {
        // Запускаем таймер, который будет повторять анимацию каждые 20 секунд
        StartCoroutine(PlayAnimationEvery20Seconds());
    }

    IEnumerator PlayAnimationEvery20Seconds()
    {
        while (true)
        {
            // Ожидаем 20 секунд перед запуском анимации
            yield return new WaitForSeconds(20);

            // Устанавливаем анимацию персонажа на нужную
            GetComponent<Animator>().SetTrigger("HandIdle");
        }
    }
}
