﻿using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject refer;
	[SerializeField] private float spawnRepeatTime;
	[SerializeField] private float lastSpawnTime = 0;
	[SerializeField] private static string numOfSpawns = "0";

	void Start () {
		lastSpawnTime = Time.time + spawnRepeatTime;
		Vector3 pos = getSpawnPoint ();
		RaycastHit _hit;
		if (Physics.Raycast(refer.transform.position, -refer.transform.up, out _hit, 200)) {
			Instantiate(enemyPrefab, pos, Quaternion.LookRotation(_hit.normal));
			int num = int.Parse (numOfSpawns);
			num+=1;
			numOfSpawns = num.ToString ();
		}
	}

	public static string getNum(){
		int num = int.Parse (numOfSpawns);
		num-=1;
		return num.ToString();
	}

	void Update(){
		if (Time.time > lastSpawnTime) {
			lastSpawnTime = Time.time + spawnRepeatTime;
			Vector3 pos = getSpawnPoint ();
			RaycastHit _hit;
			if (Physics.Raycast(refer.transform.position, -refer.transform.up, out _hit, 200)) {
				Instantiate(enemyPrefab, pos, Quaternion.LookRotation(_hit.normal));
				int num = int.Parse (numOfSpawns);
				num+=1;
				numOfSpawns = num.ToString ();
			}
		}
	}

	Vector3 getSpawnPoint(){
		Vector3 spot = new Vector3(Random.Range(200f,300f), 1f, 285.3f);
		return spot;
	}
}
