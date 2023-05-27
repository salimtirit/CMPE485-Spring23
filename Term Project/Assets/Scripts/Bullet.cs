using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float _lifeTime = 5.0f;

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
        _gun.AddToPool(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet hit " + collision.gameObject.name);
        gameObject.SetActive(false);
        _gun.AddToPool(this);
    }
}
