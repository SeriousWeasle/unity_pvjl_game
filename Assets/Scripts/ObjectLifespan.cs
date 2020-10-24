using UnityEngine;

public class ObjectLifespan : MonoBehaviour
{
    public float lifespan = 10f;
    float lifetime = 0f;
    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}
