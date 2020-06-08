using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreezeAI : MonoBehaviour
{
    public float freezeduration = 3f;
    public SteveAI steveAI;
    public NavMeshAgent agent;
    private float timer = 0;
    private bool isFrozen = false;
    private Animator animator;

    void Update()
    {
        if (isFrozen)
        {
            if (timer > freezeduration)
            {
                unFreeze();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
    }

    public void Freeze(Animator a)
    {
        animator = a;
        steveAI.enabled = false;
        agent.enabled = false;
        isFrozen = true;
    }

    private void unFreeze()
    {
        if(animator != null)
            animator.SetBool("isOn", false);
        agent.enabled = true;
        steveAI.enabled = true;
        isFrozen = false;
    }
}
