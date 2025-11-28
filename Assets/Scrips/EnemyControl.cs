using System.Runtime.InteropServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject Target;

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] public int life = 3;
    

    private bool isFacingRight = true;

   

    void Start()
    {
       
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
       
            Vector3 dir = Target.transform.position - transform.position;
            Vector3 normalizedDir = dir.normalized;

            transform.position += normalizedDir * speed * Time.deltaTime;

    }
}
