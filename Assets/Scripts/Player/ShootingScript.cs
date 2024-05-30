using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingScript : MonoBehaviour
{
    public Transform muzzlePosition; // Позиция ствола оружия
    public Transform firePoint; // Точка, откуда производится выстрел
    public float damage;
    public AudioController AudioController;
    public float KD;
    public float KDExpenditure;
    public int AmmoInMagazine = 30;
    private int _maxAmmo = 30;
    public int AmmoInInventory;
    private int _needAmmo;
    private float _reloadKD = 0;
    public float ReloadSpeed;
    public TextMeshProUGUI AmmoInInventoryText;
    public TextMeshProUGUI CurentAmmo;
    void Update()
    {
        CurentAmmo.text = AmmoInMagazine.ToString();
        AmmoInInventoryText.text = AmmoInInventory.ToString();
        KD -= KDExpenditure;
        if (KD < 0)
        {
            KD = 0;
        }
        if (Input.GetMouseButton(0) && KD == 0 && AmmoInMagazine > 0 && _reloadKD == 0) // Проверка нажатия кнопки огня
        {
            KD = 1;
            AmmoInMagazine -= 1;
            Debug.Log(AmmoInMagazine);
            RaycastHit hit;
            AudioController.ShootSoundPlay();
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<EnemyHealth>() != null)
                {
                    var enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    enemyHealth.DamageUpdate(damage);
                }
            }
        }
        _reloadKD -= ReloadSpeed;
        if (_reloadKD < 0)
        {
            _reloadKD = 0;
        }
        if (AmmoInMagazine == 0 || Input.GetKeyDown(KeyCode.R))
        {
            if (AmmoInInventory >= 30 && _reloadKD == 0)
            {
                AudioController.ReloadSoundPlay();
                _needAmmo = _maxAmmo - AmmoInMagazine;
                AmmoInInventory -= _needAmmo;
                AmmoInMagazine = _maxAmmo;
                _reloadKD = 1;
            }
            if (AmmoInInventory < 30 && AmmoInInventory > 0 && _reloadKD == 0)
            {
                AudioController.ReloadSoundPlay();
                AmmoInMagazine = AmmoInInventory;
                AmmoInInventory = 0;
                _reloadKD = 1;
            }
        }
    }
}

