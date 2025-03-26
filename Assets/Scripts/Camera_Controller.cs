using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public List<GameObject> Aircraft = new List<GameObject>();
    public GameObject player;

    private void Update()
    {


        // if ( gameobject.GetComponent<Player_Controller>() = enabled)

      //  if ((gameObject.GetComponent("Player_Controller") as Player_Controller) != (null & enabled))
      //  {
            
       // }

        foreach (GameObject obj in Aircraft) 
        {
            if (obj.GetComponent<Player_Controller>()  != null  && obj.GetComponent<Player_Controller>().enabled)
                
            {
                player = obj.gameObject;
                break;
            }
        
        }

            if (player != null) 
        {


            transform.position = player.transform.position + new Vector3(0f, 0f, -10f);
        }
    }
}
