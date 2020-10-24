using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public float force = 10f;
    public Rigidbody rb;
    public GameObject effect;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitfx = Instantiate(effect);
        hitfx.transform.position = gameObject.transform.position;
        Vector3 bulletRotation = gameObject.transform.eulerAngles;
        hitfx.transform.rotation = Quaternion.Euler(new Vector3(bulletRotation.x, bulletRotation.y + 180, bulletRotation.z));
        Destroy(gameObject);
    }

    // FixedUpdate because rigidbody physics
    void FixedUpdate()
    {
        rb.velocity = transform.forward * force * Time.deltaTime;
    }
}
