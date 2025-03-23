using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Artillery_Controller : MonoBehaviour
{

    public Transform Target;
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

        if (Target != null)
        {

            transform.right = Target.position - transform.position;          

        }


        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BombS")
        {
            Health -= 1;

        }
    }

}
