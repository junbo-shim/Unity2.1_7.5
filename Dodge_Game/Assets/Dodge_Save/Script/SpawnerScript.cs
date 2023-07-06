using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(spawnRate <= timeAfterSpawn) 
        {
            timeAfterSpawn = 0;

            GameObject bullet = Instantiate(bulletPrefab, 
                transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMax, spawnRateMax);
        }


    }
}
