using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Demon_Animations : MonoBehaviour 
{
	private Animator animator;
	private Enemy enemy;
	private E_Demon_States demonBehaviour;

	void Start () 
	{
		animator = GetComponent<Animator>();
		enemy = GetComponent<Enemy>();
	}
	

	void Update () 
	{
		if(enemy.GetCurrentHealth() <= 0)
		{
			animator.SetBool("Death", true);
		} else 
		{
			animator.SetBool("Death", false);
		}

		if(demonBehaviour.IsShooting())
		{
			animator.SetBool("Shooting", true);
		} else 
		{
			animator.SetBool("Shooting", false);
		}
	}
}
