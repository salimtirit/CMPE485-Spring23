using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public DeathMenu deathMenu;

    // On collision with the key, open the door
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Key") {
            // Open the door
            Debug.Log("Open Door");
            // Destroy the key
            Destroy(other.gameObject);

            // Get Left Door
            GameObject leftDoor = GameObject.Find("Left_Door_Final");
            GameObject keyLockKeyboard = GameObject.Find("KeyLock_Keyboard_Final");

            // Move left door and keylock to left by 0.5 units smoothly
            leftDoor.transform.Translate(0.5f, 0, 0);
            keyLockKeyboard.transform.Translate(0.5f, 0, 0);

            // Get Right Door
            GameObject rightDoor = GameObject.Find("Right_Door_Final");

            // Move right door to right by 0.5 units
            rightDoor.transform.Translate(-0.5f, 0, 0);

            deathMenu.ToggleEndMenu("You Win!");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
