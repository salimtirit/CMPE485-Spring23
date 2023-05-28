using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Vector3 _bulletScale = new Vector3(0.1f, 0.1f, 0.1f);

    [SerializeField]
    Text scoreText;

    public int score = 0;

    float _nextShootTime;
    Queue<Bullet> _pool = new Queue<Bullet>();

    void Start()
    {
        scoreText.text = "" + score;
    }

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

        bullet.transform.localScale = _bulletScale;
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

    public void IncrementScore()
    {
        score++;
        scoreText.text = "" + score;
    }

    public void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }

    bool CanShoot()
    {
        // if the left mouse key is pressed
        if (Input.GetMouseButton(0))
        {
            return true && Time.time >= _nextShootTime;
        }
        else
        {
            return false;
        }
    }

    public void BoostFireRate()
    {
        // increase bullet speed for 5 seconds
        var currentBulletSpeed = _bulletSpeed;
        _bulletSpeed = currentBulletSpeed * 2;
        StartCoroutine(ResetBulletSpeed());
    }

    IEnumerator ResetBulletSpeed()
    {
        yield return new WaitForSeconds(5.0f);
        _bulletSpeed = _bulletSpeed / 2;
    }

    //make the bullets bigger for 5 seconds
    public void BoostBulletSize()
    {
        _bulletScale = new Vector3(0.2f, 0.2f, 0.2f);
        StartCoroutine(ResetBulletSize());
    }

    IEnumerator ResetBulletSize()
    {
        yield return new WaitForSeconds(5.0f);
        _bulletScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
