using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float baseSpeed;
	public float gravity;
	public bool isGrounded;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;
	[SerializeField] private Vector3 direction;
    private float distToBottom;
    private float distToX;
    private float distToZ;
    private Rigidbody rg;
		
	// Use this for initialization
	void Start () {
		direction = new Vector3(0.0f,1.0f,0.0f);
		horizontalSpeed = 0.0f;
		isGrounded = false;

        rg = gameObject.GetComponent<Rigidbody>();

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
        else if (Physics.Raycast(transform.position + new Vector3(distToX-0.1f, 0.0f, distToZ-0.1f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(-distToX+0.1f, 0.0f, distToZ-0.1f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(distToX-0.1f, 0.0f, -distToZ+0.1f), Vector3.down, distToBottom + 0.1f))
        {
            verticalSpeed = 0.0f;
            return true;
        }
        else if (Physics.Raycast(transform.position + new Vector3(-distToX+0.1f, 0.0f, -distToZ+0.1f), Vector3.down, distToBottom + 0.1f))
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

        if (isGrounded && Input.GetButton("Jump"))
        {
            isGrounded = false;
            verticalSpeed = 5.0f;
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

	void Move ()
	{
		transform.position = transform.position + (direction.normalized * horizontalSpeed * Time.fixedDeltaTime);

		if(isGrounded == false)
		{
			verticalSpeed = verticalSpeed - gravity * Time.fixedDeltaTime;
			transform.position = transform.position + new Vector3(0.0f,verticalSpeed * Time.fixedDeltaTime,0.0f);
		}
        
		direction=new Vector3(0.0f,0.0f,0.0f);
	}

    void WorkaroundRigidBody()
    {
        rg.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

	void FixedUpdate()
	{
        isGrounded = updateGround();
		InputControl();
		Move ();
        WorkaroundRigidBody();
        if (this.transform.position.y < -4)
        {
            SceneManager.LoadScene("End");

        }
	}

	// Update is called once per frame
	void Update () {

	}
}
