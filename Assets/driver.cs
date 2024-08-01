using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    [SerializeField] float streetSpeed =0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,moveSpeed);
        transform.Translate(0,streetSpeed,0);
       
        
        
    }
}
