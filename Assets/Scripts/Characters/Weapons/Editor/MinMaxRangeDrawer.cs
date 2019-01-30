
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
public class MinMaxRangeDrawer : PropertyDrawer
{
	public override float GetPropertyHeight(SerializedProperty pProperty, GUIContent pLabel)
	{
		return base.GetPropertyHeight(pProperty, pLabel) + 16.0f;
	}

	public override void OnGUI(Rect tPosition, SerializedProperty pProperty, GUIContent pLabel)
	{
		if (pProperty.type != "MinMaxRange")
		{
			Debug.LogWarning("Use only with MinMaxRange type");
			return;
		}


		MinMaxRangeAttribute tRange = attribute as MinMaxRangeAttribute;
		SerializedProperty tMinValue = pProperty.FindPropertyRelative("m_iMin");
		SerializedProperty tMaxValue = pProperty.FindPropertyRelative("m_iMax");
		float fNewMin = tMinValue.intValue;
		float fNewMax = tMaxValue.intValue;

		float fDivisionX = tPosition.width * 0.33f;
		float fDivisionY = tPosition.height * 0.5f;

		EditorGUI.LabelField(new Rect(tPosition.x, tPosition.y, fDivisionX, fDivisionY), pLabel);

		EditorGUI.LabelField(new Rect(tPosition.x, tPosition.y + fDivisionY, tPosition.width, fDivisionY), tRange.m_iMinLimit.ToString());
		EditorGUI.LabelField(new Rect(tPosition.x + tPosition.width - 28.0f, tPosition.y + fDivisionY, tPosition.width, fDivisionY), tRange.m_iMaxLimit.ToString());
		EditorGUI.MinMaxSlider(new Rect(tPosition.x + 24.0f, tPosition.y + fDivisionY, tPosition.width - 48.0f, fDivisionY), ref fNewMin, ref fNewMax, tRange.m_iMinLimit, tRange.m_iMaxLimit);

		EditorGUI.LabelField(new Rect(tPosition.x + fDivisionX, tPosition.y, fDivisionX, fDivisionY), "From: ");
		fNewMin = Mathf.Clamp(EditorGUI.IntField(new Rect(tPosition.x + fDivisionX + 40.0f, tPosition.y, fDivisionX - 24.0f, fDivisionY), (int)fNewMin), tRange.m_iMinLimit, (int)fNewMax);
		EditorGUI.LabelField(new Rect(tPosition.x + (fDivisionX * 2.0f), tPosition.y, fDivisionX, fDivisionY), "To: ");
		fNewMax = Mathf.Clamp(EditorGUI.IntField(new Rect(tPosition.x + (fDivisionX * 2.0f) + 24.0f, tPosition.y, fDivisionX - 24.0f, fDivisionY), (int)fNewMax), (int)fNewMin, tRange.m_iMaxLimit);

		tMinValue.intValue = (int)fNewMin;
		tMaxValue.intValue = (int)fNewMax;
	}
}
