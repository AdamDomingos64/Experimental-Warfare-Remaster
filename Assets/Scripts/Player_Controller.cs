using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{
    public float Speed;
    public float lookSpeed;
    public Rigidbody2D Rb2d;
    private Vector2  moveInput;
    private SpriteRenderer spriteRenderer;
    public GameObject Ammunition;
    public int maxHealth;
    public int Health;
    public bool isAlly;
    public bool isBomber;
    public bool isFighter;
    public Camera_Controller Spotlight;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Health = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.up * Time.deltaTime * Speed;

        moveInput.x = Input.GetAxisRaw("Horizontal");

        if (moveInput.x > 0) 
        {
        
            transform.Rotate(0, 0, -10 * Time.deltaTime * lookSpeed);
        }

         else if (moveInput.x < 0)
        {
            
            transform.Rotate(0, 0, 10 * Time.deltaTime * lookSpeed);
        }

        

        if (Input.GetKeyDown("space"))
        {
            Instantiate(Ammunition, transform.position, transform.rotation);
        }


        if (Health <= 0)
        {
            if (isAlly)
            {
                Spotlight.Aircraft.Remove(this.gameObject);

            }
            Destroy(this.gameObject);

        }





        if (isAlly == true)
        {
            if (isBomber == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    this.gameObject.GetComponent<Player_Controller>().enabled = false;
                    this.gameObject.GetComponent<Basic_Medium_Bomber_Controller>().enabled = true;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    this.gameObject.GetComponent<Player_Controller>().enabled = true;
                    this.gameObject.GetComponent<Basic_Medium_Bomber_Controller>().enabled = false;
                }
            }
            else if (isFighter == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {

                    this.gameObject.GetComponent<Player_Controller>().enabled = true;
                    this.gameObject.GetComponent<Basic_Fighter_Controller>().enabled = false;

                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    this.gameObject.GetComponent<Player_Controller>().enabled = false;
                    this.gameObject.GetComponent<Basic_Fighter_Controller>().enabled = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 1;
            Destroy(collision.gameObject);
           
        }
    }
}
