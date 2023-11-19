using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondClick : MonoBehaviour
{
    bool isClicked;
    public GameObject myPanel;

    // Removing the panel set active on second click
    public void Close()
    {
        isClicked = !isClicked;

        if(isClicked == true)
        {
            myPanel.SetActive(true);
        }

        if(isClicked == false)
        {
            myPanel.SetActive(false);
        }
    }
}
