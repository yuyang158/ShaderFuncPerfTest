using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTestShader : MonoBehaviour {
	private Dropdown m_dropdown;
	public Material[] MaterialsToTest;
	public static Material Selection;

	private void Start() {
		m_dropdown = GetComponent<Dropdown>();
		
		m_dropdown.onValueChanged.AddListener(index => {
			Selection = MaterialsToTest[index];
		});
		
		foreach( var material in MaterialsToTest ) {
			m_dropdown.options.Add(new Dropdown.OptionData(material.name));
		}

		Selection = MaterialsToTest[0];
	}
}