//Version 1.65 (10.08.2016)


#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using TriviaQuizGame.Types;

namespace TriviaQuizGame
{	
	/// <summary>
	/// This is a menu for Trivia Quiz Games. It appears under Tools in the top menu of Unity. In it you can
	/// import questions and answers from an XML to the selected game controller.
	/// </summary>
	public class TQGMenu:MonoBehaviour 
	{
		// Add a menu item named "Import Questions From XML" to Tools menu in the menu bar.
		[MenuItem("Tools/Trivia Quiz Game/Import questions from XML")]
		static void ImportXML() 
		{
			// Check the currently selected gameobject in the editor
			GameObject gameController  = Selection.activeObject as GameObject;

			// If the selected gameobject does not contain a TQGGameController component, give an error
			if ( gameController == null || gameController.GetComponent<TQGGameController>() == null && gameController.GetComponent<Category>() == null ) 
			{
				EditorUtility.DisplayDialog("Quiz object not selected!","You must select a Quiz object in order to import the questions to it. A Quiz is any object with a TQGGameController or Category component attached to it.","Ok");
				return;
			}

			// Open the system file menu so we can select a file to import. We can only import XML files
			var path = EditorUtility.OpenFilePanel("Overwrite with xml","","xml");

			// If we chose an XML file, load it into the currently selected game controller 
			if ( path.Length != 0 ) 
			{	
				// Run the LoadXML function in the game controller with the XML file we loaded
				if ( gameController.GetComponent<TQGGameController>() )    gameController.GetComponent<TQGGameController>().LoadXml(File.ReadAllText(path), false);

				// Run the LoadXML function in the category with the XML file we loaded
				if ( gameController.GetComponent<Category>() )    gameController.GetComponent<Category>().LoadXml(File.ReadAllText(path), false);

				// Apply the changes made to the game controller ( imported questions and answers )
				PrefabUtility.ReplacePrefab( gameController, PrefabUtility.GetPrefabParent(gameController), ReplacePrefabOptions.ConnectToPrefab);
			}
		}

		// Add a menu item named "Append Questions to an existing quiz, from XML" to Tools menu in the menu bar.
		[MenuItem("Tools/Trivia Quiz Game/Append Questions to an existing quiz, from XML")]
		static void AppendXML() 
		{
			// Check the currently selected gameobject in the editor
			GameObject gameController  = Selection.activeObject as GameObject;
			
			// If the selected gameobject does not contain a TQGGameController component, give an error
			if ( gameController == null || gameController.GetComponent<TQGGameController>() == null && gameController.GetComponent<Category>() == null ) 
			{
				EditorUtility.DisplayDialog("Quiz object not selected!","You must select a Quiz object in order to import the questions to it. A Quiz is any object with a TQGGameController or Category component attached to it.","Ok");
				return;
			}
			
			// Open the system file menu so we can select a file to import. We can only import XML files
			var path = EditorUtility.OpenFilePanel("Overwrite with xml","","xml");
			
			// If we chose an XML file, load it into the currently selected game controller 
			if ( path.Length != 0 ) 
			{	
				// Run the LoadXML function in the game controller with the XML file we loaded
				if ( gameController.GetComponent<TQGGameController>() )    gameController.GetComponent<TQGGameController>().LoadXml(File.ReadAllText(path), true);
				
				// Run the LoadXML function in the category with the XML file we loaded
				if ( gameController.GetComponent<Category>() )    gameController.GetComponent<Category>().LoadXml(File.ReadAllText(path), true);
				
				// Apply the changes made to the game controller ( imported questions and answers )
				PrefabUtility.ReplacePrefab( gameController, PrefabUtility.GetPrefabParent(gameController), ReplacePrefabOptions.ConnectToPrefab);
			}
		}

		// Add a menu item named "Export questions to XML" to Tools menu in the menu bar.
		[MenuItem("Tools/Trivia Quiz Game/Export questions to XML")]
		static void ExportXML() 
		{
			// Check the currently selected gameobject in the editor
			GameObject gameController  = Selection.activeObject as GameObject;
			 
			// If the selected gameobject does not contain a TQGGameController component, give an error
			if ( gameController == null || gameController.GetComponent<TQGGameController>() == null && gameController.GetComponent<Category>() == null ) 
			{
				EditorUtility.DisplayDialog("Quiz object not selected!","You must select a Quiz object in order to import the questions to it. A Quiz is any object with a TQGGameController or Category component attached to it.","Ok");
				return;
			}

			// Save the created XML file to a local address
			#if UNITY_5_3 || UNITY_5_3_OR_NEWER
			string path = EditorUtility.SaveFilePanel("Save XML", "", "NewXML" + ".xml", "xml");
			#else
			string path = EditorUtility.SaveFilePanel("Save XML", "", EditorApplication.currentScene + ".xml", "xml");
			#endif

			if (path.Length != 0) 
			{
				// Save the XML file to disk
				if ( gameController.GetComponent<TQGGameController>() )    File.WriteAllBytes(path, System.Text.Encoding.UTF8.GetBytes(gameController.GetComponent<TQGGameController>().SaveXml()));
				if ( gameController.GetComponent<Category>() )    File.WriteAllBytes(path, System.Text.Encoding.UTF8.GetBytes(gameController.GetComponent<Category>().SaveXml()));
			}
		}
	}
}