using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
   
    private Animator animator;

    
    private float moveSpeed = 0f;

   
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        moveSpeed = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

        
        animator.SetFloat("speed", moveSpeed);  

        
        if (moveSpeed > 0.1f)
        {
            animator.SetBool("Running", true);  
        }
        else
        {
            animator.SetBool("Running", false);  
        }
    }
