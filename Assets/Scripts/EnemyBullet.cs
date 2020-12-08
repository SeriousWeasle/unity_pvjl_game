using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float force = 1000f;
    public float particleOffset = 1f;
    public float damage = 5f;

    public Rigidbody rb;
    public GameObject effect;

    bool hasDamaged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && !hasDamaged)
        {
            other.GetComponent<PlayerHealth>().Damage(damage);
            hasDamaged = true;
        }

        if (effect != null)
        {
            GameObject hitFX = Instantiate(effect);
            Vector3 bulletRotation = gameObject.transform.eulerAngles;
            hitFX.transform.rotation = Quaternion.Euler(new Vector3(bulletRotation.x, bulletRotation.y + 180, bulletRotation.z));
            hitFX.transform.position = gameObject.transform.position += transform.forward * particleOffset * -1;
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * force * Time.deltaTime;
    }
}
