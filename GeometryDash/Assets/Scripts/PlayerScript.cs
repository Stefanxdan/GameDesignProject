using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded = false;
    public float jumpPower = 10.0f;
    public float playerSpeed = 5f;
    public float rotation_speed = 5f;

    public Sprite Image1 ;
    public Sprite Image2 ;

    public GameObject gameOverText;


    public string imageName = "player1";
    


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);

        rb = transform.GetComponent<Rigidbody2D>();
        string path = Application.dataPath + "/playerImageName.txt";
        if(!File.Exists(path))
        {
           // Debug.Log("Nu exista fisierul");
        }
        else
        {

           // Debug.Log("Continut fisier: " + File.ReadAllText(path));
            imageName = File.ReadAllText(path);
        }

        SetCharacter(imageName);
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * (Time.deltaTime * playerSpeed));
    }

    void FixedUpdate()
    {
        //if(rb.velocity.magnitude < 1 && rb.velocity.magnitude > 0)
        //   // Debug.Log(rb.velocity.magnitude );

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

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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

        if (other.collider.tag == "Finish")
            LoadSceneMainMenu();
            
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(3);
    }


    public void SetCharacter(string ImageName)
    {
        if (ImageName == "player1")
        {
           // Debug.Log("Set to " + Image1.name);
            GetComponent<SpriteRenderer>().sprite = Image1;
        }
        else
        {
           // Debug.Log("Set to " + Image1.name);
            GetComponent<SpriteRenderer>().sprite = Image2;
        }
    }

}
