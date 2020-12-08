using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float health = 10f;

    public GameObject pickupFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth.health < 100)
            {
                playerHealth.Heal(health);
                if (pickupFX != null)
                {
                    GameObject fx = Instantiate(pickupFX);
                    fx.transform.position = gameObject.transform.position;
                }
                Destroy(gameObject);
            }
        }
    }
}
