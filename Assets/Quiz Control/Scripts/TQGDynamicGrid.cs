//Version 1.65 (10.08.2016)

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TriviaQuizGame
{
	// PlayerScript requires the GameObject to have a Rigidbody component
	[RequireComponent (typeof (GridLayoutGroup))]

	/// <summary>
	/// Automatically fits a grid layout group into the screen based on the aspect ratio. This is good when you
	/// want to be able to use the grid in both the landscape and the portrait orientation on mobile devices.
	/// </summary>
	[ExecuteInEditMode]
	public class TQGDynamicGrid:MonoBehaviour
	{
		[Header("Horizontal Orientation Settings")]
		[Tooltip("The size of a cell in a grid layout when the game is oriented horizontally ( landscape )")]
		public Vector2 horizontalCellSize = new Vector2(260,120);

		[Tooltip("The number of columns or rows used in the grid when the game is oriented horizontally ( landscape )")]
		public int horizontalGridSize = 3;

		[Header("Vertical Orientation Settings")]
		[Tooltip("The size of a cell in a grid layout when the game is oriented vertically ( portrait )")]
		public Vector2 verticalCellSize = new Vector2(180,80);

		[Tooltip("The number of columns or rows used in the grid when the game is oriented horizontally ( landscape )")]
		public int verticalGridSize = 1;

		// The current aspect ratio. When this changes we check if the grid cell size needs to be changed accordingly
		internal float currentAspectRatio = 0;

		void Awake()
		{
			UpdateGrid();
		}

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// Awake is used to initialize any variables or game state before the game starts. Awake is called only once during the 
		/// lifetime of the script instance. Awake is called after all objects are initialized so you can safely speak to other 
		/// objects or query them using eg. GameObject.FindWithTag. Each GameObject's Awake is called in a random order between objects. 
		/// Because of this, you should use Awake to set up references between scripts, and use Start to pass any information back and forth. 
		/// Awake is always called before any Start functions. This allows you to order initialization of scripts. Awake can not act as a coroutine.
		/// </summary>
		void Update()
		{
			UpdateGrid();
		}

		public void UpdateGrid()
		{
			// If the aspect ratio changed, check if the grid cell size needs to be changed accordingly
			//if ( Screen.width/Screen.height != currentAspectRatio )
			//{
			// Check if the screen aspect ratio is vertical or horizontal, and set the grid cell size accordingly
			if (Screen.width / Screen.height >= 1) 
			{
				GetComponent<GridLayoutGroup>().cellSize = horizontalCellSize;
				
				GetComponent<GridLayoutGroup>().constraintCount = horizontalGridSize;
			} 
			else 
			{
				GetComponent<GridLayoutGroup>().cellSize = verticalCellSize;
				
				GetComponent<GridLayoutGroup>().constraintCount = verticalGridSize;
			}
			
			// Update the current aspect ratio
			currentAspectRatio = Screen.width/Screen.height;
			//}
		}
	}
}