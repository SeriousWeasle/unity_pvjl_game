using UnityEngine;

public class AmmoTest : MonoBehaviour
{
    public int ammoCount = 20; //amount of ammo given back

    public GameObject pickupFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            other.GetComponent<WeaponHandler>().giveShells(ammoCount);
            if (pickupFX != null) {
                GameObject fx = Instantiate(pickupFX);
                fx.transform.position = gameObject.transform.position;
            }
            Destroy(gameObject); //Delete self
        }
    }
}
