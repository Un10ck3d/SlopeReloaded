using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    public Text speedUpText;
    public Text scoreTextObject;
    public float speed = 150f;
    public float controllSpeed = 500f;
    public float perSpeedUpMultiplier = 1f;
    public float startBoostMultiplier = 1;
    public float score = 0;
    public int highScore = 0;
    private float SpeedMultiplier = 1;
    private float direction = 0f;

    void Start() {
        // Start Boost
    }

    // Fixed Update for physics
    void FixedUpdate()
    {
        // Give player correct speed
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * SpeedMultiplier / 20);
        //rb.AddForce(0, 0, speed * Time.deltaTime * SpeedMultiplier);
        // Left and Right controlls
        rb.AddForce(controllSpeed * direction * Time.deltaTime, 0, 0);
    }

    // When collision or trigger it calls the SomeCollision() function
    private void OnCollisionEnter(Collision other) {
        SomeCollision(other.gameObject);}
    private void OnTriggerEnter(Collider other) {
        SomeCollision(other.gameObject);}

    // Logic for collision or trigger
    void SomeCollision(GameObject other) {
        speedUpText.enabled = false;
        cam.fieldOfView = 65;
        // Check for Death
        if(other.CompareTag("dead")) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
        // Check for speedup
        else if (other.CompareTag("speed")) { 
            SpeedMultiplier += 0.5f;
            speedUpText.enabled = true;
            increaseFOV();
        }

        else if (other.CompareTag("levelexit")) { 
            score += 0.5f;
        }
    }

    public void controllFunc(InputAction.CallbackContext value) {
        direction = value.ReadValue<float>();
    }

    void increaseFOV() {
        cam.fieldOfView += 2;
    }

    // Update function
    void Update() {
        // Update scoretext
        scoreTextObject.text = (score).ToString("0");
    }
}
