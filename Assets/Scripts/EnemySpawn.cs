using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    private enum State
    {
        Idle,
        Active,
    }


    [SerializeField]
    private ColliderTrigger colliderTrigger;
    [SerializeField]
    private EnemyAI[] enemySpawnArray;
    
    public Transform[] enemySpawnPosArray;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }
    void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

   private void  ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            startBattle();
        }
    }
    // Update is called once per frame
   

    void startBattle()
    {
        state = State.Active;
        foreach (EnemyAI enemy in enemySpawnArray)
        {
            int i = Random.Range(0, enemySpawnPosArray.Length);
            enemy.spawn(enemySpawnPosArray[i]);
        }
        state = State.Active;

    }
}
