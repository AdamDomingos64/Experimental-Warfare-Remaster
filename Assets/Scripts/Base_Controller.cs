using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Base_Controller : MonoBehaviour
{

    
    public bool isEnemy = false;
    public int maxHealth;
    private int Health;

    // Start is called before the first frame update
    private void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        


        if (Health <= 0)
        {

            SceneManager.LoadScene(0);
            
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BombB")
        {
            Health -= 1;
            Destroy(collision.gameObject);
        }

    }

}
