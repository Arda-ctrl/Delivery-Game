using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class driver : MonoBehaviour
{
    public float moveSpeed = 250f;
    [SerializeField] float streetSpeed = 0.3f;
    [SerializeField] float fastSpeed = 0.5f;
    [SerializeField] float slowSpeed = 0.1f;
    public float collisionDuration = 1f;
    private float currentSpeed;
    

    void Start()
    {
        currentSpeed = streetSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(HandleCollision());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fast")
        {
            currentSpeed = fastSpeed;
        }
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float streetAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -moveAmount);
        transform.Translate(0, streetAmount, 0);
    }

    private IEnumerator HandleCollision()
    {
        currentSpeed = slowSpeed;
        yield return new WaitForSeconds(collisionDuration);
        currentSpeed = streetSpeed;
    }
}
