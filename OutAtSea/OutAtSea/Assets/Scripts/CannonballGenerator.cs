using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballGenerator : MonoBehaviour {
    public static CannonballGenerator instance;

    public GameObject cannonball;
    public float timer;

    public int maxSpawn;
    public bool moveUp;
    public float speed;
    public float minTime;
    public float maxTime;


    // Use this for initialization
    void Start()
    {
        instance = this;
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }else
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }

        if(transform.position.y >= 9.76f)
        {
            moveUp = false;
        }
        if(transform.position.y <= -1.83f)
        {
            moveUp = true;
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && maxSpawn <= 2)
        {
            GameObject cannon = Instantiate(cannonball, transform.position, transform.rotation) as GameObject;
            
            timer = Random.Range(minTime, maxTime);
            maxSpawn++;
        }

    }
}
