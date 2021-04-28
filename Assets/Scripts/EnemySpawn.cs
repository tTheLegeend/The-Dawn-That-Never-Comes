﻿using System.Collections;
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
        colliderTriggerForest.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        colliderTriggerCity.OnPlayerEnterTriggerCity += ColliderTrigger_OnPlayerEnterTriggerCity;
    }

   private void  ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        
        
            startBattle(enemySpawnPosArrayForest, enemySpawnArrayForest);
            
        
    }

    private void ColliderTrigger_OnPlayerEnterTriggerCity(object sender, System.EventArgs e)
    {
        
        
            startBattle(enemySpawnPosArrayCity, enemySpawnArrayCity);

        
    }
    // Update is called once per frame


    void startBattle(Transform[] enemySpawnPosArray, EnemyAI[] enemySpawnArray)
    {
        
        foreach (EnemyAI enemy in enemySpawnArray)
        {
            int i = Random.Range(0, enemySpawnPosArray.Length);
            enemy.spawn(enemySpawnPosArray[i]);
        }
        

    }
}