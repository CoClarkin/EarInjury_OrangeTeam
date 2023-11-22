using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour

{
    public Slider volumeSlider;

    //dont destroy game object with background audio between scenes
   void Awake()
   {
    DontDestroyOnLoad(transform.gameObject);

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
        //load saved volume

        public void Load()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("background volume");
        }

}
