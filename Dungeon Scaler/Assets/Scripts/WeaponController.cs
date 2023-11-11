using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{ 
    /* Weapon Controller
     * 
     * This script is responsible for controlling the weapon.
     * 
     * It should be attached to the weapon object.
     * 
     * It should be able to:
     *  - Detect when the weapon is swung
     *  - Detect when the weapon hits an enemy
     *  - Deal damage to the enemy
     *  - Play a sound when the weapon hits an enemy
     *  - Play a sound when the weapon is swung
     *  - Play an animation when the weapon is swung
     *  - Play an animation when the weapon hits an enemy
     * 
     *
     * NOTE: //TODO
     */

    SpriteRenderer sr;
<<<<<<< Updated upstream
    Player player;  //weapon controller is attached to player, so it can access player script
=======
    Player player;  //weapon controller is attached too player, so it can access player script
>>>>>>> Stashed changes
    GameObject weaponObject; //weapon that is passed to this script
    public WeaponSword weapon; //script that controls the weapon (i think this'll be renamed to WeaponSword, or WeaponBow etc etc, idk yet)  TODO:
    bool hasWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<Player>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onFire() {
        if (hasWeapon) {
            weapon.Fire();
        }
    }

    public void weaponControl(Vector3 dir) {  //change to vector2 maybe? idk havent tested yet
        if (hasWeapon) {
            weapon.weaponDirControl(dir);
            flipWeapon(dir);
            weaponSortOrder(dir);
        }
    }

    public void setWeapon(GameObject obj) {
        weaponObject = (GameObject)Instantiate (obj, this.transform.position, this.transform.rotation);
        weaponObject.transform.position = new Vector3(weaponObject.transform.position.x, weaponObject.transform.position.y - 0.4f);
        weaponObject = transform.parent = this.transform;
        weapon = weaponObject.GetComponent<WeaponSword>();
        hasWeapon = true;
    }

    void weaponDirControl(Vector3 posToFace) {
        //rotates weapon so it'll face the provided vector direction(player dir) 
        float angle = Mathf.Atan2((posToFace.y - transform.position.y), (posToFace.x - transform.position.x)) * Mathf.Rad2Deg;
        weaponObject.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void flipWeapon(Vector3 posToFace) {
        //flips weapon so it'll face the provided vector direction(player dir) 
        if (posToFace.x > this.transform.postiion.x) {   //TODO test, 
            //facing right i think
            sr.flipY = false; 
        } else {
            //facing left
            sr.flipY = true;
        }
    }

    void weaponSortOrder(Vector3 posToFace) { 
        if (posToFace.y > this.transform.position.y) {
            //weapon is behind player
            sr.sortingOrder = player.getSortingOrder() - 2;    //getSortingOrder may rely on player script 
        } else {
            //weapon is in front of player
            sr.sortingOrder = player.getSortingOrder() + 2;
        }
    }
}
