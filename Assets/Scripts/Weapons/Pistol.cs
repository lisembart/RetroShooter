using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Pistol : MonoBehaviour 
{
	[Header("Weapon parameters")]
	[SerializeField] private float pistolDamage;
	[SerializeField] private float pistolRange;

	[Header("Ammo")]
	[SerializeField] private int ammoAmount;
	[SerializeField] private int ammoClipSize;
	private int ammoLeft;
	private int ammoClipLeft;
	[SerializeField] private Text ammoText;
	[SerializeField] private bool isReloading;

	[Header("Sounds")]
	public AudioClip shotSound;
	public AudioClip reloadSound;
	public AudioClip emptyGunSound;
	private AudioSource audioSource;

	[Header("Sprites for animation")]
	public Sprite idlePistol;
	public Sprite shot1Pistol, shot2Pistol, shot3Pistol, shot4Pistol;
	bool isShot;

	void Awake() 
	{
		audioSource = GetComponent<AudioSource>();
		ammoLeft = ammoAmount;
		ammoClipLeft = ammoClipSize;
	}

	void Start () 
	{
		
	}
	

	void Update () 
	{
		ammoText.text = ammoClipLeft + " / " + ammoLeft;

		if(Input.GetButtonDown("Fire1"))
		{
			isShot = true;
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
	}

	void FixedUpdate() 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(isShot && ammoClipLeft > 0 && !isReloading)
		{
			isShot = false;
			ammoClipLeft--;
			audioSource.PlayOneShot(shotSound);
			StartCoroutine("Shot");
			if(Physics.Raycast(ray, out hit, pistolRange))
			{
				Debug.Log("I've hited " + hit.collider.gameObject.name);
				hit.collider.gameObject.SendMessage("Hit", pistolDamage, SendMessageOptions.DontRequireReceiver);
			}
		} else if(isShot && ammoClipLeft <= 0 && !isReloading)
		{
			isShot = false;
			Reload();
		}
	}

	private void Reload()
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

	IEnumerator Shot()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = shot1Pistol;
		yield return new WaitForSeconds(0.025f);
		spriteRenderer.sprite = shot2Pistol;
		yield return new WaitForSeconds(0.025f);
		spriteRenderer.sprite = shot3Pistol;
		yield return new WaitForSeconds(0.025f);
		spriteRenderer.sprite = shot4Pistol;
		yield return new WaitForSeconds(0.025f);
		spriteRenderer.sprite = idlePistol;
	}

	IEnumerator ReloadTimer()
	{
		isReloading = true;
		audioSource.PlayOneShot(reloadSound);
		yield return new WaitForSeconds(2);
		isReloading = false;
	}
}
