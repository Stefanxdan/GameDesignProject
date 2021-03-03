using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpPower = 10.0f;
    public bool isGrounded = false;
    public float playerSpeed = 5f;
    public GameObject gameOverText;
    
    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        myRigidbody = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * playerSpeed));
    } 

    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
            isGrounded = true;

        if(other.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            gameObject.SetActive(false);
            SceneManager.LoadScene("SampleScene");
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
            isGrounded = false;
    }
}
