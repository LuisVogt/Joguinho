using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float baseSpeed;
    public float jumpSpeed = 5f;
	public float gravity;
	public bool isGrounded;
    public bool lockMovement;
    private float verticalSpeed;
    private float horizontalSpeed;
	private Vector3 direction;
    private float distToBottom;
    private float distToX;
    private float distToZ;
    public Rigidbody rg;
		
	// Use this for initialization
	void Start () {
        GetComponent<StageChecker>().RefreshCurrentLevel();
		direction = new Vector3(0.0f,1.0f,0.0f);
		horizontalSpeed = 0.0f;
		isGrounded = false;

        rg = GetComponent<Rigidbody>();

        distToBottom = gameObject.GetComponent<BoxCollider>().bounds.extents.y;
        distToX = gameObject.GetComponent<BoxCollider>().bounds.extents.x;
        distToZ = gameObject.GetComponent<BoxCollider>().bounds.extents.z;
	}

    public bool updateGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(distToX-0.2f, 0.0f, distToZ-0.2f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(-distToX+0.2f, 0.0f, distToZ-0.2f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(distToX-0.2f, 0.0f, -distToZ+0.2f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(-distToX+0.2f, 0.0f, -distToZ+0.2f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else
            return false;
    }

	void InputControl()
	{
		Vector2 tempAxys = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")*1.75f);

        //criar um vector3 pra forward e right e trocar os valores só quando apertar os botões para otimizar

		direction = direction + transform.forward  * tempAxys.y;
		direction = direction + transform.right * tempAxys.x;
		horizontalSpeed = tempAxys.magnitude * baseSpeed;

        if (Input.GetButton("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Rotate(Vector3.up, 90);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            transform.Rotate(Vector3.up, -90);
        }
    }

    public void Jump()
    {
        if (!isGrounded)
            return;
        if (!lockMovement || rg.velocity.magnitude <0.5f)
        {
            isGrounded = false;
            verticalSpeed = jumpSpeed;
        }
    }

    void Gravity()
    {
        //rg.velocity = Vector3.zero;
        if (isGrounded == false)
        {
            verticalSpeed = verticalSpeed - gravity * Time.fixedDeltaTime;
        }
        rg.velocity = new Vector3(rg.velocity.x, verticalSpeed, rg.velocity.z);
    }

	void Move()
	{
        rg.velocity = new Vector3(0f, rg.velocity.y, 0f);
        rg.velocity += new Vector3(direction.normalized.x * horizontalSpeed, 0 , direction.normalized.z * horizontalSpeed);
        direction = new Vector3(0.0f,0.0f,0.0f);
	}

    public Vector3 getVelocity()
    {
        return rg.velocity;
    }

    public void setVelocity(Vector3 vel)
    {
        rg.velocity = vel;
    }

    public void setVerticalSpeed(float v)
    {
        verticalSpeed = v;
    }

    public void LockMovement(bool b)
    {
        lockMovement = b;
        SlidingOnIce.velocity = getVelocity();
    }

    void FixedUpdate()
    {
        isGrounded = updateGround();
        InputControl();
        Gravity();
        if(rg.velocity.magnitude < 0.5f || !lockMovement)
            Move();
        LockMovement(false);
    }

}
