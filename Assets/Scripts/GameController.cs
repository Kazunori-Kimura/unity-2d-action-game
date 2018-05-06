using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	/// <summary>
	/// 障害物
	/// </summary>
	public GameObject obstaclePrefab;

	/// <summary>
	/// 障害物の生成間隔
	/// </summary>
	public float spawnInterval = 1.0f;

	/// <summary>
	/// 障害物の最低位置
	/// </summary>
	public float obstaclePositionMin = 0f;
	/// <summary>
	/// 障害物の最高位置
	/// </summary>
	public float obstaclePositionMax = 10f;

	/// <summary>
	/// 画面右下
	/// </summary>
	private Vector3 bottomRight;

	// Use this for initialization
	void Start () {
		// 画面端の取得
		var camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		// 右下
		bottomRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		bottomRight.Scale (new Vector3 (1, -1, 1)); //上下反転

		StartCoroutine (SpawnObstacle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnObstacle() {
		while (true) {
			var pos = new Vector3 (bottomRight.x, 
				Random.Range(obstaclePositionMin, obstaclePositionMax), transform.position.z);
			Instantiate (obstaclePrefab, pos, transform.rotation);
			// 生成間隔待つ
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
