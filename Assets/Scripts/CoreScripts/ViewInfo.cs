using UnityEngine;

public class ViewInfo : MonoBehaviour
{
	public static Vector2 Screen => GetWorldPoint(new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height));

	public static Vector3 GetWorldPoint(Vector2 screenPosition)
	{
		var obj = Camera.main.ScreenPointToRay(screenPosition);

		var dir = obj.direction;
		var or = obj.origin;

		Vector3 nor = new Vector3(0, 0, 1);
		Vector3 vector = new Vector3(0, 0, 0);

		float prd = Vector3.Dot(dir, nor);

		float magn = Vector3.Dot(vector - or, nor) / prd;

		Vector3 res = or + magn * dir;
		return res;
	}

	public static RaycastHit2D RacyastFromPoint(Vector2 screenPosition)
	{
		var screenPoint = GetWorldPoint(screenPosition);
		var result = Physics2D.Raycast(screenPoint, Vector3.forward);
		return result;
	}
}
