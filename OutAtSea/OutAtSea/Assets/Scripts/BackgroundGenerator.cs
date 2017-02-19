using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public float speed;
    public Player player;
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (player.didTap)
        //{
        //    speed += speedIncrease * Time.deltaTime;
        //}else if(!player.didTap)
        //{
        //    speed -= speedIncrease * Time.deltaTime;
        //}
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;

       

        
    }
}
