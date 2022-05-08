using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Rigidbody _rigidbody;
    public bool IsGrounded;
    public int BoostInpulse = 5000;
    private float _dirX;


    
    // Start is called before the first frame update
    public void Start(){
      _rigidbody = GetComponent<Rigidbody>();
    }

   public void Update () {
        Jump();
        Boost();
    }

    // Update is called once per frame
    public void FixedUpdate() { 
       Move();
     }

     public void Move()  {
         _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y, Input.GetAxis("Vertical") * _speed);//move

        
        if (_rigidbody.velocity.x < -.01)// flip
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if (_rigidbody.velocity.x > .01)
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }

     public void Jump(){
        if (Input.GetButtonDown("Jump") && IsGrounded)//jump
            {
               IsGrounded = false;
                _rigidbody.AddForce(new Vector3(0 , 300 , 0));
           }
    }

     public void OnCollisionEnter() { //ground

         IsGrounded = true;
        }

     public void Boost () {
         if(Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 15f;
        }
         else 
        {
            _speed = 10f;
        }

        _dirX = Input.GetAxis("Horizontal") * _speed;
       }

    

   
}
