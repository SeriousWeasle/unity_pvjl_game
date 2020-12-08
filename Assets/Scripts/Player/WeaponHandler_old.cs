using UnityEngine;

public class WeaponHandler_old : MonoBehaviour
{
    public InputHandler inputhandler;
    public Transform pivot;
    public GameObject quadshotgun;
    public GameObject torch;
    public GameObject rifle;
    public Transform projectileSpawn;
    public GameObject projectile;
    public Transform head;
    public AudioSource weaponSound;

    public int bulletCount = 5;
    public Vector3 randomAngleLower = new Vector3(-10, -10, -10);
    public Vector3 randomAngleUpper = new Vector3(10, 10, 10);

    int weapcount = 2;
    public int weaponIndex = 0;

    bool weaponActive = true;

    public int ammoCount = 10;

    public int rifleAmmoCount = 5;

    public float firedelay = 0.5f;
    float firetimer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (inputhandler.scrollDirection() < 0)
        {   //decrement weaponIndex
            if (weaponIndex <= 0)
            {
                weaponIndex = weapcount;
            }
            else
            {
                weaponIndex -= 1;
            }

        }
        else if (inputhandler.scrollDirection() > 0)
        {   //increment weaponIndex
            if (weaponIndex >= weapcount)
            {
                weaponIndex = 0;
            }
            else
            {
                weaponIndex += 1;
            }
        }

        switch (weaponIndex)
        {
            case 0:
                weaponActive = false;
                quadshotgun.SetActive(false);
                rifle.SetActive(false);
                torch.SetActive(true);
                break;
            case 1:
                weaponActive = true;
                quadshotgun.SetActive(true);
                rifle.SetActive(false);
                torch.SetActive(false);
                break;
            case 2:
                weaponActive = true;
                quadshotgun.SetActive(false);
                torch.SetActive(false);
                rifle.SetActive(true);
                break;
            default:
                weaponActive = false;
                quadshotgun.SetActive(false);
                rifle.SetActive(false);
                torch.SetActive(true);
                break;
        }

        if (inputhandler.isAttacking() && weaponActive && firetimer <= 0 && ammoCount > 0)
        {   //check if firebutton is pressed and firing is possible
            for (int b = 0; b < bulletCount; b++)
            {   //fire set amount of bullets
                Vector3 randRot = new Vector3(Random.Range(randomAngleLower.x, randomAngleUpper.x), Random.Range(randomAngleLower.y, randomAngleUpper.y), Random.Range(randomAngleLower.z, randomAngleUpper.z)); //create random bullet spread
                GameObject bullet = Instantiate(projectile); //make bullet
                bullet.transform.position = projectileSpawn.position;   //set position correctly
                bullet.transform.rotation = head.rotation * Quaternion.Euler(randRot);  //rotate correctly
            }
            weaponSound.Play(); //play fire sound
            firetimer = firedelay; //set fire countdown
            ammoCount--; //write off 1 ammo
        }

        if (firetimer > 0)
        {   //remove time from fire timer if it is larger than 0
            firetimer -= Time.deltaTime;
        }
    }

    public int getAmmo()
    {
        return ammoCount;
    }

    public int getRifleAmmo()
    {
        return rifleAmmoCount;
    }

    public void giveAmmo(int ammo)
    {
        ammoCount += ammo;
    }
}
