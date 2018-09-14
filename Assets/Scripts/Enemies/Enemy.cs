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

	[Header("UI")]
	[SerializeField] private GameObject UICanvas;
	[SerializeField] private Image coversBar;
	[SerializeField] private Image shieldBar;
	[SerializeField] private Image healthBar;
	[SerializeField] private Text nameText;

	private void Start() 
	{
		currentHealth = maxHealth;
		currentCover = maxCovers;
		currentShield = maxShield;

		enemyStates = GetComponent<EnemyStates>();
		navMeshAgent = GetComponent<NavMeshAgent>();	
	}

	private void Update() 
	{
		nameText.text = name;

		if(currentHealth <= 0)
		{
			UICanvas.SetActive(false);
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

		healthBar.fillAmount = currentHealth / maxHealth;
	}
}
