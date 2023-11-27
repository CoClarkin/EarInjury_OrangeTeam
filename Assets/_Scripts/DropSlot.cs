using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
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
    
            }
    }
}
