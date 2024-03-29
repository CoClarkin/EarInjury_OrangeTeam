using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsTwo : MonoBehaviour
{
    public int totalHit = 1;
    public AudioSource slapCompilation;
    public TestAnimationScript testAnimationScript;


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
    private AudioManager audioManager; 
    

    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        testAnimationScript = FindObjectOfType<TestAnimationScript>();
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
            HB0.SetActive(false);
            HB1.SetActive(true);
            audioManager.SlapAudioTrigger();
            testAnimationScript.EarAnim2();
            //if adio hasnt played bool = false if audio has played bool = true if 
            //fix in audio manager to play random range once 
            //HealthBar
            //Animation
            break;

            case 2:
            Debug.Log("hit2");
            audioManager.SlapAudioTrigger();
            HB1.SetActive(false);
            HB2.SetActive(true);
            hit1text.SetActive(false);
            hit2text.SetActive(true);
            testAnimationScript.EarAnim3();
            break;
            
            case 3:
            Debug.Log("hit3");
            audioManager.SlapAudioTrigger();
            HB2.SetActive(false);
            HB3.SetActive(true);
            hit2text.SetActive(false);
            hit3text.SetActive(true);
            testAnimationScript.EarAnim4();
            break;

            case 4:
            Debug.Log("hit4");
            audioManager.SlapAudioTrigger();
            HB3.SetActive(false);
            HB4.SetActive(true);
            hit3text.SetActive(false);
            hit4text.SetActive(true);
            testAnimationScript.EarAnim5();
            break;

            case 5:
            Debug.Log("hit5");
            audioManager.SlapAudioTrigger();
            HB4.SetActive(false);
            HB5.SetActive(true);
            hit4text.SetActive(false);
            hit5text.SetActive(true);
            testAnimationScript.EarAnim6();
            break;

            case 6:
            Debug.Log("hit6");
            audioManager.SlapAudioTrigger();
            hit5text.SetActive(false);
            hit6text.SetActive(true);
            testAnimationScript.EarAnim7();
            break;


        }
            yield return new WaitForSeconds (1.5f);
            isPlaying = false;

            
    }
}
