using UnityEngine;
using UnityEngine.AI;

public class SteveAI : MonoBehaviour
{
    public Transform playerPos;
    public NavMeshAgent agent;
    public float searchInterval = 5f;
    public float flashFreezeDistance = 4.5f;
    public float huntDistance = 5f;
    public GameObject flashLightObject;
    public FreezeAI freezeAI;

    float timer = 0.0f;
    void Update()
    {
        if (timer > searchInterval)
        {
            agent.SetDestination(playerPos.position);
            timer = 0;
        }
        timer += Time.deltaTime;

        if(Vector3.Distance(transform.position, playerPos.position) < huntDistance)
        {
            agent.SetDestination(playerPos.position);
        }

        //check if light is on
        if (flashLightObject.activeSelf)
        {
            if (Vector3.Distance(transform.position, flashLightObject.transform.position) < flashFreezeDistance)
            {
                print("Steve freeze");
                freezeAI.Freeze();
            }
        }
    }
}
