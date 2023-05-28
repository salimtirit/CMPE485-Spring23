using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float _lifeTime = 15.0f;

    Gun _gun;

    public void SetGun(Gun gun)
    {
        _gun = gun;
    }

    void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
        Debug.Log("Bullet disabled after time");
        _gun.AddToPool(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        // check collision with zombie or zombie clone
        if (collision.gameObject.tag == "zombie" || collision.gameObject.tag == "zombie(Clone)")
        {
            Debug.Log("Zombie hit");
            // destroy zombie
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall hit");
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("Bullet disabled after collision");
            _gun.AddToPool(this);
        }
    }
}
