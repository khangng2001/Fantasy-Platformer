using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    private float Length, Startpos;
    [SerializeField]
    private GameObject Cam;
    [SerializeField]
    private float ParallaxEffect;
    void Start()
    {
        Startpos= transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate() {
        float temp = (Cam.transform.position.x * (1-ParallaxEffect));
        float dist = (Cam.transform.position.x * ParallaxEffect);
        transform.position = new Vector3( Startpos+dist-4, transform.position.y, transform.position.z);
        if ( temp > Startpos+ Length) Startpos += Length; 
        else if(temp < Startpos - Length) Startpos -= Length;
    }
}
