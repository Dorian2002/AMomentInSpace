using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class CheckForEventSystem : Node
{
    private static int _playerLayerMask = 1 << 7;
    private static int range = 10;
    private Transform _transform;

    public CheckForEventSystem(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, range, _playerLayerMask);

            if (colliders.Length > 0)
            {
                foreach (Collider col in colliders)
                {
                    if (!col.gameObject.GetComponent<InteractiveObject>().CanInteract)
                    {
                        parent.parent.SetData("target", colliders[0].transform);
                        state = NodeState.SUCCESS;
                        return state;
                    }
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}

