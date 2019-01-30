
using UnityEngine;

public class MinMaxRangeAttribute : PropertyAttribute
{
	public int m_iMinLimit = 0;
	public int m_iMaxLimit = 1;

	public MinMaxRangeAttribute(int iMinLimit, int iMaxLimit)
	{
		m_iMinLimit = iMinLimit;
		m_iMaxLimit = iMaxLimit;
	}
}

[System.Serializable]
public class MinMaxRange
{
	public int m_iMin = 0;
	public int m_iMax = 1;
	public int RandomValue
	{
		get
		{
			return Random.Range(m_iMin, m_iMax);
		}
	}

	public MinMaxRange()
	{

	}

	public MinMaxRange(int iMin, int iMax)
	{
		m_iMin = iMin;
		m_iMax = iMax;
	}


	static public bool operator > (MinMaxRange tRange, int iValue)
	{
		return tRange.m_iMax > iValue;
	}
	static public bool operator < (MinMaxRange tRange, int iValue)
	{
		return tRange.m_iMin < iValue;
	}
	static public bool operator >= (MinMaxRange tRange, int iValue)
	{
		return tRange.m_iMax >= iValue;
	}
	static public bool operator <= (MinMaxRange tRange, int iValue)
	{
		return tRange.m_iMin <= iValue;
	}
}
