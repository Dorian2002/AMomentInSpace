using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class Sabotaged : Node
{

    public Sabotaged()
    {
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        target.GetComponent<InteractiveObject>().Sabotage();

        if (target.GetComponent<InteractiveObject>().CanInteract)
        {
            ClearData("target");
        }
        state = NodeState.RUNNING;
        return state;
    }
}

