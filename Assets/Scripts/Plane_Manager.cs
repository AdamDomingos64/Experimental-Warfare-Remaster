using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_Manager : MonoBehaviour
{

   
    public List<Artillery_Controller> enemyArtillery = new List<Artillery_Controller> ();
    public List<Artillery_Controller> allyArtillery = new List<Artillery_Controller>();

    public Basic_Medium_Bomber_Controller enemyBomberM;
    public Basic_Medium_Bomber_Controller allyBomberM;

    public Basic_Heavy_Bomber_Controller enemyBomberH;
    public Basic_Heavy_Bomber_Controller allyBomberH;

    public Basic_Interceptor_Controller enemyInterceptor;
    public Basic_Interceptor_Controller allyInterceptor;

    public Basic_Fighter_Controller enemyFighter;


    public GameObject allyMediumBomberPrefab;
    public GameObject enemyMediumBomberPrefab;

    public GameObject allyHeavyBomberPrefab;
    public GameObject enemyHeavyBomberPrefab;

    public GameObject enemyFighterPrefab;

    public GameObject allyInterceptorPrefab;
    public GameObject enemyInterceptorPrefab;

    public GameObject enemyBase;
    public GameObject allyBase;

    public Transform enemySpawnT;
    public Transform allySpawnT;
    public Transform PlayerT;


    // Start is called before the first frame update
    void Start()
    {
        spawnMediumBomber(true);
        spawnMediumBomber(false);
        spawnFighter();
        spawnInterceptor(true);
        spawnInterceptor(false);
       
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
        if (enemyInterceptor == null)
        {
            spawnInterceptor(true);
        }
        if (allyInterceptor == null)
        {
            spawnInterceptor(false);
        }
        if (enemyBomberH == null && allyArtillery.Count <= 0)
        {
            var newBomberHobj = GameObject.Instantiate(enemyHeavyBomberPrefab, enemySpawnT.position, Quaternion.identity, null);
            enemyBomberH = newBomberHobj.GetComponent<Basic_Heavy_Bomber_Controller>();

            if (allyBase.transform != null)
            {
                enemyBomberH.Target = allyBase.transform;
            }
            else
            {
                enemyBomberH.Target = null;
            }
        }
        if (allyBomberH == null && enemyArtillery.Count <= 0) 
        {
            var newBomberHobj = GameObject.Instantiate(allyHeavyBomberPrefab, allySpawnT.position, Quaternion.identity, null);
            allyBomberH = newBomberHobj.GetComponent<Basic_Heavy_Bomber_Controller>();

            if (enemyBase.transform != null)
            {
                allyBomberH.Target = enemyBase.transform;
            }
            else
            {
                allyBomberH.Target = null;
            }
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
        if (enemyBomberM.Target == null && allyArtillery.Count > 0)
        {

            allyArtillery.Clear ();

        }
      
        if (allyBomberM.Target == null && enemyArtillery.Count > 0)
        {

            enemyArtillery.Clear();

        }





        if (allyBomberM.transform != null)
        {
            enemyInterceptor.Target = allyBomberM.transform;
        }
        else
        {
            enemyInterceptor.Target = null;

        }


        if (enemyBomberM.transform != null)
        {
            allyInterceptor.Target = enemyBomberM.transform;
        }
        else
        {
            allyInterceptor.Target = null;
        }



       
    



    }


    private void spawnFighter()
    {
        var newFighterobj = GameObject.Instantiate(enemyFighterPrefab, enemySpawnT.position, Quaternion.identity, null);
        enemyFighter = newFighterobj.GetComponent<Basic_Fighter_Controller>();
        enemyFighter.Target = PlayerT;
    }

    private void spawnInterceptor(bool isEnemy)
    {
        if (isEnemy == true)
        {
            var newInterceptorobj = GameObject.Instantiate(enemyInterceptorPrefab, enemySpawnT.position, Quaternion.identity, null);
            enemyInterceptor = newInterceptorobj.GetComponent<Basic_Interceptor_Controller>();
          

        }
        else
        {
            var newInterceptorobj = GameObject.Instantiate(allyInterceptorPrefab, allySpawnT.position, Quaternion.identity, null);
            allyInterceptor = newInterceptorobj.GetComponent<Basic_Interceptor_Controller>();

            

        }
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
