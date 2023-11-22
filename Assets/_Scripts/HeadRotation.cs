using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
  private GameObject head;
    float yRotation;
    void Awake()
    {
        //trying to have the head rotate back to the original position on click of the ear and then the animation is triggered
        //head = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

  
    private void OnMouseDrag()
    {
        yRotation = Input.GetAxis("Mouse X");
        Debug.Log(yRotation);

        //this.transform.rotation = new Quaternion(this.transform.rotation.x ,this.transform.rotation.y + -yRotation * Time.deltaTime * 5f ,this.transform.rotation.z,1);
        transform.Rotate(0.0f,-yRotation *10.0f,0.0f);
    }
}
