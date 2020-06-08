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
    public PlayerDead playerDead;
    public Animator animator;

    float timer = 0.0f;
    float timer2 = 0.0f;
    void Update()
    {
        if (timer > searchInterval)
        {
            agent.SetDestination(playerPos.position);
            timer = 0;
        }
        else
        {
            animator.SetBool("inSightOfPlayer", false);
        }
        timer += Time.deltaTime;

        if (Vector3.Distance(transform.position, playerPos.position) < huntDistance)
        {
            if(timer > 1f)
            {
                animator.SetBool("inSightOfPlayer", false);
                agent.SetDestination(playerPos.position);
                timer2 = 0;
            }
            else
            {
                timer2 += Time.deltaTime;
            }
        }

        //check if light is on
        if (flashLightObject.activeSelf)
        {
            if (Vector3.Distance(transform.position, flashLightObject.transform.position) < flashFreezeDistance)
            {
                animator.SetBool("isOn", true);
                print("Steve freeze");
                freezeAI.Freeze(animator);
            }
        }

        if (Vector3.Distance(transform.position, playerPos.position) < 1.0f)
        {
            animator.SetBool("Attack", true);
            playerDead.Kill();
        }
    }
}
