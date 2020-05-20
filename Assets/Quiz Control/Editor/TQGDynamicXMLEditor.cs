//Version 1.65 (10.08.2016)


using UnityEngine;
using System.Collections;
using UnityEditor;
using TriviaQuizGame.Types;

namespace TriviaQuizGame
{
	[CustomEditor(typeof(TQGDynamicXML))]
	public class TQGDynamicXMLEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			// Show the component which this editor is based on
			DrawDefaultInspector();

			// Get the original dynamic XML component
			TQGDynamicXML dynamicXML = (TQGDynamicXML)target;

			// If the address type of the component is "Online", show the correct fields in the component
			if ( dynamicXML.addressType.ToString() == "Online" )
			{
				GUILayout.Label("Enter online XML address here...");

				// You can enter the web address of the XML in this field
				dynamicXML.xmlAddress = EditorGUILayout.TextField(dynamicXML.xmlAddress);

				// Save the changes made to the address ( May be deprecated soon? )
				EditorUtility.SetDirty(dynamicXML);
			}
			else if ( dynamicXML.addressType.ToString() == "Local" )
			{
				if(GUILayout.Button("Load XML address from computer"))
				{
					// Open the system file menu so we can select a file to import. We can only import XML files
					var path = EditorUtility.OpenFilePanel("Overwrite with xml","","xml");

					// Apply the file address
					if ( path.Length != 0 )    dynamicXML.xmlAddress = path;
				}

				// You can enter the local file address of the XML in this field
				dynamicXML.xmlAddress = EditorGUILayout.TextField(dynamicXML.xmlAddress);

				// Save the changes made to the address ( May be deprecated soon? )
				EditorUtility.SetDirty(dynamicXML);
			}
		}
	}
}