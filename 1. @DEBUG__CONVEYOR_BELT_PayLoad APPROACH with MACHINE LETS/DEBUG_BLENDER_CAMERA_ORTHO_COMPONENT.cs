using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_BLENDER_CAMERA_ORTHO_COMPONENT : MonoBehaviour
{


	public float[] polar_angles;

	public float cam_size_limit = 1f;



	
	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			StopAllCoroutines();

			StartCoroutine(STIMULATE());
			//
		}

	}
	


	IEnumerator STIMULATE()
	{
		#region frame_rate
		// QualitySettings.vSyncCount = 2;
		yield return null;
		yield return null;
		//
		#endregion

		Debug.Log("// somthng //");


		Camera cam = gameObject.GetComponent<Camera>();

		//
		if(cam.orthographic)
		{
			yield return orthographic_movement();
		}
		else
		{
			yield return perspective_movement();
		}
		//


		yield return null;
	}



	IEnumerator orthographic_movement()
	{
		Vector3 cam_focus = Vector3.zero;

		Transform cam_Tr = this.transform;
		Camera cam = cam_Tr.GetComponent<Camera>();
		float cam_size = cam.orthographicSize;

		while (true)
		{
			//
			// Debug.Log(Z.Atan2(y, x) / Mathf.PI * 180);


			DRAW.dt = Time.deltaTime;


			cam_size += -Input.mouseScrollDelta.y * 0.5f;
			if (cam_size < this.cam_size_limit) { cam_size = this.cam_size_limit; }

			cam.orthographicSize = cam_size;





			// adjust orbit to PI/3 phi //
			if (true)
			{
				Vector3 offset = cam_Tr.position - cam_focus;
				float[] polar_angles = Z.get_polar_angles(offset);

				this.polar_angles = polar_angles;
				//

				// xz polar angle remain same while y-xz plane angle being altered//
				polar_angles[0] += 0f;
				polar_angles[1] = +Mathf.PI / 3;
				// xz polar angle remain same while y-xz plane angle being altered//



				this.polar_angles = polar_angles;



				Vector3 new_v = Z.get_pos_from_polar3D
				(
					polar_angles[0],
					Mathf.PI / 3
				);


				// assign transform to camera //
				cam_Tr.position = cam_focus + new_v * offset.magnitude;
				cam_Tr.forward = -new_v;
				// assign transform to camera //

			}





			//
			if (Input.GetMouseButton(2))
			{
				// orbit //
				// when alt is held down //
				if (true)
				{
					Vector3 offset = cam_Tr.position - cam_focus;
					float[] polar_angles = Z.get_polar_angles(offset);

					this.polar_angles = polar_angles;
					//
					//while (true)
					//{
					//if (!Input.GetMouseButton(2)) { break; }

					polar_angles[0] += -Input.GetAxis("Mouse X") * 0.06f;
					polar_angles[1] += +Input.GetAxis("Mouse Y") * 0.03f;

					if (polar_angles[1] > Mathf.PI / 2 * 0.8f)
					{
						polar_angles[1] = Mathf.PI / 2 * 0.8f;
					}

					if (polar_angles[1] < 0.1f * Mathf.PI / 2)
					{
						polar_angles[1] = 0.1f * Mathf.PI / 2;
					}
					this.polar_angles = polar_angles;

					Vector3 new_v = Z.get_pos_from_polar3D
					(
						polar_angles[0],
						polar_angles[1]
					);


					// assign transform to camera //
					cam_Tr.position = cam_focus + new_v * offset.magnitude;
					cam_Tr.forward = -new_v;
					// assign transform to camera //

					//yield return null;

					//}
				}
				// orbit //



			}
			//



			// cam_move //
			// focus movement //

			Vector3 nav_z = Z.ortho(Vector3.up, Z.ortho(cam_Tr.forward, Vector3.up)).normalized,
					nav_x = Z.ortho(nav_z, Vector3.up);


			DRAW.col = Color.blue;
			DRAW.LINE(Vector3.zero, nav_z);
			DRAW.col = Color.red;
			DRAW.LINE(Vector3.zero, nav_x);

			float cam_move_vel = 0.15f;
			if (Input.GetKey(KeyCode.A))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_x * -cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_x * +cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_z * -cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			else if (Input.GetKey(KeyCode.W))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_z * +cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			// cam_move //



			yield return null;
		}



	}


	IEnumerator perspective_movement()
	{
		Vector3 cam_focus = Vector3.zero;

		Transform cam_Tr = this.transform;
		Camera cam = this.gameObject.GetComponent<Camera>();


		// float cam_size = ;


		while (true)
		{
			//
			// Debug.Log(Z.Atan2(y, x) / Mathf.PI * 180);





			DRAW.dt = Time.deltaTime;


			float mouse_scroll = Input.mouseScrollDelta.y * 0.5f;


			if (mouse_scroll > 0f)
			{
				//
				if (distance_between_cam_and_floor() > 5)
				{
					cam_Tr.position += cam_Tr.forward * mouse_scroll;
				}
			}
			else
			{
				cam_Tr.position += cam_Tr.forward * mouse_scroll;
			}





			// adjust orbit to PI/3 phi //
			if (true)
			{
				Vector3 offset = cam_Tr.position - cam_focus;
				float[] polar_angles = Z.get_polar_angles(offset);

				this.polar_angles = polar_angles;
				//

				// xz polar angle remain same while y-xz plane angle being altered//
				polar_angles[0] += 0f;
				polar_angles[1] = +Mathf.PI / 3;
				// xz polar angle remain same while y-xz plane angle being altered//



				this.polar_angles = polar_angles;



				Vector3 new_v = Z.get_pos_from_polar3D
				(
					polar_angles[0],
					Mathf.PI / 3
				);


				// assign transform to camera //
				cam_Tr.position = cam_focus + new_v * offset.magnitude;
				cam_Tr.forward = -new_v;
				// assign transform to camera //

			}





			//
			if (Input.GetMouseButton(2))
			{
				// orbit //
				// when alt is held down //
				if (true)
				{
					Vector3 offset = cam_Tr.position - cam_focus;
					float[] polar_angles = Z.get_polar_angles(offset);

					this.polar_angles = polar_angles;
					//
					//while (true)
					//{
					//if (!Input.GetMouseButton(2)) { break; }

					polar_angles[0] += -Input.GetAxis("Mouse X") * 0.06f;
					polar_angles[1] += +Input.GetAxis("Mouse Y") * 0.03f;

					if (polar_angles[1] > Mathf.PI / 2 * 0.8f)
					{
						polar_angles[1] = Mathf.PI / 2 * 0.8f;
					}

					if (polar_angles[1] < 0.1f * Mathf.PI / 2)
					{
						polar_angles[1] = 0.1f * Mathf.PI / 2;
					}
					this.polar_angles = polar_angles;

					Vector3 new_v = Z.get_pos_from_polar3D
					(
						polar_angles[0],
						polar_angles[1]
					);


					// assign transform to camera //
					cam_Tr.position = cam_focus + new_v * offset.magnitude;
					cam_Tr.forward = -new_v;
					// assign transform to camera //

					//yield return null;

					//}
				}
				// orbit //



			}
			//



			// cam_move //
			// focus movement //

			Vector3 nav_z = Z.ortho(Vector3.up, Z.ortho(cam_Tr.forward, Vector3.up)).normalized,
					nav_x = Z.ortho(nav_z, Vector3.up);


			DRAW.col = Color.blue;
			DRAW.LINE(Vector3.zero, nav_z);
			DRAW.col = Color.red;
			DRAW.LINE(Vector3.zero, nav_x);

			float cam_move_vel = 0.15f;
			if (Input.GetKey(KeyCode.A))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_x * -cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_x * +cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_z * -cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			else if (Input.GetKey(KeyCode.W))
			{
				Vector3 v = cam_Tr.position - cam_focus;
				cam_focus += nav_z * +cam_move_vel;
				cam_Tr.position = cam_focus + v;
			}
			// cam_move //



			yield return null;
		}





	}




	public float distance_between_cam_and_floor()
	{
		Vector3 a = this.transform.position;
		Vector3 n = this.transform.forward.normalized;


		Vector3 o = Vector3.zero;
		Vector3 up = Vector3.up;


		float L = -(Vector3.Dot(a - o, up)) / Vector3.Dot(n, up);

		return L;

	}










	#region Z
	public static class Z
	{

		#region polar 3D
		public static float[] get_polar_angles(Vector3 v)
		{
			return new float[2]
			{
				Z.Atan2(v.z , v.x),
				Mathf.Acos( Z.dot(v , Vector3.up) / v.magnitude)
			};

		}


		public static Vector3 get_pos_from_polar3D(float xy_angle, float up_angle)
		{
			return new Vector3()
			{
				x = Mathf.Cos(xy_angle) * Mathf.Sin(up_angle),
				z = Mathf.Sin(xy_angle) * Mathf.Sin(up_angle),
				y = Mathf.Cos(up_angle),
			};
		}

		#endregion



		public static Vector3 rotate_plane(Vector3 v, Vector3 axis, float angle)
		{
			axis = axis.normalized;
			float axis_project = Z.dot(v, axis);
			//
			Vector3 nY = Z.ortho(axis, v);
			Vector3 nX = Z.ortho(nY, axis);


			Vector3 new_v = nX * Mathf.Cos(angle) + nY * Mathf.Sin(angle);

			return new_v + axis * axis_project;
		}


		//
		public static float Atan2(float y, float x)
		{
			float angle = Mathf.Atan(y / x);

			if (x < 0f) { angle += 1 * Mathf.PI; }
			if (angle < 0f) { angle += 2 * Mathf.PI; }

			return angle;
		}
		//


		#region dot , area
		public static float dot(Vector3 a, Vector3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		public static float area(Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.y;
		}

		public static Vector3 ortho(Vector3 na, Vector3 nb)
		{
			return -Vector3.Cross(na, nb);
		}
		#endregion


	}
	#endregion


	public static class DRAW
	{
		public static Color col = Color.red;
		public static float dt = Time.deltaTime;
		public static Vector3 up = Vector3.forward;

		public static void LINE(Vector3 a, Vector3 b, float de = 1f / 100)
		{
			//
			Vector3 nX = b - a;
			Vector3 nY = Z.ortho(up, nX);
			nY = nY.normalized;

			Debug.DrawLine(a + nY * de, b + nY * de, DRAW.col, DRAW.dt);
			Debug.DrawLine(a - nY * de, b - nY * de, DRAW.col, DRAW.dt);
			//
		}
	}


}
