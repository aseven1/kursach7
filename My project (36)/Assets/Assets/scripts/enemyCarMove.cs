using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCarMove : MonoBehaviour {

	public float speed = 7f;
    public TextMesh equationText;
	// Use this for initialization
	void Start () {
		equationText.text=this.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
	}
}
