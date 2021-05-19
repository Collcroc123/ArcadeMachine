using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject bullet;
    public GameObject missile;
    private Vector2 movement;
    private Vector3 bullPosC, bullPosL, bullPosR, currentBullPos;
    public int laserTimerMax = 10;
    public int missileTimerMax = 120;
    private int shotTimer = 0;
    private int missileTimer = 0;

    private void Start()
    {
        bullPosC = new Vector3(0, 0, 0.01f);
        bullPosL = new Vector3(-0.1f, 0, 0.01f);
        bullPosR = new Vector3(0.1f, 0, 0.01f);
    }

    private void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            currentBullPos = bullPosR;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            currentBullPos = bullPosL;
        }
        else
        {
            currentBullPos = bullPosC;
        }

        if (shotTimer >= laserTimerMax)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bullet, transform.position + currentBullPos, Quaternion.identity);
                shotTimer = 0;
            }
        }
        if (missileTimer >= missileTimerMax)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Instantiate(missile, transform.position + currentBullPos, Quaternion.identity);
                missileTimer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        shotTimer++;
        missileTimer++;
    }
}