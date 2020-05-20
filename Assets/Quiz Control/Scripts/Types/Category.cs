//Version 1.83 (14.04.2017)

using System;
using UnityEngine;
using System.Xml;
using TriviaQuizGame.Types;

namespace TriviaQuizGame.Types
{
	[Serializable]
	public class Category:MonoBehaviour
	{
		// Used to hold the state of the category, if it was completed or not. 0 = not completed, 1 = victory. Later I might add other states, maybe to show a star rating.
		internal int categoryState = 0;

		[Tooltip("The name of the category. This is displayed in a categroy wheel or list")]
		public string categoryName;
		
		[Tooltip("The icon associated with this category. This is displayed in a category wheel or list")]
		public Sprite categoryIcon;

		[Tooltip("The color associated with this category. This is displayed in a category wheel or list")]
		public Color categoryColor = Color.red;

		[Tooltip("A list of questions in the category. Each question has a number of correct/wrong answers, a followup text, a bonus value, time, and can also have an image/video as the background of the question")]
		public Question[] questions;
		internal Question[] questionsTemp;

		// Has this category been used already?
		internal bool alreadyUsed = false;

		// The category object that displays info about this category
		internal GameObject categoryObject;

		// The category index referenced when choosing the category from a grid
		internal int categoryIndex;

		// This is used when parsing the Xml info
		internal XmlNodeList xmlRecords;

		// A general use index
		internal int index = 0;
		internal int indexB = 0;

		/// <summary>
		/// Loads an Xml file from a path, then parses it and assigns it to the selected game controller
		/// </summary>
		/// <param name="xmlPath">The path of the Xml file</param>
		public void LoadXml( string xmlPath, bool append )
		{
			// Create a new Xml document
			XmlDocument xmlDocument = new XmlDocument();
			
			// Load the Xml file from the path into the document
			xmlDocument.LoadXml(xmlPath);
			
			// Get the records from the Xml file. Each record contains a question, several answers, and bonus and time info
			xmlRecords = xmlDocument.GetElementsByTagName("record");

			int tempIndex;

			// Set the length of the question list ( in the game controller ) based on the number of questions in the Xml file
			if ( append == true )
			{
				questionsTemp = new Question[questions.Length + xmlRecords.Count];
				tempIndex = questions.Length;
			}
			else
			{
				questionsTemp = new Question[xmlRecords.Count];
				tempIndex = 0;
			}
			
			// Go through all the questions and declare each one, so that we can fill it with info from the Xml
			for ( index = tempIndex; index < questionsTemp.Length ; index++ )    questionsTemp[index] = new Question();
			
			// Set the index of the question, starting from 0, which is the first question
			int questionIndex = 0;
			
			// Go through all the Xml nodes, these are the ones that contain a Question, Image, Answers, Bonus, and Item nodes.
			foreach ( XmlNode XmlRecord in xmlRecords )
			{
				// Get all the questions from the Xml record
				XmlNodeList XmlQuestions = XmlRecord.ChildNodes;
				
				// Go through all the Xml questions and check which part we are accessing ( Question, Image, Answers, Bonus, or Time )
				foreach ( XmlNode XmlQuestion in XmlQuestions )
				{
					// Assign the question to the right slot in the game controller
					if ( XmlQuestion.Name == "Question" )    questionsTemp[questionIndex].question = XmlQuestion.InnerText;
					
					// Assign the followup text of the question to the correct slot in the game controller
					if ( XmlQuestion.Name == "Followup" )    questionsTemp[questionIndex].followup = XmlQuestion.InnerText;
					
					// Assign the image to the right slot in the game controller. All images should be placed in the Resources/Images/ path. You should enter the name of the image without the path and without an extension (ex; .png )
					if ( XmlQuestion.Name == "Image" )    questionsTemp[questionIndex].image = Resources.Load<Sprite>("Images/" + XmlQuestion.InnerText);

					// Assign the sound to the right slot in the game controller. All sounds should be placed in the Resources/Sounds/ path. You should enter the name of the sound without the path and without an extension (ex; .mp3 )
					if ( XmlQuestion.Name == "Sound" )    questionsTemp[questionIndex].sound = Resources.Load<AudioClip>("Sounds/" + XmlQuestion.InnerText);

					if ( XmlQuestion.Name == "Video" )
					{
						#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WP8 && !UNITY_WEBGL
						// Assign the video to the right slot in the game controller. All videos should be placed in the Resources/Videos/ path. You should enter the name of the video without the path and without an extension (ex; .mp4 )
						questionsTemp[questionIndex].video = Resources.Load<MovieTexture>("Videos/" + XmlQuestion.InnerText); 
						#else
						if ( XmlQuestion.InnerText != string.Empty )    Debug.LogWarning("You have imported a question that contains a video while using a mobile platform. Unity does not support videos on mobile platforms. The question is '" + questions[questionIndex].question + "'");
						#endif
					}
					
					// Assign the bonus value to the right slot in the game controller
					if ( XmlQuestion.Name == "Bonus" )    questionsTemp[questionIndex].bonus = int.Parse(XmlQuestion.InnerText);
					
					// Assign the time value to the right slot in the game controller
					if ( XmlQuestion.Name == "Time" )    questionsTemp[questionIndex].time = int.Parse(XmlQuestion.InnerText);
					
					// Set the index of the answer, starting from 0, which is the first answer
					int answerIndex = 0;
					
					// When we detect an "Answers" record, we must go through it to find all the answers
					if ( XmlQuestion.Name == "Answers" )
					{
						// Set the length of the answers list ( in the game controller ) based on the number of answers in the Xml file
						questionsTemp[questionIndex].answers = new Answer[XmlQuestion.ChildNodes.Count];
						
						// Go through all the answers and declare each one, so that we can fill it with info from the Xml
						for ( index = 0 ; index < questionsTemp[questionIndex].answers.Length ; index++ )    questionsTemp[questionIndex].answers[index] = new Answer();
						
						// Go through all the Xml nodes, these are the ones that contain an Answer, Image, and IsCorrect state nodes.
						foreach( XmlNode XmlAnswer in XmlQuestion.ChildNodes )
						{
							// If this is an answer, assign it to the game controller, and also assign the IsCorrect and Image attribute, if it exists
							if ( XmlAnswer.Name == "Answer" )
							{
								// Assign the answer
								questionsTemp[questionIndex].answers[answerIndex].answer = XmlAnswer.InnerText;
								
								// Assign the IsCorrect attribute, true or false
								if ( XmlAnswer.Attributes.GetNamedItem("correct") != null )    questionsTemp[questionIndex].answers[answerIndex].isCorrect = bool.Parse(XmlAnswer.Attributes.GetNamedItem("correct").InnerText);
								
								// Assign the image to the right slot in the answer. All images should be placed in the Resources/Images/ path. You should enter the name of the image without the path and without an extension (ex; .png )
								if ( XmlAnswer.Attributes.GetNamedItem("image") != null )    questionsTemp[questionIndex].answers[answerIndex].image = Resources.Load<Sprite>("Images/" + XmlAnswer.Attributes.GetNamedItem("image").InnerText);

								// Assign the sound to the right slot in the game controller. All sounds should be placed in the Resources/Sounds/ path. You should enter the name of the sound without the path and without an extension (ex; .mp3 )
								if ( XmlAnswer.Attributes.GetNamedItem("Sound") != null )    questionsTemp[questionIndex].answers[answerIndex].sound = Resources.Load<AudioClip>("Sounds/" + XmlAnswer.Attributes.GetNamedItem("Sound").InnerText);
							}
							
							//if ( XmlAnswer.Name == "Image" )    questions[questionIndex].answers[answerIndex].image = Resources.Load<Sprite>("Images/" + XmlQuestion.InnerText);
							
							answerIndex++;
						}
					}
				}
				
				questionIndex++;
				
			}

			// If we are appending questions to an existing quiz...
			if ( append == true )
			{
				//...go through all the questions and copy them over to the temporary merged quiz
				for ( index = 0 ; index < questions.Length ; index++ )
				{
					questionsTemp[index] = questions[index];
				}
			}

			questions = questionsTemp;
		}

