﻿using UnityEngine;
using System.Collections;
public class HeadGesture : MonoBehaviour {
	public bool isFacingDown = false;
	public bool isMovingDown = false;
	private float sweepRate = 100.0f;
	private float previousCameraAngle;
	void Start () {
		previousCameraAngle = CameraAngleFromGround ();
	}
	void Update () {
		isFacingDown = DetectFacingDown ();
		isMovingDown = DetectMovingDown ();
	}
	private float CameraAngleFromGround () {
		return Vector3.Angle (Vector3.down, transform.rotation
			* Vector3.forward);
	}
	private bool DetectFacingDown () {
		return (CameraAngleFromGround () < 60.0f);
	}
	private bool DetectMovingDown () {
		float angle = CameraAngleFromGround ();
		float deltaAngle = previousCameraAngle - angle;
		float rate = deltaAngle / Time.deltaTime;
		previousCameraAngle = angle;
		return (rate >= sweepRate);
	}
}