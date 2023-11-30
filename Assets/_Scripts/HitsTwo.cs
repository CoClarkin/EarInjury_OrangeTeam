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
    public GameObject HB0;
    public GameObject HB1;
    public GameObject HB2;
    public GameObject HB3;
    public GameObject HB4;
    public GameObject HB5;
    public GameObject HB6; 
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
            HB0.SetActive(true);
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
            HB0.SetActive(false);
            hit2text.SetActive(true);
            HB1.SetActive(true);

            break;
            
            case 3:
            Debug.Log("hit3");
            audioManager.SlapAudioTrigger();
            HB1.SetActive(false);
            HB2.SetActive(true);
            break;

            case 4:
            Debug.Log("hit4");
            audioManager.SlapAudioTrigger();
            HB2.SetActive(false);
            HB3.SetActive(true);
            break;

            case 5:
            Debug.Log("hit5");
            audioManager.SlapAudioTrigger();
            HB3.SetActive(false);
            HB4.SetActive(true);
            break;

            case 6:
            Debug.Log("hit6");
            audioManager.SlapAudioTrigger();
            HB4.SetActive(false);
            HB5.SetActive(true);
            break;

            
        }
            yield return new WaitForSeconds (5);
            isPlaying = false;

            
    }
}
