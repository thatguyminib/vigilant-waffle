using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualWaveGenerator : MonoBehaviour {

    public GameObject wave;
    public Transform generationPoint;
    public float distanceBetween;
    private float waveWidth;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + 1 + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(wave, transform.position, transform.rotation);
        }
	}
}
