using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

   


    [SerializeField]
    private ColliderTrigger colliderTriggerForest;
    [SerializeField]
    private ColliderTrigger colliderTriggerCity;
    [SerializeField]
    private EnemyAI[] enemySpawnArrayForest;
    [SerializeField]
    private EnemyAI[] enemySpawnArrayCity;

    public Transform[] enemySpawnPosArrayForest;
    public Transform[] enemySpawnPosArrayCity;

   


    void Start()
    {
        colliderTriggerForest.OnPlayerEnterTriggerForest += ColliderTrigger_OnPlayerEnterTriggerForest;
        colliderTriggerCity.OnPlayerEnterTriggerCity += ColliderTrigger_OnPlayerEnterTriggerCity;
    }

    
    private void  ColliderTrigger_OnPlayerEnterTriggerForest(object sender, System.EventArgs e)
    {
        
        
        
            startBattle(enemySpawnPosArrayForest, enemySpawnArrayForest);
            
        
    }

    private void ColliderTrigger_OnPlayerEnterTriggerCity(object sender, System.EventArgs e)
    {
        
        
            startBattle(enemySpawnPosArrayCity, enemySpawnArrayCity);

        
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
