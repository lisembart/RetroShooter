using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FaceCamera))]
public class Enemy : MonoBehaviour 
{
	public int health;
	public bool canMeleeAttack;
	public bool canShoot;
	public float meleeDamage;
	public float shootDamage;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	public void Hit(int damage)
	{
		health = health - damage;
	}
}
