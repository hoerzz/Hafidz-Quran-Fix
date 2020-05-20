//Version 1.65 (10.08.2016)

using System;
using UnityEngine;
using System.Collections;
using TriviaQuizGame.Types;

namespace TriviaQuizGame
{
	[Serializable]
	public class CategoryMath:MonoBehaviour
	{
		[Tooltip("The name of the category. This is displayed in a categroy wheel or list")]
		public string categoryName;
		
		[Tooltip("The icon associated with this category. This is displayed in a category wheel or list")]
		public Sprite categoryIcon;

		[Tooltip("The color associated with this category. This is displayed in a category wheel or list")]
		public Color categoryColor = Color.red;

		[Tooltip("How many levels will be created, each level has several questions with attributes such as Numbers Range, types of Operations, number of Operations, the bonus we get in the level, etc")]
		[Range(1,20)]
		public int totalLevels = 10;

		[Tooltip("How many questions from each level should be created? ( Each level has attributes like numbers range, types of operations, number of operations, the bonus we get in the level, etc)")]
		[Range(1,20)]
		public int questionsPerLevel = 10;

		[Tooltip("How many answers should each question have? The number of answers cannot be more than the number of answer objects defined in the gamecontroller")]
		public int answersPerQuestion = 4;

		[Header("Initial values for the first level")]
		[Tooltip("The range of numbers that will be used in the math questions, between 1 and the value of 'Numbers Range'")]
		public int numbersRange = 9;
		internal int currentNumbersRange;

		[Tooltip("How ")]
		public int bonusPerQuestion = 100;

		[Tooltip("How many seconds are given to answer a question. If there is a Global Time set, it will override this value")]
		public int timePerQuestion = 5;

		[Header("Values that increase in each level")]
		[Tooltip("How much the numbers range increases in each level")]
		public int numbersRangeIncrease = 10;

		[Tooltip("How much the bonus for a question increases in each level")]
		public int bonusIncrease = 100;

		[Tooltip("How much the time given to answer a question increases in each level")]
		public int timeIncrease = 2;

		[Header("Use these operations starting at level")]
		[Tooltip("At which level should we start using addition operations")]
		public int useAdditionAtLevel = 1;

		[Tooltip("At which level should we start using subtraction operations")]
		public int useSubtractionAtLevel = 10;

		[Tooltip("At which level should we start using multiplication operations")]
		public int useMultiplicationAtLevel = 20;

		[Tooltip("At which level should we start using division operations")]
		public int useDivisionAtLevel = 30;

// THESE WILL BE USED IN A FUTURE UPDATE
		//[Header("Which parts of the equation can be missing")]
		//[Tooltip("Should questions possibly have a missing answer?")]
		//public bool missingResult = true;

		//[Tooltip("Should questions possibly have a missing operation?")]
		//public bool missingOperation = false;

		//[Tooltip("Should questions possibly have a missing operand? ")]
		//public bool missingOperand = false;

		//[Header("Every how many levels should we increase the number of operations?")]
		//[Tooltip("After how many levels should we increase the number of operations by one? We start with one operation (ex: 2 + 3), and then after a certain level increase it to two operations (ex: 2 + 3 - 1), and so on every set number of levels")]
		//public int addOperationAtLevel = 40;

		// The number of operations in this question
		internal float operationsCount = 1;

		// A list of possible operations in this question. The operation is chosen randomly based on the available ones.
		internal string possibleOperations = "";

		// A button to preview the list of questions that will be created based on the attributes we set
		public bool createQuestions = false;

		[Tooltip("A list of questions in the math category. This is the same question used for trivia questions, but in the context of math each question has one correct answer and several wrong ones")]
		public Question[] questions;

		// Has this category been used already?
		internal bool alreadyUsed = false;

		// The category object that displays info about this category
		internal GameObject categoryObject;

		// The category index referenced when choosing the category from a grid
		internal int categoryIndex;

		// A general use index
		internal int index;
		internal int indexB;

		// Used to check if we made changes to the component
		internal bool quizChanged = false;

		// Temporary variables used to hold the numbers, operation, and result for this question
		internal float firstNumber;
		internal float secondNumber;
		internal string operation;
		internal float result;
		
