using Unity.Mathematics;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public int enemyHealth = 1;
    public GameObject explosion;
    public IntData score;
    public int points = 100;

    void Update()
    {
        if (enemyHealth < 1)
        {
            Instantiate(explosion, transform.position, quaternion.identity);
            if (score.value < 9999999)
            {
                score.value += points;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullets"))
        {
            enemyHealth--;
        }
        else if (other.gameObject.CompareTag("Explosion"))
        {
            enemyHealth -= 2;
        }
    }
}