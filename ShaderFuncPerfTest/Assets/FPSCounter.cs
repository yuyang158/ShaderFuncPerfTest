using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
	private Text m_text;
	private void Start() {
		m_text = GetComponent<Text>();
	}

	private void Update() {
		m_text.text = $"FPS : {(int)(1 / Time.smoothDeltaTime)}";
	}
}