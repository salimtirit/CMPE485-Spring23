using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(cube, new Vector3(-13f,10f,-18.3f), transform.rotation);
        }
    }
}
