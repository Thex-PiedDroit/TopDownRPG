
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameManager : MonoBehaviour
{
#region Variables (public)

	static public GameManager Instance = null;

	#endregion

#region Variables (private)

	public Camera CurrentCamera { get; private set; } = null;

	#endregion


	private void Awake()
	{
		if (Instance != null)
		{
			if (Instance != this)
			{
				EditorUtility.DisplayDialog("Multiple game managers detected", "You can only have one existing game manager, something went wrong somewhere", "Ok sorry");
				Destroy(this);
			}

			return;
		}

		Instance = this;

		CurrentCamera = Camera.main;
	}
}
