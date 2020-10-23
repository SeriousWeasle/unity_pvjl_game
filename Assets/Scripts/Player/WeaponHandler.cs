using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public InputHandler inputhandler;
    public Transform pivot;
    public GameObject weapon;
    public Transform projectileSpawn;
    public GameObject projectile;

    bool weaponActive = true;

    // Update is called once per frame
    void Update()
    {
        if (inputhandler.scrollDirection() < 0)
        {
            weaponActive = false;
            weapon.SetActive(false);
        }
        else if (inputhandler.scrollDirection() > 0)
        {
            weaponActive = true;
            weapon.SetActive(true);
        }

        if (inputhandler.isAttacking() && weaponActive)
        {
            Instantiate(projectile).transform.position = projectileSpawn.position;
        }
    }
}
