using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisGenerator : MonoBehaviour {

    public static DebrisGenerator instance;

    public GameObject debris;
    public Transform generationPoint;
    public float distanceBetween;
    private float debrisWidth;

    public float timerMin;
    public float timerMax;

    public float timer;

    public int maxSpawn;


    // Use this for initialization
    void Start()
    {
        instance = this;
        timer = Random.Range(timerMin, timerMax);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && maxSpawn <= 2)
        {
            Instantiate(debris, transform.position, transform.rotation);
            timer = Random.Range(timerMin, timerMax);
            maxSpawn++;
        }

    }
}
