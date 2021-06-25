
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    [SerializeField] private float lookSensivity = 3f;
    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Movement
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);
        
        
        //Rotation
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensivity;
        
        //Apply rotation
        motor.Rotate(_rotation);
        
        
        //Camera Rotation
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3( _xRot, 0f, 0f)  * lookSensivity;
        
        //Apply rotation
        motor.RotateCamera(_cameraRotation);
    }
}
