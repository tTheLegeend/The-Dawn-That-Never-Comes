using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private GameObject musicObj;
    private Music musicScript;
   


    [SerializeField]
    private ColliderTrigger colliderTriggerForest;
    [SerializeField]
    private ColliderTrigger colliderTriggerCity;
    [SerializeField]
    private ColliderTrigger colliderTriggerPark;
    [SerializeField]
    private EnemyAI[] enemySpawnArrayForest;
    [SerializeField]
    private EnemyAI[] enemySpawnArrayCity;
    [SerializeField]
    private EnemyAI[] enemySpawnArrayPark;
    
    

    public Transform[] enemySpawnPosArrayForest;
    public Transform[] enemySpawnPosArrayCity;
    public Transform[] enemySpawnPosArrayPark;





    void Start()
    {
        colliderTriggerForest.OnPlayerEnterTriggerForest += ColliderTrigger_OnPlayerEnterTriggerForest;
        colliderTriggerCity.OnPlayerEnterTriggerCity += ColliderTrigger_OnPlayerEnterTriggerCity;
        colliderTriggerPark.OnPlayerEnterTriggerPark += ColliderTrigger_OnPlayerEnterTriggerPark;

        musicObj = GameObject.Find("Music");
    }

    
    private void  ColliderTrigger_OnPlayerEnterTriggerForest(object sender, System.EventArgs e)
    {
        
        
        
            startBattle(enemySpawnPosArrayForest, enemySpawnArrayForest);


        musicScript = musicObj.GetComponent<Music>();
        musicScript.changeSong(1);
    }

    private void ColliderTrigger_OnPlayerEnterTriggerCity(object sender, System.EventArgs e)
    {
        
        
            startBattle(enemySpawnPosArrayCity, enemySpawnArrayCity);

        musicScript = musicObj.GetComponent<Music>();
        musicScript.changeSong(1);
    }
    private void ColliderTrigger_OnPlayerEnterTriggerPark(object sender, System.EventArgs e)
    {


        startBattle(enemySpawnPosArrayPark, enemySpawnArrayPark);

        musicScript = musicObj.GetComponent<Music>();
        musicScript.changeSong(1);
    }



    void startBattle(Transform[] enemySpawnPosArray, EnemyAI[] enemySpawnArray)
    {
        int i = 0;
        foreach (EnemyAI enemy in enemySpawnArray)
        {
            //int i = Random.Range(0, enemySpawnPosArray.Length);
            
            enemy.spawn(enemySpawnPosArray[i]);
             i ++;
        }
        

    }
}
