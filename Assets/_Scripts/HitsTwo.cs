using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsTwo : MonoBehaviour
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
    

    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    // void OnMouseDown()
    // {
    //     StartCoroutine(hits());
    // }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isPlaying)
        {
            StartCoroutine(hits());
            totalHit ++;
        }
        
        
    }

    IEnumerator hits()
    {
        isPlaying = true;
         switch (totalHit)
        {
            case 1:
            Debug.Log("hit1");
            hit1text.SetActive(true);
            audioManager.SlapAudioTrigger();
            //if adio hasnt played bool = false if audio has played bool = true if 
            //fix in audio manager to play random range once 
            //HealthBar
            //Animation
            break;

            case 2:
            Debug.Log("hit2");
            audioManager.SlapAudioTrigger();
            hit1text.SetActive(false);
            hit2text.SetActive(true);
            break;
        }
            yield return new WaitForSeconds (5);
            isPlaying = false;

            
    }
}
