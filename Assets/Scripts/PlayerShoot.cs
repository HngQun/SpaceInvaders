using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletposition;

    public float spawnRate = 0.1f;
    private float timer = 0f;


    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnbullet();
            timer = 0;
        }
    }

    void spawnbullet()
    {
        GameObject bullet01 = (GameObject)Instantiate(bullet);
        bullet01.transform.position = bulletposition.transform.position;
    }
}
