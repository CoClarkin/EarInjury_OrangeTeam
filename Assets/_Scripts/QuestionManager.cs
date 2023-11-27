using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    
    public GameObject goodAnswer; 
    private ToggleGroup mytoggleGrp;
    public GameObject myPosFB;
    public GameObject myNegFB;

    // Start is called before the first frame update
    void Start()
    {
        //access toggle group component
        mytoggleGrp = transform.GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnConfirmClick()
    {
        for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).GetComponent<Toggle>())
                {
                    transform.GetChild(i).GetComponent<Toggle>().interactable = false;
                 }
            }
            
        //compare our answer to the correct answer (goodAnswer)
        if(mytoggleGrp.ActiveToggles().FirstOrDefault().gameObject.name == goodAnswer.name)
         {
            
            Debug.Log("correct");
            //enable the positive FB image
            myPosFB.SetActive(true);

            GameObject.Find("PanelWordQuiz").GetComponent<QuizManager>().scoreNB = GameObject.Find("PanelWordQuiz").GetComponent<QuizManager>().scoreNB + 1;
         }

        else
        {
            Debug.Log("loser");
            //enable neg FB image
            myNegFB.SetActive(true);
        }
           
    }
}