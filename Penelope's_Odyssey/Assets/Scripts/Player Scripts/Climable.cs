using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climable : MonoBehaviour
{

    public Transform chController;
    bool inside = false;
    public float speedUpDown = 3.2f; //Speed for how fast going up and down 
    //public ThirdPersonMovement TPInput; //calling the ThirdPersonMovement Script

    // Start is called before the first frame update
    void Start()
    {
        //TPInput = GetComponent<ThirdPersonMovement>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Climable") //check if tag Climable is on object with colliders 
        {
            //TPInput.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Climable")
        {
            //TPInput.enabled = true;
            inside = !inside;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inside == true && Input.GetKey("w")) //move up object
        {
            chController.transform.position += Vector3.up/speedUpDown;
        }


      // if (inside == true && Input.GetKey("s"))
        //{
            //chController.transform.position += Vector3.down/speedUpDown; //Control to go down but didn't work
       // }

    }
}
