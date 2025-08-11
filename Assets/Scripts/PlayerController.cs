using UnityEngine;
using TMPro;
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
    public Animator smallMario_animator;
    [SerializeField]
    public Animator biglMario_animator;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject smallMario;
    [SerializeField]
    private GameObject bigMario;

    private SpriteRenderer m_renderer;
    private CapsuleCollider2D m_collider;

    private void Start()
    {
        
        m_collider = gameObject.GetComponent<CapsuleCollider2D>();
       
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        smallMario_animator.SetFloat("Speed", Mathf.Abs(horizontal));
        //Debug.Log(horizontal);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            smallMario_animator.SetBool("IsJumping", true);
            jump = true;
            //Debug.Log("..........1");
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(speed * horizontal*Time.fixedDeltaTime, false, jump);
    }

    public void OnLand()
    {
        smallMario_animator.SetBool("IsJumping", false);
        //jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy_Head"))
        {
            collision.gameObject.SetActive(false);
        }
        if(collision.collider.CompareTag("Enemy_Body"))
        {
            gameObject.SetActive(false);
        }
        if(collision.collider.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            score++;
            scoreText.text ="Score : " + score.ToString();
        }
    }

    public void MushroomPowerup()
    {
        smallMario.SetActive(false);
        bigMario.SetActive(true);
        m_collider.offset = new Vector2(0, -0.08f);    
        m_collider.size = new Vector2(0.16f, 0.3f);
    }
    public void Shrink()
    {
        bigMario.SetActive(false);
        smallMario.SetActive(true);
        m_collider.size = new Vector2(0.16f, 0.16f);
        m_collider.offset = new Vector2(0, -0.01f);
    }
}
