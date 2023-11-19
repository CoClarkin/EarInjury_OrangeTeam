using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIController : MonoBehaviour
{
// Change scene
    public void ChangeScene (string name) {
        SceneManager.LoadScene(name);
    }

// Exit game
    public void Quit() {
        Debug.Log("The Application has quit.");
        Application.Quit();
    }
}