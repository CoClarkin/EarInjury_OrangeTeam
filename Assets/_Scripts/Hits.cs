using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Hits : MonoBehaviour

//public GameObject ear;
//public Animator myAnimator;
//AudioSource slapCompilation
{


    public int totalHit = 1;
    public AudioSource slapCompilation;
    public GameObject hit1text;
    public GameObject hit2text;
    public GameObject hit3text;
    public GameObject hit4text;
    public GameObject hit5text;
    public GameObject hit6text;
    private AudioManager audioManager;
 
    //public Animator Reachel's Animation

   void Start()
   {
    
    audioManager = FindObjectOfType<AudioManager>();

   }
   
   void OnMouseDown()
   {
        Debug.Log("is HIT"); 
        //sets pannel active when ear is clicked
        switch (totalHit)
        {
            case 1:
            Debug.Log("hit1");
            hit1text.SetActive(true);
            audioManager.SlapAudioTrigger();
            //need to set sprite active
            //start corouteen

            break;
            //RefrenceSwitch from healthbar code
            //call audiohit compilation
            //call Hit 1 Text
            //trigger Earanimation
            //trigger delay animatino
            // if above active  move to next set else mouse down inactive
            case 2:
            Debug.Log("hit2");
            hit2text.SetActive(true);
            break;
            //count increase
         }
    //coroutine function
    }
}
