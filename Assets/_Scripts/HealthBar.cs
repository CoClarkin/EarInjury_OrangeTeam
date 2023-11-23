using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int totalHealth = 2;
    public GameObject full_healthBar;
    public GameObject medium_healthBar;

    public GameObject low_healthBar;
  
    void OnMouseDown()
    {
        switch (totalHealth)
        {
            case 0:
                medium_healthBar.SetActive(true);
                break;
            
            case 1:
                low_healthBar.SetActive(true);
                break;

            case 2:
                full_healthBar.SetActive(true);
                break;

            default:
                break;
        }
    }
}