		/// <summary>
		/// Writes the quiz content to and saves it as an XML file to a path
		/// </summary>
		/// <param name="xmlPath">The path of the Xml file</param>
		public string SaveXml()
		{
			// Create an empty text object which we will fill with the formatted XML
			string xmlString = "";
			
			// Starting the XML document with the header and data set definitions
			xmlString =  @"<?xml version=""1.0"" encoding=""UTF-8""?>" + "\n";
			xmlString += @"<data-set xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" + "\n";
			
			// Go through all the questions and assign each parts to the correct XML line
			for ( index = 0; index < questions.Length ; index++ )
			{
				// The start of a question
				xmlString += "  <record>" + "\n";
				
				// The question text
				xmlString += "    <Question>" + questions[index].question + "</Question>" + "\n";
				
				// The question image, if it exists
				if ( questions[index].image )    xmlString += "    <Image>" + questions[index].image.name + "</Image>" + "\n";
				
				// The question sound, if it exists
				if ( questions[index].sound )    xmlString += "    <Sound>" + questions[index].sound.name + "</Sound>" + "\n";
				
				#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WP8 && !UNITY_WEBGL
				// The question video, if it exists
				if ( questions[index].video )    xmlString += "    <Video>" + questions[index].video.name + "</Video>" + "\n";
				#endif
				// The start of the list of answers
				xmlString += "    <Answers>" + "\n";
				
				// Go through all the answers and declare each one, so that we can fill it with info from the Xml
				for ( indexB = 0 ; indexB < questions[index].answers.Length ; indexB++ )
				{
					// The first part of the answer element
					xmlString += "      <Answer";
					
					// The answer image, if it exists
					if ( questions[index].answers[indexB].image )    xmlString += " image=" + "\"" + questions[index].answers[indexB].image.name + "\"";
					
					// The answer sound, if it exists
					if ( questions[index].answers[indexB].sound )    xmlString += " sound=" + "\"" + questions[index].answers[indexB].sound.name + "\"";
					
					// Set the answer to be either true or false
					if ( questions[index].answers[indexB].isCorrect == true )    xmlString += @" correct=""true""";
					else    xmlString += @" correct=""false""";
					
					// The end of the answer element
					xmlString += ">" + questions[index].answers[indexB].answer + "</Answer>" + "\n";
				}
				
				// The end of the list of answers
				xmlString += @"    </Answers>" + "\n";

                // The bonus given for this question
                xmlString += @"    <Bonus>" + questions[index].bonus.ToString() + "</Bonus>" + "\n";

                // The time allowed to answer this question
                xmlString += @"    <Time>" + questions[index].time.ToString() + "</Time>" + "\n";

                // The end of a question
                xmlString += @"  </record>" + "\n";
			}
			
			// Ending the XML document
			xmlString += @"</data-set>" + "\n";
			
			return xmlString;
		}
	}
}
