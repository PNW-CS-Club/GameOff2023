using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : MonoBehaviour
{

    public GameObject attack;
    public Transform attackPos;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onFire() {
        //sword code here :)
    }

    public void weaponHit() {
        GameObject attack = Instantiate(attack, attackPos.transform.position, this.attackPos.rotation);
        g.GetComponent<Attack>().myCreator = this.transform.parent.gameObject;
    }
}
