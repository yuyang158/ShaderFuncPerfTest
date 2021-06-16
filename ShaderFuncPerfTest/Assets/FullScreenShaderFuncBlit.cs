using UnityEngine;

public class FullScreenShaderFuncBlit : MonoBehaviour {
	private static RenderTexture m_renderTexture;

	public static void ChangeResolution(int resolution) {
		m_renderTexture = new RenderTexture(resolution, resolution, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Default);
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest) {
		if( SwitchTestShader.Selection == null ) {
			return;
		}

		if( m_renderTexture == null )
			return;
		Graphics.Blit(null, m_renderTexture, SwitchTestShader.Selection);
		Graphics.Blit(m_renderTexture, dest);
	}
}