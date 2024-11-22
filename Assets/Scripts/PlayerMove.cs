using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float runSpeed = 7; 
    public float rotationSpeed = 250; 

    public Animator animator; 

    private float x, y; 

    public Rigidbody rb; 
    public float jumpHeight = 0.5f; 
    public Transform groundCheck; 
    public float groundDistance = 0.1f;
    [SerializeField] private float _radius = 2f; 
    public LayerMask groundMask; 

    bool isGrounded; 




    void Update()
    {
        x = Input.GetAxis("Horizontal"); 

        y = Input.GetAxis("Vertical"); 

        transform.Rotate(0, x * Time.deltaTime *rotationSpeed, 0); 

        transform.Translate(0, 0, y * Time.deltaTime * runSpeed); 

        animator.SetFloat("VelX", x); 
        animator.SetFloat("VelY", y); 

       
        isGrounded = Physics.CheckSphere(groundCheck.position, _radius, groundMask); 

        if(Input.GetKey("space") && isGrounded)
        {
            animator.Play("Jump"); 
            Invoke("Jump", 1f); 
        }
    

        
    }

    public void Jump()
        {
            
        }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, _radius);
    }


}

//rb.AddForce.(Vector3.up * jumpHeight, ForceMode.Impulse); (por si acaso)
