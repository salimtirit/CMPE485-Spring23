using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude = 1.0f;

    private bool isDead = false;
    public DeathMenu deathMenu;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Fence") {
            isDead = true;
            // Debug.Log("Hit Fence");
        }

        Rigidbody body = hit.collider.attachedRigidbody;

        if(body != null) {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            body.AddForceAtPosition(forceDirection * forceMagnitude,transform.position, ForceMode.Impulse);
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
            // Get death menu
            // Debug.Log("Player is dead");
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            deathMenu.ToggleEndMenu("You died!");

            // Destroy(gameObject);
            // gameObject.SetActive(false);
            // gameObject.GetComponent<Renderer>().enabled = false;
            // stop the player animations
            return;
        }   
    }
}
