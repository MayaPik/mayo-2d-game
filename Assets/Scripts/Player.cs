using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    public string WALK_ANIMATION = "walk";
    public string JUMP_ANIMATION = "jump";
    public string GROUND_TAG = "Ground";
    public string ENEMY_TAG = "Enemy";
    public bool canMove = true; 
    
    public void SetCanMove(bool canMove) {
    this.canMove = canMove;
}
   
    private bool isGrounded;

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    void Update() 
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        
    }


    void PlayerMoveKeyboard(){
         if (canMove) {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
            } 
            else {
        transform.position += new Vector3(-2f*movementX,0,0) * moveForce * Time.deltaTime;
 
            }
    }

    void AnimatePlayer() {

        if (movementX > 0) {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
        } 
        else if (movementX < 0)
         {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true;
        }
        else 
        {
            anim.SetBool(WALK_ANIMATION,false);
        }
    }

    void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION,true);
        }
    }

    private void OnCollisionEnter2D(Collision2D Collision) {
        if(Collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
                        anim.SetBool(JUMP_ANIMATION,false);

        }

        if(Collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision) {
     
        if(Collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }

}