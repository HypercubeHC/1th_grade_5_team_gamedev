using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{
    public Dropdown Dropdown;

    public void Change()
    {
        if (Dropdown.value == 0)
        {
            Screen.SetResolution(1024, 768, true);
        }
        else if (Dropdown.value == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if (Dropdown.value == 2)
        {
            Screen.SetResolution(1366, 768, true);
        }
        else if (Dropdown.value == 3)
        {
            Screen.SetResolution(1440, 900, true);
        }
        else if (Dropdown.value == 4)
        {
            Screen.SetResolution(1600, 1200, true);
        }
        else if (Dropdown.value == 5)
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }
}
