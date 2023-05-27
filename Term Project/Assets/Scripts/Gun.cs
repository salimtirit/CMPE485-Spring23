using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Bullet BulletPrefab;

    [SerializeField]
    Transform BulletSpawnPoint;

    [SerializeField]
    float _delay = 0.2f;

    [SerializeField]
    float _bulletSpeed = 10.0f;

    [SerializeField]
    CharacterController _controller;

    float _nextShootTime;
    Queue<Bullet> _pool = new Queue<Bullet>();

    void Update()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _nextShootTime = Time.time + _delay;
        var bullet = GetBullet();
        bullet.transform.position = BulletSpawnPoint.position;
        bullet.transform.rotation = BulletSpawnPoint.rotation;

        var characterVelocity = _controller.velocity;
        characterVelocity.y = 0.0f;

        bullet.GetComponent<Rigidbody>().velocity =
            BulletSpawnPoint.forward * _bulletSpeed + characterVelocity;
    }

    Bullet GetBullet()
    {
        if (_pool.Count > 0)
        {
            var bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instantiate(
                BulletPrefab,
                BulletSpawnPoint.position,
                BulletSpawnPoint.rotation
            );
            bullet.SetGun(this);
            return bullet;
        }
    }

    public void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }

    bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }
}
