using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    private Animator anim;
    private Rigidbody rb;
    private Vector2 moveInput;
    private float turnSmoothVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (moveInput.magnitude >= 0.1f)
        {
            float horizontal = moveInput.x;
            float vertical = moveInput.y;
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                rb.MovePosition(rb.position + moveDir.normalized * speed * Time.fixedDeltaTime);

                
                anim.SetFloat("VelX", horizontal);
                anim.SetFloat("VelY", vertical);
            }
        }
        else
        {
            
            anim.SetFloat("VelX", 0);
            anim.SetFloat("VelY", 0);
        }
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

        }else if (other.CompareTag("Enemy 2"))
        {
            SceneManager.LoadScene("Batalla");
        }
        else if (other.CompareTag("Enemy 3"))
        {
            SceneManager.LoadScene("Batalla");
        }
        else if (other.CompareTag("Enemy 4"))
        {
            SceneManager.LoadScene("Batalla");
        }
    }
}