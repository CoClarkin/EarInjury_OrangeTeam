using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    int hitList = 0;
	public Animator arteryDistalAnim;
    public GameObject blood1;
    public Material arteryMat;
    public Material arteryMatDark;
    public Renderer arteryRen;

    public Renderer skullRen;
    public Material skullMat1;
    public Material transparentMat;
    //public Color color1;
    //public Color color2;

	// Start is called before the first frame update
	void Start()
    {
        //skullRen.material.color = color1;
        skullRen.material = skullMat1;
        arteryRen.material = arteryMat;
        blood1.SetActive(false);
    }
	
    void OnMouseDown()
	{
        switch (hitList)
        {
            case 0:
                StartCoroutine(FadeOut());
                //ear bruises
                Debug.Log("case 0");
                break;
            
            case 1:
                //artery breaks, blood starts flowing
                Debug.Log("case 1");
                arteryDistalAnim.SetTrigger("play_artery_break");  //play artery break animation
                blood1.SetActive(true);  //turn visibility of blood flow on
                StartCoroutine(ArteryDarken());  //darken distal artery over 5 seconds
                break;
            
            case 2:
                
                Debug.Log("case 2");
                break;
            
            case 3:
                Debug.Log("case 3");
                break;

            case 4:
                Debug.Log("case 4");
                break;

            case 5:
                Debug.Log("case 5");
                break;

            case 6:
                Debug.Log("case 6");
                break;
        }
        hitList += 1;
    }

    private IEnumerator EarBruise()
    {
        //can we reuse the same artery darken coroutine? do I have to write another one?
        //can a coroutine take in a parameter?
        yield return null;
    }
    
    private IEnumerator ArteryDarken()
        //fades one artery material into another
    {
        float elapsedTime = 0f;
        float duration = 5.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            arteryRen.material.Lerp(arteryMat, arteryMatDark, elapsedTime / duration);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        float duration = 1.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            skullRen.material.Lerp(skullMat1, transparentMat, elapsedTime / duration);
            yield return null;
        }
    }

    //private IEnumerator FadeOut()
    //{
    //    float elapsedTime = 0f;
    //    float duration = 1.0f;

    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        skullRen.material.color = Color.Lerp(color1, color2, elapsedTime / duration);
    //        yield return null;
    //    }   
    //}
    //https://stackoverflow.com/questions/64510141/using-a-coroutine-in-unity3d-to-fade-a-game-object-out-and-back-in-looping-inf

}
