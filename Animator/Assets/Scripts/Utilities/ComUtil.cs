using UnityEngine;

public static class ComUtil
{
	public static bool AlmostEquals(this float standard, float target, float range = float.Epsilon)
	{
		return standard >= target - range && standard <= target + range;
	}

	public static bool AlmostEquals(this Vector2 standard, Vector2 target)
	{
		return standard.x.AlmostEquals(target.x) && standard.y.AlmostEquals(target.y);
	}

	static public void DestroyChildren(this Transform tf)
	{
		while (0 != tf.childCount)
		{
			Transform tfChild = tf.GetChild(0);
			tfChild.SetParent(null);

			if (null != tfChild.gameObject)
				GameObject.Destroy(tfChild.gameObject);
		}
	}
}