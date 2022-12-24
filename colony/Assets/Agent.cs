using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent;

    public string agentName;
	public int agentId;

	public float agentHealth;
    public float agentSpeed;

    public int agentStorageMax;

    public Transform agentTarget;

    public enum AgentType
    {
        Builder,
        Lumberjack,
        StoneMiner,
        MetalMiner,
        Hunter,
        Gatherer,
        Farmer,
        Warrior,
        Archer,
        Guard
    }

    public AgentType agentType;

    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
