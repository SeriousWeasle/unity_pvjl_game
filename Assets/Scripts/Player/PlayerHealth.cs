using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void Damage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > 100)
        {
            health = 100;
        }
    }

    public float getHealth()
    {
        return health;
    }
}
