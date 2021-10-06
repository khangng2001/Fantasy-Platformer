using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsRollin : MonoBehaviour
{
    public static bool isrolling;
    public void Roll()
    {
        isrolling= true;
    }

    public void Rolled()
    {
        isrolling=false;
    }
}
