using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour {
    public float minWaitTime = .5f;
    public float maxWaitTime = 10f;

    private float waitCooldown = 1f;
    private NavMeshAgent agent;
    private Vector3 startPos;
    private float waitTimer = 0f;
    private GuardStats gs;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
        gs = GetComponent<GuardStats>();
    }

	void Update () {
        PlayerPrefs.SetInt("wonAlltogether", gs.health <= 0f ? 1 : 0);
        if(Vector3.Magnitude(agent.velocity) <= 0.1f) {
            if(waitTimer >= waitCooldown) {
                agent.SetDestination(randomPointWithinSqRadius(10f));
                waitTimer = 0f;
                waitCooldown = Random.Range(minWaitTime, maxWaitTime);
            } else {
                waitTimer += Time.deltaTime;
            }
            
        }
    }

    Vector3 randomPointWithinSqRadius(float sqRadius) {
        float x = startPos.x + Random.Range(-sqRadius, sqRadius);
        float z = startPos.z + Random.Range(-sqRadius, sqRadius);
        return new Vector3(x, startPos.y, z);
    }
}
