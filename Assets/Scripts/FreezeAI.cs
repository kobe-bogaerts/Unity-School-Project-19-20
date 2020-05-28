using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreezeAI : MonoBehaviour
{
    public float freezeduration = 5f;
    public SteveAI steveAI;
    public NavMeshAgent agent;
    private float timer = 0;
    private bool isFrozen = false;

    // Update is called once per frame
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

    public void Freeze()
    {
        steveAI.enabled = false;
        agent.enabled = false;
        isFrozen = true;
    }

    private void unFreeze()
    {
        agent.enabled = true;
        steveAI.enabled = true;
        isFrozen = false;
    }
}
