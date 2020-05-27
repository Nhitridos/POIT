using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoButton : MonoBehaviour
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
            SceneManager.LoadScene("AutoScene"); // Zmena sceny na scenu s vyber zelanej hodnoty rychlosti podla ID
        }
    }
}
