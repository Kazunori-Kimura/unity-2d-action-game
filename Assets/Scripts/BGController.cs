using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {
	/// <summary>
	/// スクロールスピード
	/// </summary>
	public float speed = 0.01f;

	private Renderer render;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float scroll = Mathf.Repeat (Time.time * speed, 1);
		Vector2 offset = new Vector2 (scroll, 0);
		render.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
