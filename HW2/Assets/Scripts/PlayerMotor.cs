using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private bool isDead = false;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Fence") {
            isDead = true;
            // Debug.Log("Hit Fence");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            // Debug.Log("Player is dead");
            // Destroy(gameObject);
            // gameObject.SetActive(false);
            // gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            // stop the player animations
            gameObject.GetComponent<Animator>().enabled = false;
            return;
        }   
    }
}
