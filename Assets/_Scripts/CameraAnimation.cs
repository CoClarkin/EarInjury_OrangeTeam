using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator zoom;

void OnMouseDown()
{
    zoom.SetTrigger("EarZoomTrigger");

}
}
