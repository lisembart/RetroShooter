using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
	public float radius;
	public float damage;
	public LayerMask layerMask;
	public GameObject  explosion;
	public AudioClip explosionSound;
	
	float rocketLife;
	float destroyAfter = 10f;

	private void Update() 
	{
		rocketLife += Time.deltaTime;
		if(rocketLife > destroyAfter)
		{
			Destroy(gameObject);
		}	
	}

	private void OnCollisionEnter(Collision col) 
	{
		ContactPoint contact = col.contacts[0];
		Collider[] hitColliders = Physics.OverlapSphere(contact.point, radius, layerMask);
		GameObject explosionInstiantated = (GameObject)Instantiate(explosion, contact.point, Quaternion.identity);
		explosionInstiantated.GetComponent<Explosion>().explosionSound = explosionSound;
		foreach(Collider collision in hitColliders)
		{
			collision.SendMessage("AddDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		Destroy(gameObject);
	}
}
