using UnityEngine;

public class QuadShotgun : MonoBehaviour
{
    public int bulletCount = 12;
    public Vector3 randomAngleLower = new Vector3(-10, -10, -10);
    public Vector3 randomAngleUpper = new Vector3(10, 10, 10);

    public AudioSource weaponSound;

    public GameObject projectile;
    public Transform projectileSpawn;
    public Transform head;

    public float firedelay = 0.75f;
    float firetimer = 0f;
    // Update is called once per frame
    void Update()
    {
        if (firetimer > 0)
        {
            firetimer -= Time.deltaTime;
        }
    }

    public bool fireGun()
    {
        if (firetimer <= 0)
        {
            for (int b = 0; b < bulletCount; b++)
            {   //fire set amount of bullets
                Vector3 randRot = new Vector3(Random.Range(randomAngleLower.x, randomAngleUpper.x), Random.Range(randomAngleLower.y, randomAngleUpper.y), Random.Range(randomAngleLower.z, randomAngleUpper.z)); //create random bullet spread
                GameObject bullet = Instantiate(projectile); //make bullet
                bullet.transform.position = projectileSpawn.position;   //set position correctly
                bullet.transform.rotation = head.rotation * Quaternion.Euler(randRot);  //rotate correctly
            }
            weaponSound.Play(); //play fire sound
            firetimer = firedelay;
            return true;
        }

        else
        {
            return false;
        }
    }    
}
