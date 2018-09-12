using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : IEnemyAI 
{
	EnemyStates enemy;
    float timer = 0;
	public AlertState(EnemyStates enemy)
	{
		this.enemy = enemy;
	}

    public void OnTriggerEnter(Collider enemy)
    {
        throw new System.NotImplementedException();
    }

    public void ToAlertState()
    {
        
    }

    public void ToAttackState()
    {
        
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
    }

    public void UpdateActions()
    {
        Search();
        Watch();
        if(enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance)
        {
            enemy.alertLookingForPlayer = false;
            LookAround();
        }
    }

    void Watch()
    {
        RaycastHit hit;
        if(Physics.Raycast(enemy.transform.position, enemy.vision.forward, out hit, enemy.patrolRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            enemy.navMeshAgent.destination = hit.transform.position;
            ToChaseState();
        }
    }

    void LookAround()
    {
        timer += Time.deltaTime;
        if(timer >= enemy.stayAlertTime)
        {
            timer = 0;
            ToPatrolState();
        }
    }

    void Search()
    {
        enemy.alertLookingForPlayer = true;
        enemy.navMeshAgent.destination = enemy.lastKnownPosition;
        enemy.navMeshAgent.Resume();
    }
}
