using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField] float moveSpeed = 10.0f;
	Vector3 destinationPosition;
	PlayerState playerState = PlayerState.Idle;

	float waitRatio = 0;
    void Start()
	{ 
		Managers.Input.mouseAction -= OnMouseClicked;
		Managers.Input.mouseAction += OnMouseClicked;
	}

	void UpdateDie()
    {

    }


	void UpdateIdle()
	{
		waitRatio = Mathf.Lerp(waitRatio, 0, 10.0f * Time.deltaTime);
		Animator anim = GetComponent<Animator>();
		anim.SetFloat("Ratio", waitRatio);
		anim.Play("WAITRUN");
	}


	void UpdateWalk()
    {
		Vector3 dir = destinationPosition - transform.position;
		if (dir.magnitude < 0.001f)
			playerState = PlayerState.Idle;
		else
		{
			float moveDist = Mathf.Clamp(moveSpeed * Time.deltaTime, 0, dir.magnitude);
			transform.position += dir.normalized * moveDist;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
		}

		waitRatio = Mathf.Lerp(waitRatio, 1, 10.0f * Time.deltaTime);
		Animator anim = GetComponent<Animator>();
		anim.SetFloat("Ratio", waitRatio);
		anim.Play("WAITRUN");
	}

	
    void Update()
    {

		switch (playerState)
		{
			case PlayerState.Die:
				UpdateDie();
				break;
			case PlayerState.Idle:
				UpdateIdle();
				break;
			case PlayerState.Walk:
				UpdateWalk();
				break;
		}
    }

  

	void OnMouseClicked(MouseEvent mouseEvent)
    {
		if (playerState==PlayerState.Die)
			return;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1.0f);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 100f, LayerMask.GetMask("Wall")))
        {
			destinationPosition= hit.point;
			playerState = PlayerState.Walk;
        }
    }
}
