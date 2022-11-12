using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private GameObject PlayerGameObject;
    [SerializeField] private Camera Player;
    [SerializeField] private float Sensivity = 5f;
    [SerializeField] private float SmoothTime = 0.1f;

    private float _xRotation;
    private float _yRotation;
    private float _xRotationCurrent;
    private float _yRotationCurrent;
    private float _currentVelosityX;
    private float _currentVelosityY;
    private readonly string _mouseX = "Mouse X";
    private readonly string _mouseY = "Mouse Y";

    private void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        _xRotation += Input.GetAxis(_mouseX) * Sensivity;
        _yRotation += Input.GetAxis(_mouseY) * Sensivity;

        _xRotationCurrent = Mathf.SmoothDamp(_xRotationCurrent, _xRotation, ref _currentVelosityX, SmoothTime);
        _yRotationCurrent = Mathf.SmoothDamp(_yRotationCurrent, _yRotation, ref _currentVelosityY, SmoothTime);

        Player.transform.rotation = Quaternion.Euler(-_yRotationCurrent, _xRotationCurrent, 0f);
        PlayerGameObject.transform.rotation = Quaternion.Euler(0f, _xRotationCurrent, 0f);
    }
}
