//Version 1.58 (17.07.2016)

using System;
using UnityEngine;
using System.Xml;
using TriviaQuizGame.Types;

namespace TriviaQuizGame.Types
{
	/// <summary>
	/// This script defines a level in the game. When the player reaches a certain score, the level is increased and the difficulty is changed accordingly
	/// This class is used in the Game Controller script
	/// </summary>
	[Serializable]
	public class Unlockable
	{
		[Tooltip("The category that can be unlocked")]
		public Category category;

		// The lock state of the category. A locked category cannot be chosen and played
		internal bool isLocked = false;


	}
}
