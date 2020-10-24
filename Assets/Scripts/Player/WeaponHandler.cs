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
    public Transform head;

    bool weaponActive = true;

    public float firedelay = 0.5f;
    float firetimer = 0f;

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

        if (inputhandler.isAttacking() && weaponActive && firetimer <= 0)
        {
            GameObject bullet = Instantiate(projectile);
            bullet.transform.position = projectileSpawn.position;
            bullet.transform.rotation = head.rotation;
            firetimer = firedelay;
        }

        if (firetimer > 0)
        {
            firetimer -= Time.deltaTime;
        }
    }
}
