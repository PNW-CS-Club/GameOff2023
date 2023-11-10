using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHeld : MonoBehaviour {

    [SerializeField] private Image weaponHeld;
    [SerializeField] private Sprite weapon1;
    [SerializeField] private Sprite weapon2;
    [SerializeField] private Sprite weapon3;
    
    private void Update() {
        if ( Input.GetKeyDown(KeyCode.Alpha1) ) {
            weaponHeld.sprite = weapon1;
        } else if ( Input.GetKeyDown(KeyCode.Alpha2) ) {
            weaponHeld.sprite = weapon2;
        } else if ( Input.GetKeyDown(KeyCode.Alpha3) ) {
            weaponHeld.sprite = weapon3;
        }
    }
}