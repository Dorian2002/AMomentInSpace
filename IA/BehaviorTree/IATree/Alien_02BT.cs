using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using BehaviorTree;

public class Alien_02BT : BehaviorTree.Tree
{
    public NavMeshAgent agent;
    public static float speed = 1f;
    public static float walkRadius = 10f;

    protected override Node SetUpTree()
    {
        agent.speed = speed;
        Node root = new TaskPatrol(transform, agent);
        return root;
    }
}

