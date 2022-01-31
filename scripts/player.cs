using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private bool JumpKeyWasPressed;
    private float HorizontalInput;
    private Rigidbody rigidBodyComponent;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private int Score = 0;
    public float movespeed;



    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal")*5;
        


        
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyWasPressed = true;
        }
    }

    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(HorizontalInput, rigidBodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        
        
        
        
        
        if (JumpKeyWasPressed == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            JumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Score = Score + 1;  
        }


        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }

}
 