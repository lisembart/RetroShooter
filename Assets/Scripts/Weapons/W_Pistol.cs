using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Pistol : Weapons
{
	[Header("Sprites for animation")]
	public Sprite idlePistol;
	public Sprite shot1Pistol, shot2Pistol, shot3Pistol, shot4Pistol;
	
	void FixedUpdate() 
	{
		Vector2 bulletOffset = Random.insideUnitCircle * DynamicCrosshair.spread;
		Vector3 randomTarget = new Vector3(Screen.width/2 + bulletOffset.x, Screen.height/2 + bulletOffset.y, 0);
		Ray ray = Camera.main.ScreenPointToRay(randomTarget);
		RaycastHit hit;

		if(isShot && ammoClipLeft > 0 && !isReloading)
		{
			isShot = false;
			DynamicCrosshair.spread += DynamicCrosshair.PISTOL_SHOOTING_SPREAD;
			ammoClipLeft--;
			audioSource.PlayOneShot(shotSound);
			StartCoroutine("ShotAnimation");
			if(Physics.Raycast(ray, out hit, weaponRange))
			{
				if(hit.transform.CompareTag("Enemy"))
				{
					Instantiate(bloodSplat, hit.point, Quaternion.identity);
					Debug.Log("I've hited " + hit.collider.gameObject.name);
					if(hit.collider.gameObject.GetComponent<EnemyStates>().currentState == hit.collider.gameObject.GetComponent<EnemyStates>().patrolState
					|| hit.collider.gameObject.GetComponent<EnemyStates>().currentState == hit.collider.gameObject.GetComponent<EnemyStates>().alertState)
					{
						hit.collider.gameObject.SendMessage("HiddenShot", transform.parent.transform.position, SendMessageOptions.DontRequireReceiver);
					}				
					hit.collider.gameObject.SendMessage("AddDamage", weaponDamage, SendMessageOptions.DontRequireReceiver);
				} 
				//Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up,hit.normal));
			}
		} else if(isShot && ammoClipLeft <= 0 && !isReloading)
		{
			isShot = false;
			Reload();
		}
	}

	IEnumerator ShotAnimation()
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
}
