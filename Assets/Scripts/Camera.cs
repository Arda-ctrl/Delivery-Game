using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject thinkToFallow;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thinkToFallow.transform.position + new Vector3(0,0,-0.6f);
    }
}
