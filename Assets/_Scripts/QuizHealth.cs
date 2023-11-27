using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizHealth : MonoBehaviour
{
    private int quizHealth = 4;
    public GameObject highhealthBar;
    public GameObject mediumhealthBar;

    public GameObject lowhealthBar;
    public GameObject finalPanel;
  
    void Update()
    {
        switch (quizHealth)
        {
            case 4:
                highhealthBar.SetActive(true);
                break;
            
            case 3:
                highhealthBar.SetActive(false);
                mediumhealthBar.SetActive(true);
                break;

            case 2:
                mediumhealthBar.SetActive(false);
                lowhealthBar.SetActive(true);
                break;
            
            case 1:
                lowhealthBar.SetActive(false);
                finalPanel.SetActive(true);
                break;
        }

        quizHealth -= 1;
    }
}
