using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour 
{
	[Header("Health Parameters")]
	[SerializeField] private int maxHealth;
	[SerializeField] float currentHealth;
	[SerializeField] private AudioClip hitSound;
	private AudioSource playerAudioSource;
	[SerializeField] private FlashScreen flashScreen;

	[Header("UI")]
	[SerializeField] private Image healthBar;
	
	void Start () 
	{
		playerAudioSource = GetComponent<AudioSource>();
		currentHealth = maxHealth;
	}

	public void EnemyHit(float damage)
	{
		playerAudioSource.PlayOneShot(hitSound);
		currentHealth -= damage;
		flashScreen.FlashHit();
		healthBar.fillAmount = currentHealth / maxHealth;
	}

	public void AddHealth(float healthToAdd)
	{
		flashScreen.FlashMedpack();
		if(currentHealth < maxHealth)
		{
			currentHealth += healthToAdd;
		}
	}
	
}
