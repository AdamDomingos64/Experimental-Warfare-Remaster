using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basic_Enemy_Controller : MonoBehaviour
{

    public float speed;
    public GameObject Target;
    public GameObject Ammunition;
    public int Health;
    public float attackRange;
    public float cooldown;
    private float cooling;

    // Start is called before the first frame update
    void Start()
    {
        cooling = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        cooling -= Time.deltaTime;
        if (cooling <= 0)
        {
            cooling = cooldown;
        }

        if (Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(Target.transform.position, transform.position) <= attackRange)
        {
             speed = 0;
        }
        if (Health <= 0)
        {
            Destroy(this);
        }

        if ( cooling <= 0 && Vector2.Distance(Target.transform.position, transform.position) <= attackRange )
        {
            Instantiate(Ammunition);
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player_Bullet"))
        {
            Health -= 1;
        }
    }
}
