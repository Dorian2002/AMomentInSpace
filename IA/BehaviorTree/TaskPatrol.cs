using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TaskPatrol : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    public TaskPatrol(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        if (_agent.destination == _transform.position)
        {
            Vector3 randomDirection = Random.insideUnitSphere * Alien_02BT.walkRadius;
            randomDirection += _transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, Alien_02BT.walkRadius, 1);
            _agent.destination = hit.position;
        }
        state = NodeState.RUNNING;
        return state;
    }
}
