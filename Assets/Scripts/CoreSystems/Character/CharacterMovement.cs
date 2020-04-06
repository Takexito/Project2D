using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController2D charCont2d;
    private Transform playerTransform;
    public IsometricCharacterRenderer isoRenderer;

    [SerializeField]
    private float speed; // Скорость передвижения
    private Rigidbody2D rb2d; // Сам игровой объект
    private bool moveAtack = false;
    public bool isStop = true;
    public Vector2 lastDirectionVector2;



    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        charCont2d = gameObject.GetComponent<CharacterController2D>();
        playerTransform = gameObject.transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!isStop)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            MoveCharacter(h, v);
            if (moveAtack)
            {
                MoveCharacter(playerTransform.transform.right.x, 0f);
                moveAtack = false;
            }
        }

    }

    public void MoveCharacter(float dX, float dY)
    {
        Vector2 currentPos = rb2d.position;
        float horizontalInput = dX;
        float verticalInput = dY;
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * speed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

        if(movement.magnitude > .01f)
        {
            lastDirectionVector2 = movement.normalized;
        }
        
        isoRenderer.SetDirection(movement);
        rb2d.MovePosition(newPos);
    }

    public void Stop()
    {
        isoRenderer.SetDirection(Vector2.zero);
    }
    public Vector2 GetDirection()
    {
        return lastDirectionVector2;//Vector2.ClampMagnitude(lastDirectionVector2, 1f);
    }
    public void MoveToPoint(Vector2 point)
    {
        transform.position = point;
        Debug.Log("Move" + point);
    } 
    public void Move(Vector2 direction)
    {
        rb2d.MovePosition(direction);
        Debug.Log("Move" + direction);
    }
    public void MoveAfterHit()
    {
        //moveAtack = true;
        playerTransform.transform.Translate(GetDirection() * 0.2f);
        //Debug.Log(GetDirection());
    }

}
