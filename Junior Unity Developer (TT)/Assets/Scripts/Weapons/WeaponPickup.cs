﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {

    public RaycastWeapon weaponFab;


    private void OnTriggerEnter(Collider other) {
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon) {
            RaycastWeapon newWeapon = Instantiate(weaponFab);
            activeWeapon.Equip(newWeapon);
            Destroy(gameObject);
        }

        AiWeapons aiWeapons = other.gameObject.GetComponent<AiWeapons>();
        if (aiWeapons) {
            RaycastWeapon newWeapon = Instantiate(weaponFab);
            aiWeapons.Equip(newWeapon);
            Destroy(gameObject);
        }
    }
}
