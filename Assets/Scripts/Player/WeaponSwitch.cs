using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour 
{
	public bool autoFill;
	public List<Transform> weapons;
	public int initialWeapon;
	int selectedWeapon;

	[Header("Weapon Prefabs")]
	public GameObject pistolPrefab;
	public GameObject rocketLauncherPrefab;

	void Awake() 
	{
		if(autoFill)
		{
			weapons.Clear();
			foreach(Transform weapon in transform)
			{
				weapons.Add(weapon);
			}
		}
	}

	void Start () 
	{
		selectedWeapon = initialWeapon % weapons.Count;
		UpdateWeapon();
	}
	

	void Update () 
	{
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			selectedWeapon = (selectedWeapon + 1) % weapons.Count;
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			selectedWeapon = Mathf.Abs(selectedWeapon - 1) & weapons.Count;
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedWeapon = 0;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2) && weapons.Count > 1)
		{
			selectedWeapon = 1;
		}

		UpdateWeapon();
	}

	void UpdateWeapon()
	{
		for(int i = 0; i < weapons.Count; i++)
		{
			if(i == selectedWeapon)
			{
				weapons[i].gameObject.SetActive(true);
			} else
			{
				weapons[i].gameObject.SetActive(false);
			}
		}
	}

	public void AddWeapon(Items_Weapons weaponType)
	{
		int weaponToAdd = (int)weaponType;
		switch(weaponToAdd)
		{
			case 1:
				if(gameObject.GetComponentInChildren<W_Pistol>() == null)
				{
					GameObject pistol = Instantiate(pistolPrefab, transform);
					pistol.transform.parent = gameObject.transform;
					weapons.Add(pistol.transform);
					selectedWeapon = 1;
					break;
				}
				break;
			case 5:
				if(gameObject.GetComponentInChildren<W_RocketLauncher>() == null)
				{
					GameObject rocketLauncher = Instantiate(rocketLauncherPrefab, transform);
					rocketLauncher.transform.parent = gameObject.transform;
					weapons.Add(rocketLauncher.transform);
					break;
				}
				break;	
		}
	}
}
