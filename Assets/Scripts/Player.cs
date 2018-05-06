using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	/// <summary>
	/// 移動速度
	/// </summary>
	public float moveSpeed = 5.0f;
	/// <summary>
	/// ジャンプ力
	/// </summary>
	public float jumpForce = 100.0f;

	private Rigidbody2D rbody;

	private Animator animator;

	private bool isRunning = false;

	private bool isJumping = false;

	private bool isFalling = false;

	/// <summary>
	/// ジャンプボタンの押下フラグ
	/// </summary>
	private bool pushedJumpButton = false;
	/// <summary>
	/// 左右移動
	/// </summary>
	private float horizontalValue = 0.0f;


	// Use this for initialization
	void Start () {
		this.rbody = GetComponent<Rigidbody2D> ();
		this.animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetInputState ();
		UpdateMecanim ();
	}

	void FixedUpdate() {
		Move ();
		Jump ();
	}


	void UpdateMecanim() {
		// running
		isRunning = horizontalValue != 0;
		animator.SetBool ("isRunning", isRunning);
		// jumping
		animator.SetBool ("isJumping", isJumping);
		// falling
		isFalling = this.rbody.velocity.y < 0;
		animator.SetBool ("isFalling", isFalling);
	}

	void GetInputState() {
		this.pushedJumpButton = Input.GetButtonDown ("Jump");
		this.horizontalValue = Input.GetAxisRaw ("Horizontal");
	}

	void Move() {
		this.rbody.velocity = new Vector2(moveSpeed * this.horizontalValue,
			this.rbody.velocity.y);

		// 向き
//		if ((transform.localScale.x > 0 && horizontalValue < 0) || (transform.localScale.x < 0 && horizontalValue > 0)) {
//			// 反転させる
//			var scale = transform.localScale;
//			scale.x *= -1;
//			transform.localScale = scale;
//		}
	}

	void Jump() {
		if (!this.isJumping && this.pushedJumpButton) {
			this.rbody.AddForce (Vector2.up * this.jumpForce);
			this.isJumping = true;
		}
	}

	/// <summary>
	/// 地面との衝突判定
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			this.isJumping = false;
		}
	}
}
