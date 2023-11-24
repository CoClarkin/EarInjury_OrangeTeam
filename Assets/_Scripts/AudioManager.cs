using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class AudioManager : MonoBehaviour

{
    public Slider volumeSlider;
    public GameObject audioSettings;
    

    //dont destroy game object with background audio between scenes

   void Awake()
   {
    DontDestroyOnLoad(transform.gameObject);
    
    //if no player prefs set, set volume to 1; otherwise load player prefs

    if (!PlayerPrefs.HasKey("background volume"))
        {
            PlayerPrefs.SetFloat("background volume", 1);
            Load();
        }
        else
        {
            Load();
        }

   }

   //change audio volume with slider

    public void VolumeChanger()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    
        //Save player preferences
        //save volume

        public void Save()
        {
            PlayerPrefs.SetFloat("background volume", volumeSlider.value);
        }


        //Load player preferences

        public void Load()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("background volume");
        }

        //on new scene find the panel audio, find its slider and set the value and volume to the player prefs
        void OnLevelWasLoaded()
        { 
           audioSettings = GameObject.Find("PanelAudio");
           volumeSlider = audioSettings.GetComponentInChildren<Slider>();
           volumeSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
           Load();
        }
        public void ValueChangeCheck()
	    {
		    VolumeChanger();
	    }

}
