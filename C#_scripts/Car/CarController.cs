using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour
{
    // Deklaracia premennych
    public InputManager im;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steerWheels;
    private float coef = 10000f;
    private float maxTurn = 30f;
    
    void Start()
    {
        im = GetComponent<InputManager>(); // Nacitanie komponentu InputManager
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Zrychlovanie/spomalovanie
        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = coef * Time.deltaTime * im.throttle;
        }

        // Odbacanie
        foreach (WheelCollider wheel in steerWheels)
        {
            wheel.steerAngle = maxTurn * im.steer;
        }

    }
}
