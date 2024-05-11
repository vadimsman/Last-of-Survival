using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public Transform FirePoint;

    public float RotationSpeed;

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        CameraAxisTransform.localEulerAngles = new Vector3(CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y"), 0, 0);
        FirePoint.localEulerAngles = new Vector3(FirePoint.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y"), 0, 0);
    }
}
