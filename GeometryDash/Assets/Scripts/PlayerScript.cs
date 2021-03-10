using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded = false;
    public float jumpPower = 10.0f;
    public float playerSpeed = 5f;
    public float rotation_speed = 5f;
    public GameObject gameOverText;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        rb = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * (Time.deltaTime * playerSpeed));
    }

    void FixedUpdate()
    {
        //if(rb.velocity.magnitude < 1 && rb.velocity.magnitude > 0)
        //    Debug.Log(rb.velocity.magnitude );

        //if (Input.GetKey(KeyCode.Space) && isGrounded && rb.velocity.magnitude == 0)
        //{
        //    rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));
        //}
        Vector3 vel = rb.velocity;
        vel.x = playerSpeed;
        rb.velocity = vel;

        if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * jumpPower * rb.mass * rb.gravityScale * 20.0f);
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.Rotate(Vector3.back * rotation_speed);
        }

        //if (rb.velocity.x != 7 && rb.velocity.x != 0)
        //    GameOver();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag.Equals("Enemy"))
        {
            GameOver();
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }

    }

    void GameOver()
    {
        gameOverText.SetActive(true);
        gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
