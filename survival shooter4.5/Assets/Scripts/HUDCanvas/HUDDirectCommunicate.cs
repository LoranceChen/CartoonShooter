using UnityEngine;
using System.Collections;

public class HUDDirectCommunicate : MonoBehaviour 
{
		public InputCommunicate inputCommunicate;
		void Awake()
		{
			inputCommunicate=GameObject.FindGameObjectWithTag("Input").GetComponent<InputCommunicate>();
		}
}
