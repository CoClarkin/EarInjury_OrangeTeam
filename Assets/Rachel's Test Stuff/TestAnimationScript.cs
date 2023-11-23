using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    public GameObject skull;

    // Start is called before the first frame update
    void Start()
    {
        skull.SetActive(true);
        //initialize state of first rotatable head
        //click one: stuff disappears/appears, animation 1 happens
    }
	
    private void OnMouseDown()
	{
        skull.SetActive(false);
    }

	// Update is called once per frame
	void Update()
    {
        
    }
}
