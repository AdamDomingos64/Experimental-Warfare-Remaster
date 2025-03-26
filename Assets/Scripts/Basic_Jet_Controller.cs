using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Basic_Jet_Controller : MonoBehaviour
{

    public float speedOr;
    public Transform Target;
    public GameObject Ammunition;
    public int maxHealth;
    public float attackRange;
    public float cooldown;
    private float cooling;
    private float speed;
    public int Health;
    public Vector2 targetPosition;
    public GameObject Weakness;
    public bool isAlly;
    public Camera_Controller Spotlight;


    // Start is called before the first frame update
    void Start()
    {
        cooling = cooldown;
        speed = speedOr;
        Health = maxHealth;
        if (isAlly == true)
        {
            Spotlight.Aircraft.Add(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {



       // targetPosition = Target.transform.position;

        cooling -= Time.deltaTime;



       

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
        if (Target != null)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) <= attackRange)
            {
                // Debug.Log("stop");
                speed = 0;
            }
            else if (Vector2.Distance(transform.position, Target.transform.position) > attackRange)
            {
                // Debug.Log("find");
                speed = speedOr;
            }
            Debug.Log("target is not null");
        }
        else if (Target == null)
        {
            speed = 0;
            Debug.Log("target is null");
        }

        if (Health <= 0)
        {
            if (isAlly)
            {
                Spotlight.Aircraft.Remove(this.gameObject);

            }
            Destroy(this.gameObject);
        }

        if (Target != null)
        {
            if (cooling <= 0 && Vector2.Distance(Target.transform.position, transform.position) <= attackRange)
            {
                Instantiate(Ammunition, transform.position, transform.rotation);
            }
            if (cooling <= 0)
            {
                cooling = cooldown;
            }
        }
        else if (Target == null)
        {
            cooling = 1;
        }

        if (isAlly == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                this.gameObject.GetComponent<Player_Controller>().enabled = false;
                this.gameObject.GetComponent<Basic_Jet_Controller>().enabled = true;

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.gameObject.GetComponent<Player_Controller>().enabled = false;
                this.gameObject.GetComponent<Basic_Jet_Controller>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                this.gameObject.GetComponent<Player_Controller>().enabled = false;
                this.gameObject.GetComponent<Basic_Jet_Controller>().enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                this.gameObject.GetComponent<Player_Controller>().enabled = true;
                this.gameObject.GetComponent<Basic_Jet_Controller>().enabled = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            // healthbar.UpdateHealthBar(Health, maxHealth);
            if (gameObject.name == "Goblin(Clone)")
            {


                {
                    Health -= 1;
                    Destroy(collision.gameObject);
                }

            }

        }
        if (collision.gameObject.tag == "BulletP")
        {
            if (gameObject.name == "Lippisch(Clone)")
            {
                Health -= 1;
                Destroy(collision.gameObject);
            }
        }
    }

}
