using UnityEngine;

public class DamageField : MonoBehaviour
{
    public float damageDelay = 0.05f;
    public float damage = 5f;

    PlayerHealth player;
    float damageTimer = 0f;

    bool containsPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            containsPlayer = true;
            player = other.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            containsPlayer = false;
        }
    }

    private void Update()
    {
        if (containsPlayer && damageTimer <= 0)
        {
            player.Damage(damage);
            damageTimer = damageDelay;
        }

        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }
}
