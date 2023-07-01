using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    // Coroutine to make the object go up at a constant rate and come back down after y position is 4.6 until y position is -0.4 and repeat
    IEnumerator GoDownCoroutine()
    {
        //boolean to check if the object is going down or up
        bool goingUp = true;
        while (true)
        {
            if (goingUp)
            {
                if (transform.position.y > 4.6)
                {
                    goingUp = false;
                }
                transform.position = transform.position + new Vector3(0, 0.01f, 0);
            }
            else
            {
                if (transform.position.y < -0.4)
                {
                    goingUp = true;
                }
                transform.position = transform.position + new Vector3(0, -0.01f, 0);
            }
            
            //Debug.Log(transform.position);
            
            yield return new WaitForSeconds(.001f);
        }
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        // Start coroutine
        StartCoroutine(GoDownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
