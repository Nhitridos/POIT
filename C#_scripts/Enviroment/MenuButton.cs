using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
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
            SceneManager.LoadScene("SampleScene"); // Zmena sceny na menu
        }
    }
}
