using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.5f; 
    private Vector2 moveInput;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = rb.position + new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.fixedDeltaTime;

        
        Vector3 smoothedPosition = Vector3.Lerp(rb.position, targetPosition, smoothTime);


        rb.MovePosition(smoothedPosition);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Batalla");
        }
    }
}
