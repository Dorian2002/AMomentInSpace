using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class GoToEventSystem : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    public GoToEventSystem(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (target.position != _transform.position)
        {
            _agent.destination = target.position;
        }

        state = NodeState.RUNNING;
        return state;
    }
}

