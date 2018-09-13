using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(FaceCamera))]
public class Enemy : MonoBehaviour 
{
	public int maxHealth;
	float currentHealth;
	EnemyStates enemyStates;
	NavMeshAgent navMeshAgent;

	private void Start() 
	{
		currentHealth = maxHealth;
		enemyStates = GetComponent<EnemyStates>();
		navMeshAgent = GetComponent<NavMeshAgent>();	
	}

	private void Update() 
	{
		if(currentHealth <= 0)
		{
			enemyStates.enabled = false;
			navMeshAgent.enabled = false;			
		}	
	}

	public float GetCurrentHealth()
	{
		return currentHealth;
	}

	public void Hit(float damage)
	{
		currentHealth -= damage;
	}
}
