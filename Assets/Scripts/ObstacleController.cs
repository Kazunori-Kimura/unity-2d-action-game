using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	public float scrollSpeed = 0.15f;

	private Renderer render;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		// 画面外に出たら削除
		if (!render.isVisible) {
			Destroy (this.gameObject);
		}
	}

	void FixedUpdate() {
		var pos = transform.localPosition;
		transform.localPosition = new Vector3 (pos.x - scrollSpeed, pos.y, pos.z);
	}
}
