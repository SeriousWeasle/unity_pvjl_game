using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    public int ammoCount = 10;
    public GameObject pickupFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            other.GetComponent<WeaponHandler>().giveBullets(ammoCount);
            if (pickupFX != null)
            {
                GameObject fx = Instantiate(pickupFX);
                fx.transform.position = gameObject.transform.position;
            }
            Destroy(gameObject);
        }
    }
}
