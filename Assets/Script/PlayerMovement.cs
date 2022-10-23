using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float PlayerMoveForce = 20f;
    [SerializeField]
    private float PlayerJumpForce = 12f;

    private float MoveLnR;

    private SpriteRenderer sr;

    private Rigidbody2D Charbody;
    [SerializeField]
    private Animator Anim;

    private string WalkAnim = "Walk";
   

    private bool IsGrounded = true;
    private string GroundTag = "Ground";

    private void Awake()
    {
        Charbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerMoveKeyboard();
        Animateplayer();
        
        //character movement
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        MoveLnR = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(MoveLnR, 0f, 0f) * PlayerMoveForce * Time.deltaTime ;  

    }
    void Animateplayer()
    {
        //moving right
        if(MoveLnR > 0)
        {
            Anim.SetBool(WalkAnim, true);
            sr.flipX = false;
        }
        //going left
        else if(MoveLnR < 0)
        {
            Anim.SetBool(WalkAnim, true);
            sr.flipX = true;
        }
        else
        {
            Anim.SetBool(WalkAnim, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButton("Jump")&& IsGrounded)
        {
            IsGrounded = false;
            Charbody.AddForce(new Vector2(0f, PlayerJumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            IsGrounded = true;
        }
    }
}   //class
