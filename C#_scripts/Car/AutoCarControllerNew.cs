using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AutoCarControllerNew: MonoBehaviour
{
    // Deklaracia premennych
    public DataLoader dl;
    public string wVelStr;
    private float wVelFloat;
    private float throttle;
    private int throttleCnt;
    public Text actVel;
    private float actual;
    private Rigidbody rb;
    public GameObject car;
    private float value;
    private float timeCnt = 0f;
    public GameObject fWall;
    public GameObject bWall;
    private float carPos;
    private float fWallPos;
    private float bWallPos;
    private bool flag;

    void Start()
    {
        dl = GetComponent<DataLoader>(); // Nacitanie komponentu DataLoader
        rb = car.GetComponent<Rigidbody>();
        throttleCnt = 1;
        actVel.text = 0.ToString();
        value = 0;
    }

    void FixedUpdate()
    {
        // Aktualna hodnota rychlosti
        actual = Mathf.Round(rb.velocity.magnitude * 10.0f) * 0.1f;

        // Zmena na hodnotu rychlosti zelaneho ID
        wVelStr = dl.wVel;
        if(wVelStr != "")
        {
            float.TryParse(wVelStr, out wVelFloat); // String to Float
            if(value != wVelFloat)
            {
                if (throttleCnt % 2 != 0) // Zmena smeru jazdy pri kazdej volbe novej rychlosti
                {
                    throttle = 1;
                }
                else
                {
                    throttle = -1;
                }
                value = wVelFloat;
                throttleCnt += 1;
                flag = true; // Zabezpecenie opatovneho rozbehu
                rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
        }

        carPos = rb.transform.position.z; // Poloha vozidla
        fWallPos = fWall.transform.position.z; // Poloha prednej steny
        bWallPos = bWall.transform.position.z; // Poloha zadnej steny

        if (((fWallPos - carPos) > (value * 12)) && ((bWallPos - carPos) < (value * -12))) // Zistovanie vzdialenosti od prekazky
        {
            rb.velocity = value * throttle * new Vector3(0f, 0f, 1f); // Jazda v dostatocnej vzdialenosti od prekazky
            flag = false;
        }
        else
        {
            if (flag) // Rozbeh po brzdeni
            {
                rb.velocity = value * throttle * new Vector3(0f, 0f, 1f);
            }
            else // Brzdenie
            {
                if (rb.velocity.magnitude < 1)
                {
                    rb.AddForce(new Vector3(0, 0, 0));
                    if (rb.velocity.magnitude < 0.2)
                    {
                        rb.velocity = new Vector3(0f, 0f, 0f);
                    }
                }
                else
                {
                    rb.AddForce(new Vector3(0, 0, value * -throttle * Time.deltaTime * 1200));
                }
            }
        }
    }

    // Update vypisu aktualnej hodnoty rychlosti
    void Update()
    {
        actual = Mathf.Round(rb.velocity.magnitude * 10.0f) * 0.1f;
        timeCnt += Time.deltaTime;
        if (timeCnt > 0.2)
        {
            actVel.text = actual.ToString();
            timeCnt = 0;
        }
    }
}
