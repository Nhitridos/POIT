using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DataLoader : MonoBehaviour
{
    // Deklaracia premennych
    public string[] vels;
    public string velID;
    public InputField inField;
    private string idNoStr;
    private int idNo;
    private int lastIDNo;
    private float count = 0f;
    public GameObject oor;
    public Text wVelText;
    public string wVel;

    void Start()
    {
        oor.SetActive(false);
        wVelText.text = 0.ToString();
    }

    void Update()
    {
        // Nacitanie novo zadanej hodnoty z Input Fieldu
        Int32.TryParse(inField.text, out idNo); //String to Int
        if(idNo != lastIDNo)
        {
            count += Time.deltaTime;
            if(count > 2)
            {
                StartCoroutine(IDNoChooser(idNo));
                lastIDNo = idNo;
                count = 0;
                oor.SetActive(false);
            }
        }
    }

    // Vyber zelanej hodnoty rychlosti odpovedajucej danemu ID vyuzitim WWW class, ktora umoznuje nacitanie stranky na pozadi
    // Zo stranky sa cita cely string hodnot ID a rychlosti a z neho sa nasledne vybera zelane ID vyuzitim substringu
    IEnumerator IDNoChooser(int idNum)
    {
        WWW velData = new WWW("http://localhost/unity_vel_test/vels.php");
        yield return velData;

        try
        {
            string velDataStr = velData.text;
            vels = velDataStr.Split(';');
            wVel = GetDataValue(vels[idNum - 1], "Velocity:");
            wVelText.text = wVel;
        }
        catch
        {
            oor.SetActive(true);
        }
        
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index)+index.Length);
        return value;
    }
}
