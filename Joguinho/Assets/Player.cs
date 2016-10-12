using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float baseSpeed;
	public float gravity;
	public bool isGrounded;
	private float verticalSpeed;
	private float horizontalSpeed;
	private Vector3 direction;

	void OnTriggerEnter(Collider other)
	{
		isGrounded = true;
		verticalSpeed = 0.0f;
		Ray myRay = other.transform.position - transform.position;
		RaycastHit hit;
		Physics.Raycast(myRay,out hit);
		//transform.position = transform.position + hit.normal * other.contactOffset;
		//Ray myRay = other.transform.position - transform.position;
		//RaycastHit myRayHit;
//		Physics.Raycast (myRay,out myRayHit);

//		transform.position = transform.position * other.contactOffset;
	}
		
	// Use this for initialization
	void Start () {
		direction = new Vector3(0.0f,1.0f,0.0f);
		horizontalSpeed = 0.0f;
		isGrounded = false;
	}

	void InputControl()
	{
		Vector2 tempAxys = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")*1.75f);
		direction = direction + new Vector3(1.0f,0.0f,1.0f)  * tempAxys.y;
		direction = direction + new Vector3(1.0f,0.0f,-1.0f) * tempAxys.x;
		horizontalSpeed = tempAxys.magnitude * baseSpeed;
	}

	void Move ()
	{
//		transform.position = transform.position + (direction.normalized * horizontalSpeed * Time.deltaTime);
		transform.position = transform.position + (direction.normalized * horizontalSpeed * Time.fixedDeltaTime);

		if (isGrounded && Input.GetButton("Jump"))
		{
			isGrounded = false;
			verticalSpeed = 5.0f;
		}
		if(isGrounded == false)
		{
//			verticalSpeed = verticalSpeed - gravity * Time.deltaTime;
			verticalSpeed = verticalSpeed - gravity * Time.fixedDeltaTime;
//			transform.position = transform.position + new Vector3(0.0f,verticalSpeed * Time.deltaTime,0.0f);
			transform.position = transform.position + new Vector3(0.0f,verticalSpeed * Time.fixedDeltaTime,0.0f);

		}
		direction=new Vector3(0.0f,0.0f,0.0f);
	}

	void FixedUpdate()
	{
		InputControl();
		Move ();
	}

	// Update is called once per frame
	void Update () {
//		InputControl();
//		Move();
	}
}
