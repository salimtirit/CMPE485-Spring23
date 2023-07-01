using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DeathMenu deathMenu;

    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the player falls off the platform, show the death menu
        if (transform.position.y < -10)
        {
            deathMenu.ToggleEndMenu("You Lose!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Script" + other.gameObject.tag);
        if (other.gameObject.tag == "zombie" || other.gameObject.tag == "zombie(Clone)")
        {
            deathMenu.ToggleEndMenu("You Lose!");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Star")
        {
            Destroy(other.gameObject);
            gun.BoostFireRate();
        }

        if (other.gameObject.tag == "Cuboid")
        {
            Destroy(other.gameObject);
            gun.BoostBulletSize();
        }
    }
}
