using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{

    private List<Basic_Medium_Bomber_Controller> enemyMediumBombers = new List<Basic_Medium_Bomber_Controller> ();
    private List<Basic_Medium_Bomber_Controller> allyMediumBombers = new List<Basic_Medium_Bomber_Controller>();
    public List<Artillery_Controller> enemyArtillery = new List<Artillery_Controller> ();
    public List<Artillery_Controller> allyArtillery = new List<Artillery_Controller>();
    public Basic_Medium_Bomber_Controller enemyBomberM;
    public Basic_Medium_Bomber_Controller allyBomberM;

    public GameObject allyMediumBomberPrefab;
    public GameObject enemyMediumBomberPrefab;

    public Transform enemySpawnT;
    public Transform allySpawnT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnMediumBomber(bool isEnemy)
    {

    }


}
