using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Basic_Enemy_Controller : MonoBehaviour
{

    public float speedOr;
    public Transform Target;
    public GameObject Ammunition;
    public int Health;
    public float attackRange;
    public float cooldown;
    private float cooling;
    private float speed;
    public Vector2 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        cooling = cooldown;
        speed = speedOr;
    }

    // Update is called once per frame
    void Update()
    {



       // targetPosition = Target.transform.position;

        cooling -= Time.deltaTime;



        if (cooling <= 0)
        {
            cooling = cooldown;
        }

        if (Target != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

             Vector3 delta = Target.transform.position - transform.position;

            float zAngle = Mathf.Atan2(delta.y, delta.x);
            zAngle = zAngle * Mathf.Rad2Deg - 90f;

            Vector3 newRotation = Vector3.zero;
            newRotation.z = zAngle;
            transform.rotation = Quaternion.Euler(newRotation);
        }

        if (Vector2.Distance(transform.position, Target.transform.position) <= attackRange)
        {
            Debug.Log("stop");
             speed = 0;
        }
        else if(Vector2.Distance(transform.position, Target.transform.position) > attackRange)
        {
            Debug.Log("find");
            speed = speedOr;
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
