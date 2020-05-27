using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Deklaracia premennych
    public float throttle;
    public float steer;

    // Input z klavesnice - zrychlovanie/spomalovanie a odbocovanie
    void Update()
    {
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");
    }
}
