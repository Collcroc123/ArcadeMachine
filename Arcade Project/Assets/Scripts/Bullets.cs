using Unity.Mathematics;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public bool isExplosive = false;
    public GameObject explosion;

    private void Start()
    {
        movement.x = 0;
        movement.y = 1;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (bulletSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isExplosive)
            {
                Instantiate(explosion, transform.position + new Vector3(0, 0.075f, -0.1f), quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}