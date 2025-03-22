using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Artillery_Controller : MonoBehaviour
{

    public Transform Target;
   public float speed = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Target != null)
        {

            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

            Vector3 delta = Target.transform.position - transform.position;

            float zAngle = Mathf.Atan2(delta.y, delta.x);
            zAngle = zAngle * Mathf.Rad2Deg - 90f;

            Vector3 newRotation = Vector3.zero;
            newRotation.z = zAngle;
            transform.rotation = Quaternion.Euler(newRotation);

            //transform.LookAt(Target, transform.up);

            //transform.LookAt(Target.position, Vector3.up);

        }

        

        // Vector3 Look = transform.InverseTransformPoint(Target.transform.position);
        // float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        // transform.Rotate(0,0,Angle);


        // var dir = Target.transform.position - transform.position;
        // var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
