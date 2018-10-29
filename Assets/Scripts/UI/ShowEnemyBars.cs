using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowEnemyBars : MonoBehaviour 
{
	[Header("UI Objects")]
	[SerializeField] private GameObject canvasObject;
	[SerializeField] private Image coversBar;
	[SerializeField] private Image shieldBar;
	[SerializeField] private Image healthBar;
	[SerializeField] private TextMeshProUGUI nameText;

	//Enemies parameters containers
	private float enemyHealth;
	private float enemyCovers;
	private float enemyShields;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			if(other.gameObject.GetComponent<Enemy>().IsAlive())
			{
				canvasObject.SetActive(true);
				nameText.text = other.gameObject.GetComponent<Enemy>().GetName();
				enemyHealth = other.gameObject.GetComponent<Enemy>().GetCurrentHealth();	
				coversBar.fillAmount = other.gameObject.GetComponent<Enemy>().GetCurrentCover() 
				/ other.gameObject.GetComponent<Enemy>().GetMaxCover();
				shieldBar.fillAmount = other.gameObject.GetComponent<Enemy>().GetCurrentShield() 
				/ other.gameObject.GetComponent<Enemy>().GetMaxShield();
				healthBar.fillAmount = other.gameObject.GetComponent<Enemy>().GetCurrentHealth() 
				/ other.gameObject.GetComponent<Enemy>().GetMaxHealth();						
			} else 
			{
				CleanBars();
			}
		}	
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			CleanBars();
		}	
	}

	private void CleanBars()
	{
		nameText.text = "";
		enemyHealth = 0;	
		canvasObject.SetActive(false);
	}
}
