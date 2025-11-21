using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed;

    void Start()
    {
        //transform.up = Vector2.up + Vector2.down;
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player" && collision.tag != "Bullet")
        Destroy(gameObject);
    }
}
