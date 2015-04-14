using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public GameObject go;
	private Transform myTransform;
	public PlayerHealth ph;
	
	// Use this for initialization
	void Awake() {
		myTransform = transform;
	}

	void Start () {
		go = GameObject.FindGameObjectWithTag("Player");
		ph = new PlayerHealth ();
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {    
		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f;
		if (dir != Vector3.zero) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, 
			                                         Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

		myTransform.position += (target.position -myTransform.position).normalized;
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Colide");
		if (col.gameObject.tag == "Player") {
			ph.AddjustCurrentHealth(-10);
			Debug.Log("Attacked");
		}
		
	}
}