using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_RocketLauncher : Weapons 
{
	[Header("Rocket Launcher Necessary Objects")]
	public GameObject rocket;
	public GameObject explosion;
	public GameObject spawnPoint;
	
	[Header("Rocket Sounds")]
	public AudioClip explosionSound;

	[Header("Explosion parameters")]
	public float rocketForce;
	public float explosionRadius;
	public float explosionDamage;
	public LayerMask explosionLayerMask;
	AudioSource audioSource;

	bool isReloading;
	bool isCharged = true;
	int rocketInChamber;

	[SerializeField] private GameObject crosshair;

	private void Awake() 
	{
		audioSource = GetComponent<AudioSource>();
		ammoLeft = ammoAmount;
	}

	void OnEnable () 
	{
		isReloading = false;
		crosshair.SetActive(false);
	}

	private void OnDisable() 
	{
		crosshair.SetActive(true);
	}
	

	void Update () 
	{
		rocketInChamber = isCharged ? 1 : 0;
		ammoText.text = rocketInChamber + " / " + ammoLeft;

		if(Input.GetButtonDown("Fire1") && isCharged && !isReloading)
		{
			isCharged = false;
			audioSource.PlayOneShot(shotSound);
			GameObject rocketInstantiated = (GameObject) Instantiate(rocket, spawnPoint.transform.position, Quaternion.identity);
			rocketInstantiated.GetComponent<Rocket>().damage = explosionDamage;
			rocketInstantiated.GetComponent<Rocket>().radius = explosionRadius;
			rocketInstantiated.GetComponent<Rocket>().explosionSound = explosionSound;
			rocketInstantiated.GetComponent<Rocket>().layerMask = explosionLayerMask;
			rocketInstantiated.GetComponent<Rocket>().explosion = explosion;
			Rigidbody rocketRgbd = rocketInstantiated.GetComponent<Rigidbody>();
			rocketRgbd.AddForce(Camera.main.transform.forward * rocketForce, ForceMode.Impulse);
			Reload();
		} else if(Input.GetButtonDown("Fire1") && !isCharged && !isReloading)
		{
			Reload();
		}
	}

	private void Reload()
	{
		if(ammoLeft <= 0)
		{
			audioSource.PlayOneShot(emptyGunSound);
		} else 
		{
			StartCoroutine("ReloadTimer");
			ammoLeft--;
			isCharged = true;
		}
	}

	private IEnumerator ReloadTimer()
	{
		isReloading = true;
		audioSource.PlayOneShot(reloadSound);
		yield return new WaitForSeconds(3f);
		isReloading = false;
	}
}
