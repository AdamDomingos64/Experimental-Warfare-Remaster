using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{

   
    public List<Artillery_Controller> enemyArtillery = new List<Artillery_Controller> ();
    public List<Artillery_Controller> allyArtillery = new List<Artillery_Controller>();
    public Basic_Medium_Bomber_Controller enemyBomberM;
    public Basic_Medium_Bomber_Controller allyBomberM;

    public Basic_Fighter_Controller enemyFighter;


    public GameObject allyMediumBomberPrefab;
    public GameObject enemyMediumBomberPrefab;
    public GameObject enemyFighterPrefab;


    public Transform enemySpawnT;
    public Transform allySpawnT;
    public Transform PlayerT;


    // Start is called before the first frame update
    void Start()
    {
        spawnMediumBomber(true);
        spawnMediumBomber(false);
        spawnFighter();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBomberM == null)
        { 
            spawnMediumBomber (true);
        }
        if (allyBomberM == null)
        {
            spawnMediumBomber (false);
        }
        if(enemyFighter == null)
        {
            spawnFighter();
        }




        foreach (var Artillery in allyArtillery)
        {
            if (Artillery != null)
            {
                enemyBomberM.Target = Artillery.transform;
                break;
            }
            else if (allyArtillery.Count == 0)
            {

                enemyBomberM.Target = null;
                break;

            }
        }
        foreach (var Artillery in enemyArtillery)
        {
            if (Artillery != null)
            {
                allyBomberM.Target = Artillery.transform;
                break;
            }
            else if ( enemyArtillery.Count == 0)
            {

                allyBomberM.Target = null;
                break;

            }

        }
        if (enemyBomberM.Target == null)
        {

            allyArtillery.Remove(allyArtillery[0]);

        }
      
        if (allyBomberM.Target == null)
        {

            enemyArtillery.Remove(enemyArtillery[0]);

        }
      



    }


    private void spawnFighter()
    {
        var newFighterobj = GameObject.Instantiate(enemyFighterPrefab, enemySpawnT.position, Quaternion.identity, null);
        enemyFighter = newFighterobj.GetComponent<Basic_Fighter_Controller>();
        enemyFighter.Target = PlayerT;
    }



    private void spawnMediumBomber(bool isEnemy)
    {

        

        if(isEnemy == true)
        {
            var newBomberMobj = GameObject.Instantiate(enemyMediumBomberPrefab, enemySpawnT.position, Quaternion.identity, null );
            enemyBomberM = newBomberMobj.GetComponent<Basic_Medium_Bomber_Controller>();
            

          
            
            
                

           
            
        }
        else
        {
            var newBomberMobj = GameObject.Instantiate(allyMediumBomberPrefab, allySpawnT.position, Quaternion.identity, null);
            allyBomberM = newBomberMobj.GetComponent<Basic_Medium_Bomber_Controller>();
            

          
           
         
            
        }





    }


}
