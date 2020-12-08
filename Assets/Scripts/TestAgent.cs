using UnityEngine;
using UnityEngine.AI;

public class TestAgent : MonoBehaviour
{
    //target
    public Transform goal;
    public Transform weapon;
    public float sightRadius = 20f;
    public float fireRadius = 10f;

    public GameObject projectile;
    public Transform projectilespawn;

    public AudioSource fireSFX;

    public float EnemyFireDelay = 1f;
    float EnemyFireTimer = 0f;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        if ((gameObject.transform.position - goal.transform.position).magnitude < sightRadius) //If player is in sight
        {
            agent.destination = goal.position; //Try to move to player
            gameObject.transform.LookAt(new Vector3(goal.position.x, gameObject.transform.position.y, goal.position.z)); //Face player
            weapon.transform.LookAt(goal.position); //rotate weapon towards center mass of player
            if (EnemyFireTimer <= 0 && (gameObject.transform.position - goal.transform.position).magnitude < fireRadius) //can fire?
            {
                GameObject proj = Instantiate(projectile);
                fireSFX.Play();
                proj.transform.position = projectilespawn.transform.position;
                proj.transform.rotation = projectilespawn.transform.rotation;
                EnemyFireTimer = EnemyFireDelay;
            }
        }

        if (EnemyFireTimer > 0)
        {
            EnemyFireTimer -= Time.deltaTime;
        }
    }
}
