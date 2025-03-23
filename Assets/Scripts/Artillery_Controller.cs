using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Artillery_Controller : MonoBehaviour
{

    public Transform Target;
   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Target != null)
        {





            transform.right = Target.position - transform.position;

            //transform.LookAt(Target.position, Vector3.up);

        }
        else
        {
            Debug.Log("null");
        }
        

        // Vector3 Look = transform.InverseTransformPoint(Target.transform.position);
        // float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

        // transform.Rotate(0,0,Angle);


        // var dir = Target.transform.position - transform.position;
        // var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
