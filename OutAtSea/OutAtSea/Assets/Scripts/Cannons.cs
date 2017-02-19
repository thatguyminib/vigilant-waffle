using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannons : MonoBehaviour {

    public Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        rb.AddForce((Vector3.left * speed), ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Destroyer")
        {
            CannonballGenerator.instance.maxSpawn--;
            Destroy(gameObject);
        }
    }
}
