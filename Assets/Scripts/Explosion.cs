using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	[HideInInspector]
	public AudioClip explosionSound;
	private AudioSource audioSource;
	float lifespan;

	private void Awake() 
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Start() 
	{
		audioSource.PlayOneShot(explosionSound);
	}
	
	void Update () 
	{
		lifespan += Time.deltaTime;

		if(lifespan > 2)
		{
			Destroy(gameObject);
		}
	}
}
