using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;

    float speed = 10;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletspeed;

    bool OnGround = false;

    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value) //Vector 2
    {
        Vector2 input = value.Get<Vector2>();

        Debug.Log(input);

        rb.velocity = input.y * transform.forward + input.x * transform.right; 
        rb.velocity *= speed;
    }

    void OnFire() //will be called when fire action is triggered, when left click is pressed
    {
        Debug.Log("Firing");

        GameObject bulletInstance = Instantiate(bullet, transform.position + 0.5f * transform.forward, Quaternion.identity);
        Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(10f * transform.forward);
    }

    void OnJump(InputValue jump)
    {

        if(OnGround)
        {
            //jump here
            Debug.Log("Jumping");

            rb.velocity = transform.up * speed;

        }

        if(!OnGround) return;
        

    

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }

}

