<<<<<<< HEAD
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> 76d3febc2ae5b603ee0c6a8b5137eea50d582411
using System.Collections;

public static class CameraUtils {

	public static Bounds OrthographicBounds(this Camera camera)
	{
		float screenAspect = (float)Screen.width / (float)Screen.height;
		float cameraHeight = camera.orthographicSize * 2;
		Bounds bounds = new Bounds(
			camera.transform.position,
			new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
		return bounds;
	}

	public static Vector2 MouseClickToWorldPos(Vector2 mPos) {
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mPos.x, mPos.y, 0));
		return new Vector2(pos.x, pos.y);
	}

	//screen percent to screen dimensions.
	public static Vector2 FromScreenPercent(Bounds camBounds, Vector2 mPercent) {
		return new Vector2(mPercent.x * camBounds.extents.x * 2, mPercent.y * camBounds.extents.y * 2);
	}

	//screen dimensions (Input.mousePosition) to screen percent.
	public static Vector2 ToScreenPercent(Vector2 mPos) {
		return new Vector2(mPos.x/Screen.width, mPos.y/Screen.height);

	}

}
