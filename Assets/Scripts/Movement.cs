using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public Text scoreText;
    public float speed = 150f;
    public float moveSpeed = 500f;
    public float speedUpSpeed = 100f;

    void Start() {
        rb.AddForce(0, 0, speed * 0.05f, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("a")){rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);}
        else if (Input.GetKey("d")){rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);}
        else if (Input.GetKey("right")){rb.AddForce(moveSpeed * Time.deltaTime, 0, 0);}
        else if (Input.GetKey("left")){rb.AddForce(-moveSpeed * Time.deltaTime, 0, 0);}
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("dead")) {SceneManager.LoadScene( SceneManager.GetActiveScene().name );}
        else if (other.gameObject.CompareTag("speed")){rb.AddForce(0,0, speedUpSpeed * Time.deltaTime, ForceMode.Impulse);}
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("dead")) {SceneManager.LoadScene( SceneManager.GetActiveScene().name );}
    }

    void Update() {
        scoreText.text = (transform.position.z/25).ToString("0");
    }
}
