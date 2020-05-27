using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
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
            Application.Quit(); // Ukoncenie aplikacie
        }
    }
}
