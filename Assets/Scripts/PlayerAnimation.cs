using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private static string RUN_ANIMATION_TAG = "Run";
    private static string JUMP_ANIMATION_TAG = "Jump";
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void RunningAnimation(bool run){
        anim.SetBool(RUN_ANIMATION_TAG,run);
    }
    public void JumpingAnimation(bool jump){
        anim.SetBool(JUMP_ANIMATION_TAG, jump);
    }
}
