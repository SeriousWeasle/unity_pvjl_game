using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float health = 10f;  //health of target
    public GameObject onDestroy;    //effect it spawns on death
    public Vector3 FX_offset;

    bool isDestroyed = false; //prevent destroying object several times on same frame

    public void damage(float dmg)   //function to receive damage
    {
        health -= dmg;  //remove damage from health
        if (health <= 0 && !isDestroyed)    //if health is 0 or lower
        {
            isDestroyed = true;
            if (onDestroy != null)  //does it have a destroy effect?
            {
                GameObject destroyFX = Instantiate(onDestroy); //yes, spawn destroy effect
                destroyFX.transform.position = gameObject.transform.position + FX_offset; //move destroy effect to position of destroyed object
                destroyFX.transform.rotation = gameObject.transform.rotation; //rotate destroy effect according to gameobject rotation
            }
            Destroy(gameObject);    //destroy the gameobject
        }
    }
}
