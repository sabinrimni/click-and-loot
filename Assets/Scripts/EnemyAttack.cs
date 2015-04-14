using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackTime;
	public float coolDown;
	public Rigidbody2D rbody;
	PlayerHealth eh;
	
	
	void Start () {
		attackTime = 0;
		coolDown = 2.0f;
		target = GameObject.Find("Player");
		rbody = gameObject.GetComponent<Rigidbody2D> ();
		eh = (PlayerHealth)target.GetComponent("Camera");
	}
	
	
	void Update () {
		if(attackTime > 0)
			attackTime -= Time.deltaTime;
		
		if(attackTime < 0)
			attackTime = 0;

		
		if(attackTime == 0) {
			Attack();
			attackTime = coolDown;
		}
		
	}
	
		private void Attack() {
		float distance = Vector3.Distance(target.transform.position, transform.position);
		
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);

	}
	void OnCollisionEnter2D(Collision2D col){
			if (col.gameObject.tag == "Player") {
				eh.AddjustCurrentHealth(-10);
				Debug.Log("Attacked");
			}

	}
}