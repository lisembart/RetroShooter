using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHiding : MonoBehaviour 
{
	[SerializeField] private GameObject weapons;
	[SerializeField] private GameObject crosshair;
	[SerializeField] private GameObject ammoBar;
	public bool weaponHidden;

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.H))
		{
			HideShowWeapon();
		} 
	}

	public void HideShowWeapon()
	{
		if(weaponHidden)
		{
			weaponHidden = false;
			weapons.SetActive(true);
			crosshair.SetActive(true);
			ammoBar.SetActive(true);
		} else 
		{
			weaponHidden = true;
			weapons.SetActive(false);
			crosshair.SetActive(false);
			ammoBar.SetActive(false);
		}
	}
}
