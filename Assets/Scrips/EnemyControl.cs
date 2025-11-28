
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] public int life = 3;
    

    private bool isFacingRight = true;

   

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    

     void Update()
     {

        bool isPlayerRight = transform.position.x < player.transform.position.x;
         Flip(isPlayerRight);

        MoveToTarget();
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigeer entro: " + collision.tag);
        if (collision.tag == "Bullet")
        {
            life--;
            if (life <= 0)
                Destroy(gameObject);
        }
    }


    private void Flip(bool isPlayerRight)
     {
         if((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
         {
             isFacingRight = !isFacingRight;
             Vector3 scale = transform.localScale;
             scale.x *= -1;
             transform.localScale = scale;
         }
     }

    public Transform GetTransform()
    {
        return transform;
    }

    public void MoveToTarget()
    {
       
            Vector3 dir = player.position - transform.position;
            Vector3 normalizedDir = dir.normalized;

            transform.position += normalizedDir * speed * Time.deltaTime;

    }
}
