
using UnityEngine;

public class Data : MonoBehaviour
{
	public static Data instance;

	public string Name;
	public int LV,HP,maxHP,G;

	private void Awake()
	{
		instance = this;
	}
}
