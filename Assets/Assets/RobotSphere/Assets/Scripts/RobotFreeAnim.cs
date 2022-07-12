using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 60f;
	Animator anim;

	private Vector3 movementVector;
	private bool move;
	private float movementTimer;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;

		//movementVector = new Vector3(Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y), 0, Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y)) * 0.05f;
		move = false;
		movementTimer = 0.5f;
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;
	}

    private void FixedUpdate()
    {
		if (move)
        {
			movementTimer -= Time.deltaTime;
			if(movementTimer < 0f)
            {
				movementVector = new Vector3(Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y), 0, Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y)) * 0.0625f;
				transform.localPosition += movementVector;
			}
        }
        else
        {
			movementTimer = 0.5f;
        }
    }

    void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			move = true;
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			move = false;
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKey(KeyCode.Space))
		{
			anim.SetBool("Roll_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			anim.SetBool("Roll_Anim", false);
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

    private void OnTriggerEnter(Collider collision)
    {
		if(collision.gameObject.layer == 6)
        {
			transform.DOMoveY(transform.position.y + 0.675f, 0.33f);
        }
        Debug.Log("Trigger Object: " + collision.gameObject.name);
    }

}
