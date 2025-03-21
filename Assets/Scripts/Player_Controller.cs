using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Rb2d;
    private Vector2  moveInput;
    private SpriteRenderer spriteRenderer;
    public GameObject Ammunition;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        

        moveInput.Normalize();

        Rb2d.velocity = moveInput * Speed;

        if (moveInput.x > 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

         else if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

             else if (moveInput.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

                 else if (moveInput.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKeyDown("space"))
        {
            Instantiate(Ammunition, transform.position, transform.rotation);
        }
    }
}
