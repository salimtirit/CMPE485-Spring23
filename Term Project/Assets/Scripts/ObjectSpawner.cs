using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject star;

    public GameObject cuboid;

    public GameObject baseArea;

    // Start is called before the first frame update

    private float x_min;
    private float x_max;
    private float z_min;
    private float z_max;

    void Start()
    {
        CalculateBaseAreaBounds();
        StartCoroutine(SpawnObject());
    }

    void CalculateBaseAreaBounds()
    {
        x_min = baseArea.transform.position.x - 2.3f;
        x_max = baseArea.transform.position.x + 2.3f;
        z_min = baseArea.transform.position.z - 9f;
        z_max = baseArea.transform.position.z + 9f;
    }

    // Update is called once per frame
    void Update() { }

    // create a coroutine that spawns an object every 4 seconds based on a random number
    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(7.0f);
            GetObject();
        }
    }

    // return an object from the pool
    GameObject GetObject()
    {
        var random = Random.Range(0, 2);

        if (random == 0)
        {
            return Instantiate(star, GetRandomPosition(), star.transform.rotation);
        }
        else
        {
            return Instantiate(cuboid, GetRandomPosition(), cuboid.transform.rotation);
        }
    }

    Vector3 GetRandomPosition()
    {
        var x = Random.Range(x_min, x_max);
        var z = Random.Range(z_min, z_max);

        return new Vector3(x, 0.5f, z);
    }
}
