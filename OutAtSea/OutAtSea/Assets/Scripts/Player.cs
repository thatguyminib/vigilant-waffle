using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Player instance;

    public Rigidbody rb;
    public float singleJumpForce;
    public bool didTap;
    public float forwardSpeed;
    public bool grounded;
    public bool canDoubleJump;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool canJump;
    public float fuel;
    public float fuelMax;
    public float fuelDepletion;
    public float fuelUpgrade;
    public bool canRefuel;
    public float moveSpeed;
    public float minMoveSpeed;
    public ParticleSystem jetParticles;
    public float timer;
    private Vector3 startPos;
    public ScoreManager scoreManager;
 

    public Slider fuelBar;

    private void Awake()
    {
        startPos = transform.position;
        instance = this;
        fuelBar = GameObject.Find("Fuelbar").GetComponent<Slider>();
    }


    void Start () {
        canJump = true;
        fuel = fuelMax;
        scoreManager = FindObjectOfType<ScoreManager>();
        fuelBar.value = CalculateFuel();
    }



    



    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!jetParticles.isPlaying)
                {
                  
                    jetParticles.Play();

                }

                canJump = false;
                fuel -= fuelDepletion * Time.deltaTime;
                didTap = true;
                canDoubleJump = true;
                grounded = false;
                moveSpeed += 2f * Time.deltaTime;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                didTap = false;
                if (jetParticles.isPlaying)
                {
                    jetParticles.Stop();
                    
                }
                moveSpeed -= 1f * Time.deltaTime;
            }
        }

       


        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && fuel > 0)
        {
            
            if (!jetParticles.isPlaying)
            {
                
                jetParticles.Play();
                
            }

            canJump = false;
            fuel -= fuelDepletion * Time.deltaTime;
            didTap = true;
            canDoubleJump = true;
            grounded = false;
            moveSpeed += 2f * Time.deltaTime;
          

        }
        else
        {
            didTap = false;
            if (jetParticles.isPlaying)
            {
                jetParticles.Stop();

            }
            moveSpeed -= 1f * Time.deltaTime;
        }

        if (fuel >= fuelMax)
        {
            fuel = fuelMax;
        }else if(fuel <= 0)
        {
            fuel = 0;
            canRefuel = false;
        }

        if(!canRefuel && grounded)
        {
           canRefuel = true;
        }

        

        if (!didTap && fuel < fuelMax && canRefuel)
        {
            fuel += fuelUpgrade * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
            {
                grounded = false;
            }

        if (!grounded)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
            var rot = transform.eulerAngles;
            rot.z = 0;
            transform.eulerAngles = rot;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
        }

        if(moveSpeed >= 10)
        {
            moveSpeed = 10;
        }else if (moveSpeed <= minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }
        fuelBar.value = CalculateFuel();

        scoreManager.scoreCount = Mathf.RoundToInt(Mathf.Abs(transform.position.x - startPos.x));

        if(scoreManager.scoreCount >= 100)
        {
            minMoveSpeed = 4;
        }

        if (scoreManager.scoreCount >= 200)
        {
            minMoveSpeed = 5;
        }

        if (scoreManager.scoreCount >= 300)
        {
            minMoveSpeed = 6;
        }

        if (scoreManager.scoreCount >= 400)
        {
            minMoveSpeed = 7;
        }



    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        
        if (didTap)
        {
            didTap = false;
            rb.AddForce(new Vector3(0, singleJumpForce, 0), ForceMode.Impulse);
            
        }
    
    }

    float CalculateFuel()
    {
        return fuel / fuelMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }



}
