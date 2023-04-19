using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    // Coroutine to make the object go down at a constant rate and come back up after y position is -10.5 until y position is -5.5 and repeat
    IEnumerator GoDownCoroutine()
    {
        //boolean to check if the object is going down or up
        bool goingDown = true;
        while (true)
        {
            if (goingDown)
            {
                if (transform.position.y < -10.5)
                {
                    goingDown = false;
                }
                transform.position = transform.position + new Vector3(0, -0.01f, 0);
            }
            else
            {
                if (transform.position.y > -5.5)
                {
                    goingDown = true;
                }
                transform.position = transform.position + new Vector3(0, 0.01f, 0);
            }
            
            //Debug.Log(transform.position);
            
            yield return new WaitForSeconds(.01f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine
        StartCoroutine(GoDownCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
