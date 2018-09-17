using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier_Animatons : MonoBehaviour 
{
	private Animator _animator;
	private EnemyStates enemyStates;
	private Enemy enemy;

	void Start () 
	{
		_animator = GetComponent<Animator>();
		enemyStates = GetComponent<EnemyStates>();
		enemy = GetComponent<Enemy>();
	}
	

	void Update () 
	{
		if(enemyStates.currentState == enemyStates.patrolState || enemyStates.currentState == enemyStates.chaseState)
		{
			_animator.SetFloat("Speed", 1);
		} else if(enemyStates.currentState == enemyStates.alertState && enemyStates.alertLookingForPlayer == true)
		{
			_animator.SetFloat("Speed", 1);
		} else 
		{
			_animator.SetFloat("Speed", 0);
		}

		if(enemyStates.currentState == enemyStates.attackState && enemyStates.onlyMelee == false)
		{
			_animator.SetBool("Shooting", true);
		} else 
		{
			_animator.SetBool("Shooting", false);
		}	

		if(enemy.GetCurrentHealth() <= 0)
		{
			_animator.SetBool("Dying", true);
		} else 
		{
			_animator.SetBool("Dying", false);
		}
	}
}
