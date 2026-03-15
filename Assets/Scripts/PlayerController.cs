using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int lives=3;
    
    [SerializeField] private ParticleSystem collectParticleSystem;
    [SerializeField] private ParticleSystem dieParticleSystem;

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        speed = 10;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        
        if (count >= 22)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));

        }

    }

    void FixedUpdate()
    {
        countText.text = "Count: " +  count.ToString() + "/22\nLives: " + lives.ToString();
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            if(lives>=1){                
                // gameObject.transform.position = Vector3.zero;                               
            }else{
                Destroy(gameObject); 
                winTextObject.gameObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";                
            }
            dieParticleSystem.Play();

            
 
        }
        

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
           
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            collectParticleSystem.Play();
            
        }
        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            other.gameObject.SetActive(false);
            speed = speed + 2;

        }
        
        
    }
   
   
}
