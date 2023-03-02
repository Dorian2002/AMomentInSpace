using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using BehaviorTree;

public class Alien_01BT : BehaviorTree.Tree
{
    public NavMeshAgent agent;
    public static float speed = 3f;
    public static float interactRange = 2f;
    public static float walkRadius = 30f;

    protected override Node SetUpTree()
    {
        agent.speed = speed;
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckRangeForEventSystem(transform),
                new Sabotaged(),
            }),
            new Sequence(new List<Node>
            {
                new CheckForEventSystem(transform),
                new GoToEventSystem(transform, agent),
            }),
            new TaskPatrol(transform, agent),
        });

        return root;
    }
}

