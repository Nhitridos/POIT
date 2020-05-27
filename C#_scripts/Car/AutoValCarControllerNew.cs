using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AutoValCarControllerNew : MonoBehaviour
{
    // Deklaracia premennych
    public Text actVelText;
    public InputField inField;
    public GameObject oor; // Out of Range
    private float count = 0f;
    private float value;
    private float lastValue = 0f;
    public Text wished;
    private Rigidbody rb;
    public GameObject car;
    private float actual;
    private float throttle;
    private int throttleCnt;
    private float timeCnt = 0f;
    public GameObject fWall;
    public GameObject bWall;
    private float carPos;
    private float fWallPos;
    private float bWallPos;
    private bool flag;

    void Start()
    {
        actVelText.text = 0.ToString();
        wished.text = 0.ToString();
        oor.SetActive(false);
        rb = car.GetComponent<Rigidbody>();
        throttleCnt = 0;
        flag = false;
    }

    void FixedUpdate()
    {
        // Aktualna hodnota rychlosti
        actual = Mathf.Round(rb.velocity.magnitude * 10.0f) * 0.1f;

        float.TryParse(inField.text, out value); // Nacitanie hodnoty z Input Fieldu a konverzia string to float

        // Zmena rychlosti na aktualne zelanu zadanu rychlost
        if ((value >= 0) && (value <= 10))
        {
            if (value != lastValue)
            {
                count += Time.deltaTime;
                if (count > 2)
                {
                    lastValue = value;
                    count = 0;
                    oor.SetActive(false);
                    wished.text = value.ToString();
                    throttleCnt += 1;
                    rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    flag = true; // Zabezpecenie opatovneho rozbehu
                    if (throttleCnt % 2 != 0) // Zmena smeru jazdy pri kazdej volbe novej rychlosti
                    {
                        throttle = 1;
                    }
                    else
                    {
                        throttle = -1;
                    }
                }
            }
        }
        else
        {
            oor.SetActive(true);
        }

        carPos = rb.transform.position.z; // Poloha vozidla
        fWallPos = fWall.transform.position.z; // Poloha prednej steny
        bWallPos = bWall.transform.position.z; // Poloha zadnej steny

        if (((fWallPos - carPos) > (lastValue * 12)) && ((bWallPos - carPos) < (lastValue * -12))) // Zistovanie vzdialenosti od prekazky
        {
            rb.velocity = lastValue * throttle * new Vector3(0f, 0f, 1f); // Jazda v dostatocnej vzdialenosti od prekazky
            flag = false;
        }
        else
        {
            if (flag) // Rozbeh po brzdeni
            {
                rb.velocity = lastValue * throttle * new Vector3(0f, 0f, 1f); 
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
                    rb.AddForce(new Vector3(0, 0, lastValue * -throttle * Time.deltaTime * 1200));
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
            actVelText.text = actual.ToString();
            timeCnt = 0;
        }
    }
}
