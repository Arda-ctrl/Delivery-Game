using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    public float moveSpeed = 100;
    [SerializeField] float streetSpeed =10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Horizontal")*moveSpeed * Time.deltaTime;
        float streetAmount = Input.GetAxis("Vertical")*streetSpeed * Time.deltaTime;
        transform.Rotate(0,0,-moveAmount);
        transform.Translate(0,streetAmount,0);
       
        
        
    }
}
