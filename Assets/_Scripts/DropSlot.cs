using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlot : MonoBehaviour, IDropHandler
{
    public int id;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
        if (eventData.pointerDrag.GetComponent<DragDrop>().id == id) 
            {
                Debug.Log("correct");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            }
        else
            {
                Debug.Log("false");
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().quizHealth = GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().quizHealth - 1; 
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().ChangeBar();
            }
    }
}
