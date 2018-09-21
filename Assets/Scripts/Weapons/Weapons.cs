using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public abstract class Weapons : MonoBehaviour
{
	[Header("Weapon parameters")]
	[SerializeField] protected Items_Weapons weaponType;
	[SerializeField] protected float weaponDamage;
	[SerializeField] protected float weaponRange;
	[SerializeField] protected GameObject bulletHole;
	[SerializeField] protected float timeToReload;

	[Header("Sounds")]
	public AudioClip shotSound;
	public AudioClip reloadSound;
	public AudioClip emptyGunSound;
	protected AudioSource audioSource;

	[Header("Ammo")]
	[SerializeField] protected int ammoAmount;
	[SerializeField] protected int ammoClipSize;
	protected int ammoLeft;
	protected int ammoClipLeft;
	[SerializeField] protected Text ammoText;
	[SerializeField] protected bool isReloading;
	protected bool isShot;	

	[Header("Other")]
	[SerializeField] protected GameObject bloodSplat;	

	void OnEnable () 
	{
		isReloading = false;
	}

	void Awake() 
	{
		audioSource = GetComponent<AudioSource>();
		ammoLeft = ammoAmount;
		ammoClipLeft = ammoClipSize;		
	}	

	void Update () 
	{
		ammoText.text = ammoClipLeft + " / " + ammoLeft;

		if(Input.GetButtonDown("Fire1") && !isReloading)
		{
			isShot = true;
		}

		if(Input.GetKeyDown(KeyCode.R) && !isReloading)
		{
			Reload();
		}		
	}

	protected void Reload()
	{
		int bulletsToReload = ammoClipSize - ammoClipLeft;
		if(ammoLeft >= bulletsToReload)
		{
			StartCoroutine("ReloadTimer");
			ammoLeft -= bulletsToReload;
			ammoClipLeft = ammoClipSize;
		} else if(ammoLeft < bulletsToReload && ammoLeft > 0)
		{
			StartCoroutine("ReloadTimer");
			ammoClipLeft += ammoLeft;
			ammoLeft = 0;
		} else if(ammoLeft <= 0)
		{
			audioSource.PlayOneShot(emptyGunSound);
		}
	}	

	IEnumerator ReloadTimer()
	{
		isReloading = true;
		audioSource.PlayOneShot(reloadSound);
		yield return new WaitForSeconds(timeToReload);
		isReloading = false;
	}
}
