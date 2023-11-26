using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    int hitList = 0;
    public Material transparentMat, transparentPartMat;

    public Renderer earRen;
    public Material earMat1, earMat2; //can earMat2 inherit the alpha properties of earMat1?

    public Renderer arteryRen;
    public Material arteryMat1, arteryMat2;
    public Animator arteryDistalAnim;

    public GameObject blood1, blood2, bloodClot;
    public Renderer blood1Ren, blood2Ren, bloodClotRen;
    public Material bloodMat;
    public Animator earExternalAnim;
    public ParticleSystem blood1Part, blood2Part;

    public Renderer skullRen;
    public Material skullMat1;
    

	// Start is called before the first frame update
	void Start()
    {
        //set everything to initial state
        earRen.material = earMat1;
        skullRen.material = skullMat1;
        arteryRen.material = arteryMat1;
        
    }
	
    void OnMouseDown()
	{
        switch (hitList)
        {
            case 0:
                //first zoom in, adjust material transparency
                Debug.Log("case 0");
                break;
            
            case 1:
                //ear bruises
                Debug.Log("case 1");
                StartCoroutine(CrossfadeMaterial(1.0f, earRen, earMat1, earMat2));  //fade to bruised ear material
                break;
            
            case 2:
                //artery breaks, blood starts flowing
                Debug.Log("case 2");
                arteryDistalAnim.SetTrigger("play_artery_break");  //play artery break animation
                blood1.SetActive(true);  //turn on flowing blood
                StartCoroutine(CrossfadeMaterial(5.0f, arteryRen, arteryMat1, arteryMat2));  //fade to dark artery material
                break;
            
            case 3:
                //hematoma forms
                Debug.Log("case 3");
                StartCoroutine(CrossfadeMaterial(5.0f, blood1Ren, bloodMat, transparentPartMat));  //fade out flowing blood
                blood2.SetActive(false); //turn off flowing blood
                StartCoroutine(CrossfadeMaterial(5.0f, blood2Ren, transparentPartMat, bloodMat));  //fade in floating blood
                blood2.SetActive(true);  //turn on floating blood
                earExternalAnim.SetTrigger("play_hematoma");  //play hematoma animaion
                break;
            
            case 4:
                //blood clots
                Debug.Log("case 4");
                StartCoroutine(CrossfadeMaterial(3.0f, blood2Ren, bloodMat, transparentPartMat));  //fade out floating blood
                bloodClot.SetActive(true);  //turn on blood clot
                StartCoroutine(CrossfadeMaterial(3.0f, bloodClotRen, transparentMat, arteryMat2));  //fade in blood clot
                StartCoroutine(CrossfadeMaterial(3.0f, arteryRen, arteryMat2, transparentMat));  //fade out distal artery
                break;

            case 5:
                //cartilage shrinks and changes color
                //need texture for this
                Debug.Log("case 5");
                break;

            case 6:
                //cauliflower ear develops
                Debug.Log("case 6");
                break;

            case 7:
                //ear drum rips
                Debug.Log("case 7");
                break;
        }
        hitList += 1;
    }

    private IEnumerator CrossfadeMaterial(float duration, Renderer ren, Material mat1, Material mat2)
    //fades one material into another over a defined duration of time
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            ren.material.Lerp(mat1, mat2, elapsedTime / duration);
            yield return null;
        }
    }

    //https://stackoverflow.com/questions/64510141/using-a-coroutine-in-unity3d-to-fade-a-game-object-out-and-back-in-looping-inf

}
