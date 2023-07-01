using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject walkingZombie;
    public GameObject runningZombie;
    public GameObject walkingHandsUpZombie;

    public float _interval;

    public GameObject enemyArea;

    private float x_min;
    private float x_max;
    private float z_min;
    private float z_max;

    // Start is called before the first frame update
    void Start()
    {
        _interval = 3.0f;

        CalculateEnemyAreaBounds();
        StartCoroutine(SpawnZombie());
        StartCoroutine(DecrementInterval());
    }

    void CalculateEnemyAreaBounds()
    {
        // TODO: Make theese values dynamic
        x_min = enemyArea.transform.position.x;
        x_max = enemyArea.transform.position.x + 9f;
        z_min = enemyArea.transform.position.z - 9f;
        z_max = enemyArea.transform.position.z + 9f;
    }

    // create a coroutine that spawns a zombie every 2 seconds
    IEnumerator SpawnZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            GetZombie();
        }
    }

    // decrement the interval by 0.1 every 10 seconds
    IEnumerator DecrementInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            _interval -= 0.1f;
        }
    }

    // return a zombie from the pool
    GameObject GetZombie()
    {
        // pick a random number between 0 and 11
        var random = Random.Range(0, 11);

        // pick a random position within the enemy area
        var position = new Vector3(Random.Range(x_min, x_max), 0.0f, Random.Range(z_min, z_max));

        //pick one of the zombies based on the random number
        if (random <= 4)
        {
            var zombie = Instantiate(walkingZombie, position, walkingZombie.transform.rotation);
            return zombie;
        }
        else if (random <= 9)
        {
            var zombie = Instantiate(
                walkingHandsUpZombie,
                position,
                walkingHandsUpZombie.transform.rotation
            );
            return zombie;
        }
        else
        {
            var zombie = Instantiate(runningZombie, position, runningZombie.transform.rotation);
            return zombie;
        }
    }
}
