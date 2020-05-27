using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualButton : MonoBehaviour
{
    private bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
    }

    public void OnButtonClick()
    {
        if (!clicked)
        {
            clicked = true;
            SceneManager.LoadScene("ManualScene"); // Zmena sceny na scenu s manualnym ovladanim auta
        }
    }
}