		void OnValidate()
		{
			// Limit the levels we can target between 1 and the maximum number of questions in the game
			useAdditionAtLevel = Mathf.Clamp(useAdditionAtLevel, 1, totalLevels * questionsPerLevel);
			useSubtractionAtLevel = Mathf.Clamp(useSubtractionAtLevel, 1, totalLevels * questionsPerLevel);
			useMultiplicationAtLevel = Mathf.Clamp(useMultiplicationAtLevel, 1, totalLevels * questionsPerLevel);
			useDivisionAtLevel = Mathf.Clamp(useDivisionAtLevel, 1, totalLevels * questionsPerLevel);

			// If we have no missing type assigned, set the missingResult as the default type in questions
			//if ( missingResult == false && missingOperation == false && missingOperand == false ) missingResult = true;

			// The attributes were changed since the last time we created the questions
			quizChanged = true;

			// Create the list of questions based on the attributes we entered
			if ( createQuestions == true )
			{
				CreateQuestions();

				// Reset the button so we can click on it again
				createQuestions = false;

				// The question list fits the attributes we set
				quizChanged = false;
			}
		}

		void Awake()
		{
			// If we changed the math quiz attributes without updating the questions ( didn't press CreateQuestion() button ), then the question will be recreated to make sure they fit the new attributes
			if ( quizChanged == true )
			{
				CreateQuestions();

				// The question list fits the attributes we set
				quizChanged = false;
			}
		}

		/// <summary>
		/// Creates the questions in the attached quiz gamecontroller based on the attributes set in the math category
		/// </summary>
		public void CreateQuestions()
		{
			// Create a list of questions based on the total number of questions in the math quiz
			questions = new Question[totalLevels * questionsPerLevel];

			// Go through the list of questions we created and fill them up
			for ( index = 0; index < questions.Length ; index++ )
			{
				// Declare the new question, so that we can fill it with info
				questions[index] = new Question();

				// Set the missing type which will have to answer
				//if ( missingOperation == true )

				// Holds the list of possible operations in this question
				possibleOperations = "";

				// Set the list of operations based on the level we reached
				if ( index >= useAdditionAtLevel - 1 ) possibleOperations += "+";
				if ( index >= useSubtractionAtLevel - 1 ) possibleOperations += "-";
				if ( index >= useMultiplicationAtLevel - 1 ) possibleOperations += "×";
				if ( index >= useDivisionAtLevel - 1 ) possibleOperations += "÷";

				// Set the number of operations in the question based on the level we reached ( For now we are keeping this value at 1)
				operationsCount = 1;// + Mathf.FloorToInt(index/addOperationAtLevel);

				// Set the range of numbers used in the question based on the level we reached
				currentNumbersRange = numbersRange + Mathf.FloorToInt(index/questionsPerLevel) * numbersRangeIncrease;

				// Choose the first number in the question
				firstNumber = UnityEngine.Random.Range(1,currentNumbersRange);

				// Enter the rest of the operations and numbers, based on the number of operations in this question
				while ( operationsCount > 0 )
				{
					// Choose one of the operations randomly
					operation = possibleOperations[Mathf.FloorToInt(UnityEngine.Random.value * possibleOperations.Length)].ToString();

					// Choose another number in the question
					secondNumber = UnityEngine.Random.Range(1,currentNumbersRange);

					operationsCount--;
				}

				// Calculate the question result based on the operation we are using
				if ( operation == "+" ) result = firstNumber + secondNumber;
				else if ( operation == "-" ) result = firstNumber - secondNumber;
				else if ( operation == "×" ) result = firstNumber * secondNumber;
				else if ( operation == "÷" ) result = Mathf.Round((firstNumber / secondNumber) * 100f) / 100f;

				// Create a list of answers based on the number of answers per question
				questions[index].answers = new Answer[answersPerQuestion];

				// Go through the list of answers we created and fill them up
				for ( indexB = 0; indexB < questions[index].answers.Length ; indexB++ )
				{
					// Declare the new answer, so that we can fill it with info
					questions[index].answers[indexB] = new Answer();

					// If this is the first answer, it is correct
					if ( indexB == 0 )
					{
						// Set the answer value
						questions[index].answers[indexB].answer = result.ToString();

						// This answer is correct
						questions[index].answers[indexB].isCorrect = true;
					}
					else // Otherwise, set the other (incorrect) answers with varying results
					{
						// Either set the result higher or lower than the correct one
						if ( UnityEngine.Random.value > 0.5f ) questions[index].answers[indexB].answer = (result + (indexB * indexB)).ToString();
						else questions[index].answers[indexB].answer = (result - (indexB * indexB)).ToString();
					}
				}

				// Show the full question, with numbers, operation, and result
				questions[index].question = firstNumber.ToString() + " " + operation + " " + secondNumber.ToString();

				// Fill out the bonus based on the level we are in
				questions[index].bonus = bonusPerQuestion + Mathf.FloorToInt(index/questionsPerLevel) * bonusIncrease;

				// Fill out the time based on the level we are in
				questions[index].time = timePerQuestion + Mathf.FloorToInt(index/questionsPerLevel) * timeIncrease;
			}
		}
	}
}
