//Name: Apolinar Camacho

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float raycastDistance;
    private Rigidbody rb;
    public AudioSource coinSound;
    public Text WinMessage;
    public Text countText;
    private int count;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coinSound = GetComponent<AudioSource>();
        WinMessage.text = "";
        count = 0;
        setCount();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if( Input.GetKeyDown(KeyCode.Space) )
        {
            if (isGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPosition);
        
    }

    private bool isGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, raycastDistance); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CoinObj"))
        {
            other.gameObject.SetActive(false);
            coinSound.Play();
            count++;
            setCount();
        }

        if (other.gameObject.CompareTag("GroundHit"))
        {
            Debug.Log("Ground Hit!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }

        if(other.gameObject.CompareTag("EndBase"))
        {
            WinMessage.text = "You Win!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void setCount()
    {
        countText.text = "Count: " + count.ToString();
    }
}
