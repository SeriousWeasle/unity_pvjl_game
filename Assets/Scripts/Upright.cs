using UnityEngine;

public class Upright : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
