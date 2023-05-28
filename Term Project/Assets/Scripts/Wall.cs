using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public DeathMenu deathMenu;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "zombie")
        {
            deathMenu.ToggleEndMenu("You Lose!");
            Destroy(other.gameObject);
        }
    }
}
