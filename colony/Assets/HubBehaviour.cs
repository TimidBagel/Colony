using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubBehaviour : MonoBehaviour
{
    public Transform agentParent;

    public string hubName;
    public int hubId;

    public float hubHealth;

    public int hubStorageMax;

    public int agentCount = 10;
    public List<Agent> agents = new List<Agent>();
    public GameObject agentPrefab;

    private void Start()
    {
		SpawnAgents();
    }

    private void SpawnAgents()
    {
		for (int i = 0; i < agentCount; i++)
		{
			Agent newAgent = Instantiate(agentPrefab, transform.position,
				Quaternion.identity, agentParent).GetComponent<Agent>();

			bool cont = true;
			while (cont)
			{
				int newId = Random.Range(100, 999);
				foreach (Agent agent in agents)
				{
					if (newId == agent.agentId)
						continue;
					else
					{
						cont = false;
						newAgent.agentId = newId;
						break;
					}
				}
				break;
			}

			newAgent.agentName = hubName + " agent";
			newAgent.name = "agent clone";
			agents.Add(newAgent);
		}
	}

	static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T value = (T)A.GetValue(Random.Range(0, A.Length));
		return value;
	}
}
