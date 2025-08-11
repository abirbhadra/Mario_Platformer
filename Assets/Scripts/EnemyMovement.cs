using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
  
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform);
        if (collision.collider.CompareTag("Pipe"))
        {
            //Debug.Log("...........1");
            speed *= -1;
        }
    }
    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
    
}
