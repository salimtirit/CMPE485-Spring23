using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
           rb.AddForce(new Vector3(0f,0f,-5f));
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
           rb.AddForce(new Vector3(0f,0f,5f));
        }   
        else if(Input.GetKey(KeyCode.UpArrow)){
           rb.AddForce(new Vector3(-5f,0f,0f));
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
           rb.AddForce(new Vector3(5f,0f,0f));
        }

        //if(position is not in the game field spawn back)
    }
}
