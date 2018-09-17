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
	public bool showingBars = false;
	[SerializeField] private GameObject UICanvas;
	[SerializeField] private Image coversBar;
	[SerializeField] private Image shieldBar;
	[SerializeField] private Image healthBar;
	[SerializeField] private Text nameText;
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
		nameText.text = name;
		
		if(showingBars)
		{
			UICanvas.SetActive(true);
		} else 
		{
			UICanvas.SetActive(false);
		}

		if(currentHealth <= 0)
		{
			UICanvas.SetActive(false);
			enemyStates.enabled = false;
			navMeshAgent.enabled = false;
			enemyRgbd.isKinematic = true;
		}	
	}

	public float GetCurrentHealth()
	{
		return currentHealth;
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

		coversBar.fillAmount = currentCover / maxCovers;
		shieldBar.fillAmount = currentShield / maxShield;
		healthBar.fillAmount = currentHealth / maxHealth;
	}

	public void SetBars(bool value)
	{
		showingBars = value;
	}
}
