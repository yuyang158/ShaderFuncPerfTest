using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenShaderFuncBlit : MonoBehaviour {
	private RenderTexture m_2048Texture;
	private void Start() {
		m_2048Texture = new RenderTexture(2048, 2048, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Default);
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest) {
		if( SwitchTestShader.Selection == null ) {
			return;
		}
		Graphics.Blit(null, m_2048Texture, SwitchTestShader.Selection);
		Graphics.Blit(m_2048Texture, dest);
	}
}