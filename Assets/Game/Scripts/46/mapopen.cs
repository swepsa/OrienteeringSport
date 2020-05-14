using UnityEngine;
using System.Collections;

public class mapopen : MonoBehaviour {


		public float x = 0;
		public float y = -1;

	
		void FixedUpdate () {

				if (Input.GetKeyDown (KeyCode.Tab))
						y = -y;

				if ((x + y) >= 0 && (x + y) <= 90 && Input.GetKey (KeyCode.Q)) {
						x = x + y;
						transform.Translate (0, -y/100, -y/300, Space.Self);
						transform.Rotate(y,transform.localEulerAngles.y,0,Space.Self);
					//	transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
					
				}
	

		}
}
/*
using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

		public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
		public RotationAxes axes = RotationAxes.MouseXAndY;
		public float sensitivityX = 15F;
		public float sensitivityY = 15F;

		public float minimumX = -360F;
		public float maximumX = 360F;

		public float minimumY = -60F;
		public float maximumY = 60F;

		float rotationY = 0F;

		void Update ()

						rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
						rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

						transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
				}
		}
*/