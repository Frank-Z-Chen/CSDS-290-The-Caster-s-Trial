using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilToadBehavior: MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public LayerMask isGround, isPlayer;

    public Vector3 walkingPoint;
    public bool ispointSet;
    public float walkingpointRange;

    public float attacktimeRange;
    bool hasAttacked;

    public float visionRange, attackRange;
    public bool invisionRange, inattackRange;

    public GameObject shootableTongue;

    public float enemyHealth;

    void Awake() {
        player = GameObject.Find("Ellen").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        invisionRange = Physics.CheckSphere(transform.position, visionRange, isPlayer);
        inattackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if(!invisionRange && !inattackRange) Disengaged();
        if(invisionRange && !inattackRange) SpotPlayer();
        if(invisionRange && inattackRange) AttackPlayer();
    }

    void Disengaged() {

        if(!ispointSet) {
            SearchWalkingPoint();
        } 

        if(ispointSet) {
            
            agent.SetDestination(walkingPoint);
        }

        Vector3 distancetoPoint = transform.position - walkingPoint;

        if(distancetoPoint.magnitude < 1f) {

            ispointSet = false;
        }
    }

    void SearchWalkingPoint() {

        float randomPointZ = Random.Range(-walkingpointRange, walkingpointRange);
        float randomPointX = Random.Range(-walkingpointRange, walkingpointRange);

        walkingPoint = new Vector3(transform.position.x + randomPointX, transform.position.y, transform.position.z + randomPointZ);

        if(Physics.Raycast(walkingPoint, -transform.up, 2f, isGround)) {

            ispointSet = true;
        }
    }

    void SpotPlayer() {
        agent.SetDestination(player.position);
    }

    void AttackPlayer() {

        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!hasAttacked) {

            //Evil toad attack code here
            Rigidbody rigidBody = Instantiate(shootableTongue, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rigidBody.AddForce(transform.up * 8f, ForceMode.Impulse);

            hasAttacked = true;
            Invoke(nameof(ResetAttack), attacktimeRange);
        }
    }

    void ResetAttack() {

        hasAttacked = false;
    }

   void TakeDamage(int damage) {

       enemyHealth -= damage;

       if(enemyHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    void DestroyEnemy() {
        
        Destroy(gameObject);
    }

    void OnDrawSpheres() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
