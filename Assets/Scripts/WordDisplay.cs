using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordDisplay : MonoBehaviour {

	public Text text;
	public float fallSpeed = 10f;

	public void SetWord (string word)
	{
		text.text = word;
	}

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.fontStyle = FontStyle.BoldAndItalic;
	}

	public void RemoveWord ()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.Translate(0f, -fallSpeed * Time.deltaTime * UserSettings.speedMultiplier, 0f);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "boundary")
		{
			Destroy(gameObject);
			SceneManager.LoadScene(2);
		}
	}
	
	
}
