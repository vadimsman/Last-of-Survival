using UnityEngine;

public class DayConroller : MonoBehaviour
{
    public float Speed;

    public float DayXRotate;

    public float NightXRotate;

    public UnityEngine.GameObject LightGroup;

    private float _newAngleX;

    private bool _isDay = true;

    public int DayCount;

    private EnemyHealth _enemyHealth;

    public bool IsDay => _isDay;
    public void Start()
    {
        _newAngleX = transform.eulerAngles.x;
        _enemyHealth = FindObjectOfType<EnemyHealth>();

    }

    public void Update()
    {
        transform.Rotate(Vector3.right * Speed * Time.deltaTime);
        _newAngleX = transform.eulerAngles.x;
        _isDay = _newAngleX > DayXRotate && _newAngleX < NightXRotate;
        LightOnOrOf();
        if (!_isDay)
        {
            DayCount++;
        }
    }

    private void LightOnOrOf()
    {
        if (_isDay)
        {
            LightGroup.SetActive(false);
        }
        if (!_isDay)
        {
            LightGroup.SetActive(enabled);
        }
    }
}
