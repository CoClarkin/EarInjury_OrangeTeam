using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    int hitList = 0;
    Renderer arteryProximalRen;
    Renderer arteryDistalRen;
    Renderer cartilageRen;
    Renderer earExternalRen;
    Renderer earCoverRen;
    Renderer faceRen;
    Renderer eyesRen;
    Renderer hairRen;
    public Material transparentMat, transparentPartMat;

    public GameObject eyes, hair, face, skull, earExternal, earCover, cartilage, arteryProximal, arteryDistal, blood1, blood2, bloodClot;
    public Material earMat1, earMat2, skinMat, skinTransparentMat;
    //can earMat2 inherit the alpha properties of earMat1?


    public Material arteryMat1, arteryMat2;
    public Animator arteryDistalAnim;

    public Material bloodMat;
    public Animator earExternalAnim;
    public ParticleSystem blood1Part, blood2Part;

    public Material cartilageMat1, cartilageMat2;
    public Animator cartilageAnim;

    public Material skullMat1;

	private void Awake()
	{
        arteryProximalRen = arteryProximal.GetComponent<Renderer>();
        arteryDistalRen = arteryDistal.GetComponent<Renderer>();
        cartilageRen = cartilage.GetComponent<Renderer>();
        earExternalRen = earExternal.GetComponent<Renderer>();
        earCoverRen = earCover.GetComponent<Renderer>();
        faceRen = face.GetComponent<Renderer>();
        eyesRen = eyes.GetComponent<Renderer>();
        hairRen = hair.GetComponent<Renderer>();
    }

	// Start is called before the first frame update
	void Start()
    {
        //set everything to initial state
        //earRen.material = earMat1;
        //skullRen.material = skullMat1;
        //arteryRen.material = arteryMat1;
        
    }
	
    void OnMouseDown()
	{
        switch (hitList)
        {
            case 0:
                //first zoom in, adjust material transparency
                Debug.Log("case 0");
                StartCoroutine(CrossfadeMaterial(1.0f, faceRen, skinTransparentMat, skinMat));  //fade in face
                StartCoroutine(CrossfadeMaterial(1.0f, eyesRen, eyesRen.material, transparentMat));  //fade out eyes
                StartCoroutine(CrossfadeMaterial(1.0f, hairRen, hairRen.material, transparentMat));  //fade out hair
                StartCoroutine(CrossfadeMaterial(1.0f, arteryProximalRen, arteryMat1, transparentMat));  //fade out proximal artery
                StartCoroutine(CrossfadeMaterial(1.0f, arteryDistalRen, arteryMat1, transparentMat));  //fade out distal artery
                StartCoroutine(CrossfadeMaterial(1.0f, cartilageRen, cartilageMat1, transparentMat));  //fade out cartilage
                StartCoroutine(CrossfadeMaterial(1.0f, earExternalRen, skinTransparentMat, skinMat));  //fade in ear
                StartCoroutine(CrossfadeMaterial(1.0f, earCoverRen, skinTransparentMat, skinMat));  //fade in ear cover
                break;
            
            case 1:
                //ear bruises
                Debug.Log("case 1");
                skull.SetActive(false);  //turn off skull
                StartCoroutine(CrossfadeMaterial(1.0f, earExternalRen, earMat1, earMat2));  //fade to bruised ear material              
                break;
            
            case 2:
                //artery breaks, blood starts flowing
                Debug.Log("case 2");
                arteryDistalAnim.SetTrigger("play_artery_break");  //play artery break animation
                blood1.SetActive(true);  //turn on flowing blood
                StartCoroutine(CrossfadeMaterial(5.0f, arteryDistal.GetComponent<Renderer>(), arteryMat1, arteryMat2));  //fade to dark artery material
                break;
            
            case 3:
                //hematoma forms
                Debug.Log("case 3");
                StartCoroutine(CrossfadeMaterial(5.0f, blood1.GetComponent<Renderer>(), bloodMat, transparentPartMat));  //fade out flowing blood  
                blood2.SetActive(false); //turn off flowing blood
                StartCoroutine(CrossfadeMaterial(5.0f, blood2.GetComponent<Renderer>(), transparentPartMat, bloodMat));  //fade in floating blood
                blood2.SetActive(true);  //turn on floating blood
                earExternalAnim.SetTrigger("play_hematoma");  //play hematoma animaion
                break;
            
            case 4:
                //blood clots
                Debug.Log("case 4");
                StartCoroutine(CrossfadeMaterial(3.0f, blood2.GetComponent<Renderer>(), bloodMat, transparentPartMat));  //fade out floating blood
                bloodClot.SetActive(true);  //turn on blood clot
                StartCoroutine(CrossfadeMaterial(3.0f, bloodClot.GetComponent<Renderer>(), transparentMat, arteryMat2));  //fade in blood clot
                StartCoroutine(CrossfadeMaterial(3.0f, arteryDistal.GetComponent<Renderer>(), arteryMat2, transparentMat));  //fade out distal artery
                break;

            case 5:
                //cartilage shrinks and changes color
                //need texture for this
                Debug.Log("case 5");
                cartilageAnim.SetTrigger("play_shrink_cartilage");
                //crossfade texture
                //shrink ear skin too
                //fade bruise texture on outer ear
                //switch in aniamted cauliflower ear model to prep for next animation?
                //or figure out how to use keyframes. animation events? going to need this for onmousedown to work.
                break;

            case 6:
                //cauliflower ear develops
                Debug.Log("case 6");
                //fade in ear texture
                //play cauliflower ear animation
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
