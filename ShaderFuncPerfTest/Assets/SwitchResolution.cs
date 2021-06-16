using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SwitchResolution : MonoBehaviour {
	private static readonly int[] m_resolutions = { 1024, 2048, 4096, 8192 };

	private void Start() {
		FullScreenShaderFuncBlit.ChangeResolution(m_resolutions[0]);
		var dropdown = GetComponent<Dropdown>();
		dropdown.onValueChanged.AddListener(index => {
			FullScreenShaderFuncBlit.ChangeResolution(m_resolutions[index]);
		});
		
		dropdown.AddOptions(m_resolutions.ToList().ConvertAll(value => value.ToString()));
	}
}