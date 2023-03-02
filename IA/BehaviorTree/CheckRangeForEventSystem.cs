using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class CheckRangeForEventSystem : Node
{
    private static int _playerLayerMask = 1 << 7;
    private static int range = 10;
    private Transform _transform;

    public CheckRangeForEventSystem(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform targetTransform = (Transform)target;
        if (Vector3.Distance(_transform.position, targetTransform.position) <= Alien_01BT.interactRange)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}

