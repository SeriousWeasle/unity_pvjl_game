using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public InputHandler inputhandler;
    public Transform pivot;

    public GameObject quadshotgun;
    public QuadShotgun qsg;
    public GameObject rifle;
    public Rifle rfl;
    public GameObject torch;

    public int shellCount = 10;
    public int bulletCount = 5;

    int weapcount = 2;
    public int weaponIndex { private set; get; }

    bool holdingWeapon = true;

    // Update is called once per frame
    void Update()
    {
        if (inputhandler.scrollDirection() < 0)
        {
            //Decrement weaponIndex
            if (weaponIndex <= 0)
            {
                weaponIndex = weapcount;
            }
            else
            {
                weaponIndex--;
            }
        }

        else if (inputhandler.scrollDirection() > 0)
        {
            //increment weapon index
            if (weaponIndex >= weapcount)
            {
                weaponIndex = 0;
            }
            else
            {
                weaponIndex++;
            }
        }

        //toggle weapons between active states
        switch (weaponIndex)
        {
            case 0: //quad shotgun
                holdingWeapon = true;
                quadshotgun.SetActive(true);
                rifle.SetActive(false);
                torch.SetActive(false);
                break;
            case 1: //rifle
                holdingWeapon = true;
                quadshotgun.SetActive(false);
                torch.SetActive(false);
                rifle.SetActive(true);
                break;
            case 2: //torch
                holdingWeapon = false;
                quadshotgun.SetActive(false);
                rifle.SetActive(false);
                torch.SetActive(true);
                break;
            default: //default; torch
                holdingWeapon = false;
                quadshotgun.SetActive(false);
                rifle.SetActive(false);
                torch.SetActive(true);
                break;
        }

        if (inputhandler.isAttacking() && holdingWeapon)
        {
            bool hasFired;
            switch (weaponIndex)
            {
                case 0: //quad shotgun
                    if (shellCount > 0)
                    {
                        hasFired = qsg.fireGun();
                        if (hasFired) { shellCount--; }
                    }
                    break;
                case 1: //rifle
                    if (bulletCount > 0)
                    {
                        hasFired = rfl.fireGun();
                        if (hasFired) { bulletCount--; }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public int getBullets()
    {
        return bulletCount;
    }

    public int getShells()
    {
        return shellCount;
    }

    public void giveShells(int sh)
    {
        shellCount += sh;
    }

    public void giveBullets(int bl)
    {
        bulletCount += bl;
    }
}
