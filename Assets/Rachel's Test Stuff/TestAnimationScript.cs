using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    int hitList = 0;

    public GameObject eyes, hair, face, skull, earExternal, earCover, 
        cartilage, arteryProximal, arteryDistal, blood1, blood2, bloodClot;

    Renderer eyesRen, hairRen, faceRen, earExternalRen, earCoverRen,
        cartilageRen, arteryProximalRen, arteryDistalRen, bloodClotRen;

    public Material skullMat1, earMat1, earMat2, skinMat, skinTransparentMat, cartilageMat1, cartilageMat2, 
        arteryMat1, arteryMat2, bloodMat, transparentMat, transparentPartMat;

    public Texture earTexture;    
    public Texture holdingTexture;
    //can earMat2 inherit the alpha properties of earMat1?

    public Animator arteryDistalAnim, earExternalAnim, cartilageAnim;

    public ParticleSystem blood1Part, blood2Part;

    public Material dummyMat;


	private void Awake()
	{
        eyesRen = eyes.GetComponent<Renderer>();
        hairRen = hair.GetComponent<Renderer>();
        faceRen = face.GetComponent<Renderer>();
        earExternalRen = earExternal.GetComponent<Renderer>();
        earCoverRen = earCover.GetComponent<Renderer>();
        cartilageRen = cartilage.GetComponent<Renderer>();
        arteryProximalRen = arteryProximal.GetComponent<Renderer>();
        arteryDistalRen = arteryDistal.GetComponent<Renderer>();
        bloodClotRen = bloodClot.GetComponent<Renderer>();
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
                StartCoroutine(CrossfadeTexture(1.0f, earExternalRen, earMat1, earMat2));  //fade to bruised ear material              
                //BRUISED EAR MATERIAL NOT WORKING
                break;
            
            case 2:
                //artery breaks, blood starts flowing
                Debug.Log("case 2");
                StartCoroutine(CrossfadeMaterial(1.0f, faceRen, faceRen.material, skinTransparentMat));  //switch to transparent face
                StartCoroutine(CrossfadeMaterial(1.0f, earExternalRen, earExternalRen.material, skinTransparentMat));  //switch to transparent ear
                StartCoroutine(CrossfadeMaterial(1.0f, earCoverRen, earCoverRen.material, skinTransparentMat));  //switch to transparent ear cover
                StartCoroutine(CrossfadeMaterial(1.0f, arteryProximalRen, arteryProximalRen.material, arteryMat1));  //fade in proximal artery
                StartCoroutine(CrossfadeMaterial(1.0f, arteryDistalRen, arteryDistalRen.material, arteryMat1));  //fade in distal artery
                StartCoroutine(CrossfadeMaterial(1.0f, cartilageRen, cartilageRen.material, cartilageMat1));  //fade in cartilage
                arteryDistalAnim.SetTrigger("play_artery_break");  //play artery break animation
                blood1.SetActive(true);  //turn on flowing blood
                StartCoroutine(CrossfadeMaterial(5.0f, arteryDistalRen, arteryMat1, arteryMat2));  //fade to dark artery material
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
                StartCoroutine(CrossfadeMaterial(3.0f, bloodClotRen, transparentMat, arteryMat2));  //fade in blood clot
                StartCoroutine(CrossfadeMaterial(3.0f, arteryDistalRen, arteryDistalRen.material, transparentMat));  //fade out distal artery
                break;

            case 5:
                //cartilage shrinks and changes color
                //need texture for this
                Debug.Log("case 5");
                cartilageAnim.SetTrigger("play_shrink_cartilage");
                //crossfade texture
                StartCoroutine(CrossfadeMaterial(10.0f, bloodClotRen, bloodClotRen.material, transparentMat));  //fade out blood clot?
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
                bloodClot.SetActive(false);
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

    private IEnumerator CrossfadeTexture(float duration, Renderer ren, Material mat1, Material mat2)
    //fades one material into another over a defined duration of time
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            dummyMat = new Material(Shader.Find("Standard"));
            
            ren.material.SetTexture("_MainTex", holdingTexture);
            dummyMat.mainTexture = earTexture;
           

            earExternalRen.material.Lerp(ren.material, dummyMat, elapsedTime / duration);
          

           
            yield return null;
        }
    }


    //https://stackoverflow.com/questions/64510141/using-a-coroutine-in-unity3d-to-fade-a-game-object-out-and-back-in-looping-inf

}
