using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject player;

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0f , 0f, -10f);
    }
}
