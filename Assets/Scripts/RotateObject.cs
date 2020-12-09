using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Transform toRotate;
    public Vector3 targetAngle = new Vector3(0, 0, 0);

    public void Rotate()
    {
        toRotate.transform.rotation = Quaternion.Euler(targetAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Rotate();
        }
    }
}
