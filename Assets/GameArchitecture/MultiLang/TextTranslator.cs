using UnityEngine;
using UnityEngine.UI;

public class TextTranslator : MonoBehaviour
{
	[Header ("Enter your word key here.")]
	[SerializeField] private string key;

	private void Start()
	{
		GetComponent<Text>().text = MultiLang.GetTranslation(key);
	}
}
