using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //MOVEMENT//
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    //Fix jump code for next week production//
    //JUMPING//
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    //Find code for bullet at every frame?//
    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;

    //UPDATED JUMP AND SHOOT CODE//
    private bool doJump = false;
    private bool doShoot = false;

    private GameManager _gameManager;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Removed start function
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        //JUMP UPDATED CODE//
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            doShoot = true;
        }

        /*This comments these functions so we won't be running two different controls
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
    }

    private void FixedUpdate()
    {
        //JUMP UPDATE//
        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            doJump = false;
        }
       
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position +
            this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        //SHOOT UPDATE
        //Instead of checking Input.GetMouseButtonDown(0) we check doShoot

        if(doShoot)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.right, this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            doShoot = false;
        }
       
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
           _col.bounds.min.y, _col.bounds.center.z);
        bool grounded =Physics.CheckCapsule(_col.bounds.center,
             capsuleBottom, distanceToGround, groundLayer,
             QueryTriggerInteraction.Ignore);
        return grounded;
    }

    //SPEED BOOST//
    private float speedMultiplier;

    public void BoostSpeed(float multiplier, float seconds)
    {
        speedMultiplier = multiplier;
        moveSpeed *= multiplier;
        Invoke("EndSpeedBoost", seconds);
    }

    private void EndSpeedBoost()
    {
        Debug.Log("speed boost ended");
        moveSpeed /= speedMultiplier;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }
}
