using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "")
        {
            Health -= 1;
            Destroy(collision.gameObject);
           
        }
    }
}
