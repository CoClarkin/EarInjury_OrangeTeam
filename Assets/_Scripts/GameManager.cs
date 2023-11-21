using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Create variable that is static and shared between all game managers
    public static GameManager singleton; 

    
    //Singleton
    void Awake() {
        
        if (singleton == null) {
            singleton = this;
        }
        
        else if (singleton != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //Change scene with index number
    public void ChangeScene (int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    //End game
    public void Quit() {
    Debug.Log("The Application has quit.");
        Application.Quit();
    }


    //Health meter with switch statements

    //Play audio on start (constant audio)

    //Play audio on canvas button click

}