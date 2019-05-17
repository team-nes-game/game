using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

	public Transform TARGET;
	public float SMOOTHING;

    // Start is called before the first frame update
    void Start() {
        
    }

    // This ensures that the camera will follow the player
    // without the camera getting ahead of the player in 
    // the "update" hierarchy, late update is always last
    void LateUpdate() {
        if (transform.position != TARGET.position) {
        	// Where we're going to make sure that our Z value doesn't get messed up
        	Vector3 cameraTarget = new Vector3(TARGET.position.x, TARGET.position.y, transform.position.z);

        	// Lerp to the position so we can go at a percentage rate of the SMOOTHING factor
        	transform.position = Vector3.Lerp(transform.position, cameraTarget, SMOOTHING);
		}
    }
}
