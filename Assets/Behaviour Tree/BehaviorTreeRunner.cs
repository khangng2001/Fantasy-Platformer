using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeRunner : MonoBehaviour
{
    BehaviorTree tree;
    void Start()
    {
        tree = ScriptableObject.CreateInstance<BehaviorTree>();
        var log1 = ScriptableObject.CreateInstance<DebugLogNode>();
        log1.message = "Hello World!!! 111";
        var time1 = ScriptableObject.CreateInstance<WaitNode>();
        var log2 = ScriptableObject.CreateInstance<DebugLogNode>();
        log2.message = "Hello World!!! 222";
        var time2 = ScriptableObject.CreateInstance<WaitNode>();
        var log3 = ScriptableObject.CreateInstance<DebugLogNode>();
        log3.message = "Hello World!!! 333";
        var time3 = ScriptableObject.CreateInstance<WaitNode>();

        var sequence = ScriptableObject.CreateInstance<SequencerNode>();
        sequence.children.Add(log1);
        sequence.children.Add(time1);
        sequence.children.Add(log2);
        sequence.children.Add(time2);
        sequence.children.Add(log3);
        sequence.children.Add(time3);

        var Loop = ScriptableObject.CreateInstance<RepeatNode>();

        Loop.Child = sequence;
        tree.rootNode = Loop;
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
