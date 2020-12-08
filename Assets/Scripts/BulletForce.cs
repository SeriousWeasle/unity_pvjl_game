using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public float force = 10f;           //force for adding speed to projectile
    public float particleOffset = 1f;   //offset from hit towards player to prevent particle clipping
    public float damage = 1f;           //damage for damaging hitables
    public Rigidbody rb;                //rigidbody projectile
    public GameObject effect;           //on hit effect

    private void OnTriggerEnter(Collider other) //check for intersect with objects
    {
        if (other.tag != "bullet" && other.tag != "bulletignore")
        {
            GameObject hitfx = Instantiate(effect); //it hit, so instantiate hit effect
            hitfx.transform.position = gameObject.transform.position;   //set hit effect to position of hit
            Vector3 bulletRotation = gameObject.transform.eulerAngles;  //store bullet's global rotation in a 3 component vector
            hitfx.transform.rotation = Quaternion.Euler(new Vector3(bulletRotation.x, bulletRotation.y + 180, bulletRotation.z));   //flip hit effect 180°
            hitfx.transform.position += transform.forward * particleOffset * -1;    //offset particles towards camera the specified amount
            if (other.tag == "hitable")
            {   //if other object can be hit
                other.GetComponent<Hitable>().damage(damage);   //apply damage
            }
            Destroy(gameObject);    //delete bullet
        }
    }

    // FixedUpdate because rigidbody physics
    void FixedUpdate()
    {
        rb.velocity = transform.forward * force * Time.deltaTime;   //push bullet forward each physics timestep
    }
}
