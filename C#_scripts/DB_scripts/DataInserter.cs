using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataInserter : MonoBehaviour
{
    // Deklaracia premennych
    private string inputVelMag;
    public GameObject car;
    private Rigidbody rb;
    public Text velText;
    public Text coordsText;
    private float xc;
    private float yc;
    private float zc;

    void Start()
    {
        rb = car.GetComponent<Rigidbody>();
        velText.text = 0.ToString();
        coordsText.text = "x: " + 0.ToString() + "; y: " + 0.ToString() + "; z: " + 0.ToString();
    }

    void Update()
    {
        inputVelMag = (Mathf.Round(rb.velocity.magnitude * 10.0f) * 0.1f).ToString();
        velText.text = inputVelMag;
        xc = Mathf.Round(rb.transform.position.x * 10.0f) * 0.1f;
        yc = rb.transform.position.y - 0.3f;
        yc = Mathf.Round(yc * 10.0f) * 0.1f;
        zc = Mathf.Round(rb.transform.position.z * 10.0f) * 0.1f;
        coordsText.text = "x: " + xc + "; y: " + yc + "; z: " + zc;
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddVelData(inputVelMag, xc.ToString(), yc.ToString(), zc.ToString());
            //CreateText(inputVelMag, xc.ToString(), yc.ToString(), zc.ToString()); //doesn't work after game is built
        }
    }

    // Zapis aktulnej rychlosti a polohy vozidla do DB vyuzitim WWW class, ktora umoznuje nacitanie stranky na pozadi
    public void AddVelData(string velMag, string xcoord, string ycoord, string zcoord)
    {
        WWWForm form = new WWWForm();
        form.AddField("velPost", velMag);
        form.AddField("xPost", xcoord);
        form.AddField("yPost", ycoord);
        form.AddField("zPost", zcoord);

        WWW www = new WWW("http://localhost/unity_vel_test/insert_vels.php", form);
    }

    // Zapis aktulnej rychlosti a polohy do suboru - funguje len na debug, po vybuildeni nie
    void CreateText(string velMag, string xcoord, string ycoord, string zcoord)
    {
        string path = Application.dataPath + "/TextOut/log.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

        string content = "Velocity: " + velMag + " | X: " + xcoord + " | Y: " + ycoord + " | Z: " + zcoord + "\n";
        File.AppendAllText(path, content);
    }
}
