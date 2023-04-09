using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 6f;

    private float movementX;
    public GameObject restartButton;
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    public string WALK_ANIMATION = "walk";
    public string JUMP_ANIMATION = "jump";
    public string GROUND_TAG = "Ground";
    public string ENEMY_TAG = "Enemy";
    public string STAR_TAG = "Star";
    public string COIN_TAG = "Coin";


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

    void Start() {
    restartButton = GameObject.Find("restartButton");
    restartButton.SetActive(false);
    //transform.Translate(2,2,0);
}


    void Update() 
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();   

    if (transform.position.y < -10) {
        Destroy(gameObject);
        restartButton.SetActive(true);

    }
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
            restartButton.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision) {
     
        if(Collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        
            restartButton.SetActive(true);
        }
         if(Collision.gameObject.CompareTag(STAR_TAG)) {
            Destroy(Collision.gameObject);
            GameManager.instance.AddScore(2); 
        }
         if(Collision.gameObject.CompareTag(COIN_TAG)) {
            Destroy(Collision.gameObject);
            GameManager.instance.AddScore(1); 
        }
    }

}