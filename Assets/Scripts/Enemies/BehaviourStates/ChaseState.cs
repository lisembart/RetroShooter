using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyAI 
{
	EnemyStates enemy;
	public ChaseState(EnemyStates enemy)
	{
		this.enemy = enemy;
	}

    public void OnTriggerEnter(Collider enemy)
    {
        throw new System.NotImplementedException();
    }

    public void ToAlertState()
    {
        Debug.Log("I've lost the player from my eyes");
        enemy.currentState = enemy.alertState;
    }

    public void ToAttackState()
    {
        Debug.Log("I'm attacking the player");
        enemy.currentState = enemy.attackState;
    }

    public void ToChaseState()
    {
        
    }

    public void ToPatrolState()
    {
        
    }

    public void UpdateActions()
    {
        Watch();
        Chase();
    }

    void Watch()
    {
        RaycastHit hit;
        if(Physics.Raycast(enemy.transform.position, enemy.vision.forward, out hit, enemy.patrolRange, enemy.raycastMask) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            enemy.lastKnownPosition = hit.transform.position;
        } else 
        {
            ToAlertState();
        }
    }

    void Chase()
    {
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();

        if(enemy.navMeshAgent.remainingDistance <= enemy.attackRange && enemy.onlyMelee)
        {
            enemy.navMeshAgent.Stop();
            ToAttackState();
        } else if(enemy.navMeshAgent.remainingDistance <= enemy.shootRange && !enemy.onlyMelee)
        {
            enemy.navMeshAgent.Stop();
            ToAttackState();
        }
    }
}
