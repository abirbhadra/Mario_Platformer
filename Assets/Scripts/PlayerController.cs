using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    public bool jump = false;
    [SerializeField]
    CharacterController2D characterController;
    public float horizontal;
    [SerializeField]
    public Animator animator;
    
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        //Debug.Log(horizontal);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
            jump = true;
            Debug.Log("..........1");
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(speed * horizontal*Time.fixedDeltaTime, false, jump);
    }

    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
        //jump = false;
    }
}
