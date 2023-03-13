using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private Rigidbody rb;
   Vector3 initialLocation = new Vector3(13.77f,4.05f,-18.3f);
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

      if(this.transform.position.x > 18 || this.transform.position.x < -49.5f || this.transform.position.z < -49.5f || this.transform.position.z > 49.5f){
         this.transform.position = initialLocation;
         rb.velocity = Vector3.zero;
      }
    }
}
