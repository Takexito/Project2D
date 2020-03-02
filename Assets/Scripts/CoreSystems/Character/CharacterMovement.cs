using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController2D charCont2d;
    private Transform playerTransform;

    [SerializeField]
    private float speed; // Скорость передвижения
    [Range(0, .3f)] [SerializeField] private float smoothing = .05f;
    private Rigidbody2D rb2d; // Сам игровой объект
    private Animator animator;
    private bool isRotate = false;
    private bool moveAtack = false;
    private Vector2 velocity = Vector2.zero;

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        charCont2d = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        playerTransform = GameObject.FindGameObjectWithTag(charCont2d.playableCharacterTagName).transform;
        rb2d = GameObject.FindGameObjectWithTag(charCont2d.playableCharacterTagName).GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d = GameObject.FindGameObjectWithTag(charCont2d.playableCharacterTagName).GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag(charCont2d.playableCharacterTagName).transform;
        
    }

    void FixedUpdate()
    {
        if (gameObject.CompareTag(charCont2d.playableCharacterTagName))
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Movement(h, v);
            if (rb2d.velocity.x == 0 && rb2d.velocity.y == 0) Stop();
            if (moveAtack)
            {
                MoveCharacter(playerTransform.transform.right.x, 0f);
                moveAtack = false;
            }
        }

    }

    private void Movement(float deltaX, float deltaY)
    {
        animator.SetFloat("Speed", Mathf.Abs(deltaX));

        if (deltaX < 0 && !isRotate)
            Flip();
        if (deltaX > 0 && isRotate)
            Flip();

        MoveCharacter(deltaX, deltaY);
    }


    public void Stop()
    {
        rb2d.velocity = Vector2.zero;
        animator.SetFloat("Speed", Mathf.Abs(0));
    }

    public void Flip()
    {
        
        isRotate = !isRotate;
        Vector3 scale = playerTransform.transform.localScale;
        scale.x *= -1;
        playerTransform.transform.localScale = scale;
        
    }

    public void MoveCharacter(float dX, float dY)
    {
        Vector2 input = new Vector2(dX, dY); // Создаем переменную в которой будем хранить окончательное направление
        input = Vector2.ClampMagnitude(input, 1);
        Vector2 movement = input * speed * speed * Time.fixedDeltaTime;
        //Vector2 newPos = rb2d.position + movement;
        //rb2d.MovePosition(newPos);
         rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, movement, ref velocity, smoothing);
         //Debug.Log(rb2d.velocity);

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
        playerTransform.transform.Translate(playerTransform.transform.right * 20f);
    }

}
