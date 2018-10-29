using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(FaceCamera))]
public class Enemy : MonoBehaviour 
{
	[Header("Parameters")]
	[SerializeField] private string name;
	public int maxHealth;
	[SerializeField] private float currentHealth;
	public int maxCovers;
	[SerializeField] private float currentCover;
	public int maxShield;
	[SerializeField] private float currentShield;
	private EnemyStates enemyStates;
	private NavMeshAgent navMeshAgent;
	[SerializeField] private bool isAlive;

	private Rigidbody enemyRgbd;

	private void Start() 
	{
		currentHealth = maxHealth;
		currentCover = maxCovers;
		currentShield = maxShield;

		enemyStates = GetComponent<EnemyStates>();
		navMeshAgent = GetComponent<NavMeshAgent>();	
		enemyRgbd = GetComponent<Rigidbody>();
	}

	private void Update() 
	{
		if(currentHealth <= 0)
		{
			isAlive = false;
			enemyStates.enabled = false;
			navMeshAgent.enabled = false;
			enemyRgbd.isKinematic = true;
		} else 
		{
			isAlive = true;
		}
	}

	public bool IsAlive()
	{
		return isAlive;
	}

	public float GetCurrentHealth()
	{
		return currentHealth;
	}

	public float GetMaxHealth()
	{
		return maxHealth;
	}

	public float GetCurrentCover()
	{
		return currentCover;
	}

	public float GetMaxCover()
	{
		return maxCovers;
	}

	public float GetCurrentShield()
	{
		return currentShield;
	}

	public float GetMaxShield()
	{
		return maxShield;
	}	

	public string GetName()
	{
		return name;
	}

	public void AddDamage(float damage)
	{
		if(currentCover > 0)
		{
			currentCover -= damage;
		} else if(currentCover <= 0 && currentShield > 0)
		{
			currentShield -= damage;
		} else if(currentCover <= 0 && currentShield <= 0 && currentHealth > 0)
		{
			currentHealth -= damage;
		}
	}
}
