using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
	private Text m_text;
	private void Start() {
		var builder = new StringBuilder(2048);
		builder.AppendLine($"Unity: {Application.unityVersion}");
		builder.AppendLine($"App : {Application.identifier}:{Application.version} {Application.platform}");
		builder.AppendLine($"Device : {SystemInfo.deviceModel}, {SystemInfo.deviceName}, {SystemInfo.deviceType}");
		builder.AppendLine($"Battery : {SystemInfo.batteryStatus}, {SystemInfo.batteryLevel:0.00}");
		builder.AppendLine($"Processor : {SystemInfo.processorType}, {SystemInfo.processorCount}, {SystemInfo.processorFrequency}");
		builder.AppendLine($"Graphics : {SystemInfo.graphicsDeviceName}, {SystemInfo.graphicsDeviceType}, " +
		                   $"{SystemInfo.graphicsDeviceVendor}, {SystemInfo.graphicsDeviceVersion}, " +
		                   $"GMEM : {SystemInfo.graphicsMemorySize}, SM{SystemInfo.graphicsShaderLevel}");

		builder.AppendLine($"OS : {SystemInfo.operatingSystem}, MEM : {SystemInfo.systemMemorySize}, {SystemInfo.operatingSystemFamily}");
		builder.AppendLine("UsesReversedZBuffer : " + SystemInfo.usesReversedZBuffer);
		builder.Append($"NPOT : {SystemInfo.npotSupport}, INSTANCING : {SystemInfo.supportsInstancing}, Texture Size : {SystemInfo.maxTextureSize}, " +
		               $"Compute : {SystemInfo.supportsComputeShaders}");
		Debug.LogWarning(builder.ToString());
		m_text = GetComponent<Text>();
	}

	private void Update() {
		m_text.text = $"FPS : {(int)(1 / Time.smoothDeltaTime)}";
	}
}