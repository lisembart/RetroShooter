using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyAI  
{
	EnemyStates enemy;
	public AttackState(EnemyStates enemy)
	{
		this.enemy = enemy;
	}
    public void OnTriggerEnter(Collider enemy)
    {
        throw new System.NotImplementedException();
    }

    public void ToAlertState()
    {
        throw new System.NotImplementedException();
    }

    public void ToAttackState()
    {
        throw new System.NotImplementedException();
    }

    public void ToChaseState()
    {
        throw new System.NotImplementedException();
    }

    public void ToPatrolState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateActions()
    {
        throw new System.NotImplementedException();
    }
}
