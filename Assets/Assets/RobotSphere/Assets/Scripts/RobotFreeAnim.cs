using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RobotFreeAnim : MonoBehaviour 
{

	Vector3 rot = Vector3.zero;
	float rotSpeed = 60f;
	Animator anim;
	private bool useTool;

	//Touch
	private Touch touch;
	private Vector2 touchBegan;

	private Vector3 movementVector;
	private bool move;
	private float movementTimer;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
		useTool = false;

		touchBegan = Vector2.zero;

		move = false;
		movementTimer = 0.5f;
	}

	// Update is called once per frame
	void Update()
	{
	}

    private void FixedUpdate()
    {
		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);

			// Walk
			if (touch.phase == TouchPhase.Began)
			{
				touchBegan = touch.position;
				move = true;
				anim.SetBool("Walk_Anim", true);
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				move = false;
				anim.SetBool("Walk_Anim", false);
			}

			if (touch.phase == TouchPhase.Moved)
			{
				// Rotate Left
				if (touchBegan.x > touch.position.x)
				{
					rot[1] -= rotSpeed * Time.fixedDeltaTime;
				}

				// Rotate Right
				if (touchBegan.x < touch.position.x)
				{
					rot[1] += rotSpeed * Time.fixedDeltaTime;
				}
			}

		}

		if (touch.phase == TouchPhase.Ended)
		{
			move = false;
			anim.SetBool("Walk_Anim", false);
		}

		// Roll
		if (useTool && !move)
		{
			anim.SetBool("Roll_Anim", true);
		}
		else
		{
			anim.SetBool("Roll_Anim", false);
		}
		//CheckInput();
		gameObject.transform.eulerAngles = rot;


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

	void CheckInput()
	{
		if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

			// Walk
			if (touch.phase == TouchPhase.Began)
			{
				touchBegan = touch.position;
				move = true;
				anim.SetBool("Walk_Anim", true);
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				move = false;
				anim.SetBool("Walk_Anim", false);
			}

			if(touch.phase == TouchPhase.Stationary)
            {
				Debug.Log("touchBegan: " + touchBegan);
				Debug.Log("touch.pos: " + touch.position);
				// Rotate Left
				if (touchBegan.x > touch.position.x)
				{
					rot[1] -= rotSpeed * Time.fixedDeltaTime;
				}

				// Rotate Right
				if (touchBegan.x < touch.position.x)
				{
					rot[1] += rotSpeed * Time.fixedDeltaTime;
				}
			}
		}

		// Roll
		if (useTool && !move)
		{
			anim.SetBool("Roll_Anim", true);
		}
		else
		{
			anim.SetBool("Roll_Anim", false);
		}

	}

    private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.layer == 6)
        {
			transform.DOMoveY(transform.position.y + 0.675f, 0.33f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "LootTile")
		{
            if (!move)
            {
				useTool = true;
				other.gameObject.GetComponent<LootTile>().triggerPlayer = true;
				if(other.gameObject.transform.GetChild(0).gameObject.activeSelf == false)
                {
					useTool = false;
                }
            }
		}
	}
    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.tag == "LootTile")
		{
			useTool = false;
			other.gameObject.GetComponent<LootTile>().triggerPlayer = false;
		}
	}
}
