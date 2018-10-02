using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Bomb : MonoBehaviour 
{
	private Animator animator;
	public float explosionRadius;
	public float explosionDamage;

	private void Start() 
	{
		animator = GetComponent<Animator>();
		animator.SetBool("Explode", false);	
	}

	public void Explode()
	{
		animator.SetBool("Explode", true);
	}
}
