using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	Rigidbody2D rbody;
	Animator anim;
	PlayerHealth ph;
	
	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		ph = new PlayerHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (movement_vector != Vector2.zero) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat("axis_x", movement_vector.x);
			anim.SetFloat("axis_y", movement_vector.y);
		} else {
			anim.SetBool("isWalking", false);
		}

		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime *200);
	}

	public void updateHealth(int adj)
	{
		ph.AddjustCurrentHealth(adj);
	}
}