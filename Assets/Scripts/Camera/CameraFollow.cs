using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothfactor;
    // Start is called before the first frame update
    private void FixedUpdate() {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothpos = Vector3.Lerp(transform.position, targetPos, smoothfactor* Time.deltaTime);
        transform.position=targetPos;
    }
}
