using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

                    
                    Destroy(collision.gameObject);
                

        }
        if (collision.gameObject.tag == "BulletP")
        {
            
                
                Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.tag == "BombS")
        {
            
            

                Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.tag == "BombB")
        {



            Destroy(collision.gameObject);

        }
    }
}
