using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);//Inicialmente mirando hacia la derecha
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        //Variables movimiento jugador (dentro de unity)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);//Last moved x
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);//Last moved y
        }
        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);//Last moved x and y
        }
    }
    void Move()//Movimiento jugador 
    {
        rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}

