using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] frontWheelColliders;//Коллайдеры передних колёс
    public Transform[] frontWheels;//Сами передние колёса
    public WheelCollider[] backWheelColliders;//Коллайдеры задних колёс
    public Transform[] backWheels;//Сами задние колёса
    public Transform centerOfMass;//Центр массы авто

    public float maxSpeed;//Макс скорость
    public float sideSpeed;//Скорость поворота и угол поворота колёс
    [HideInInspector]
    public float vAxis;//Вертикальное направление
    [HideInInspector]
    public float hAxis;//Горизонтальное направление

    [Range(0, 1)]
    public float steerHelpValue = 0;
    float lastYRotation;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        vAxis = Input.GetAxis("Vertical");
        hAxis = Input.GetAxis("Horizontal");
        
        float handbrake = Input.GetKey(KeyCode.LeftShift) ? 1 : 0;

        /*мотор*/
        backWheelColliders[0].motorTorque = vAxis * maxSpeed;
        backWheelColliders[1].motorTorque = vAxis * maxSpeed;
        frontWheelColliders[0].motorTorque = vAxis * maxSpeed;
        frontWheelColliders[1].motorTorque = vAxis * maxSpeed;
        /*мотор*/

        /*поворот*/
        frontWheelColliders[0].steerAngle = hAxis * sideSpeed;
        frontWheelColliders[1].steerAngle = hAxis * sideSpeed;
        /*поворот*/

        /*ручной тормоз*/
        if (handbrake == 1.0)
        {
            backWheelColliders[0].brakeTorque = float.MaxValue;
            backWheelColliders[1].brakeTorque = float.MaxValue;
            backWheelColliders[0].motorTorque = 0.001f;
            backWheelColliders[1].motorTorque = 0.001f;
            frontWheelColliders[0].motorTorque = frontWheelColliders[0].motorTorque / 2f;
            frontWheelColliders[1].motorTorque = frontWheelColliders[1].motorTorque / 2f;
        }
        else
        {
            backWheelColliders[0].brakeTorque = 0;
            backWheelColliders[1].brakeTorque = 0;
        }
        /*ручной тормоз*/

        SteerHelp();
        
    }

    void SteerHelp()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.y - lastYRotation) < 10f)
        {
            float turnAdjust = (transform.rotation.eulerAngles.y - lastYRotation) * steerHelpValue;
            Quaternion rotationAssist = Quaternion.AngleAxis(turnAdjust, Vector3.up);
            GetComponent<Rigidbody>().velocity = rotationAssist * GetComponent<Rigidbody>().velocity;
        }
        lastYRotation = transform.rotation.eulerAngles.y;
    }
}
