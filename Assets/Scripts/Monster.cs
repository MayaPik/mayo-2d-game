using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public bool isFacingRight;
    public float jumpForce;
    public bool hitAWall;
    public float hightOfGhost;
    private float prevY;
    private float currentTime;

    private Rigidbody2D myBody;

    void Start() {
        prevY = transform.position.y;
        currentTime = Time.time;
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        hitAWall = false; // reset hitAWall to false every time FixedUpdate is called

        if (Time.time - currentTime >= 1f)
        {
            if (Mathf.Approximately(transform.position.y, prevY))
            {
                wallHit(true);
            }
            prevY = transform.position.y;
            currentTime = Time.time;
        }
        else {
            wallHit(false);
        }

        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        if ( myBody.bodyType == RigidbodyType2D.Kinematic) {
            myBody.position = new Vector2(myBody.position.x, hightOfGhost);
        } else {

        if (hitAWall) {
        myBody.position = new Vector2(myBody.position.x, myBody.position.y + 1f);
        myBody.position = new Vector2(myBody.position.x - 1f, myBody.position.y);
        }
        }
    }

    public void wallHit(bool hit) {
        hitAWall =  hit;
    }
}
