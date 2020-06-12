using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
    public int totalLevel = 0;

    public int unlockedLevel = 1;

    private LevelButtom[] levelButtons;

    private int totalPage = 0;

    private int page = 0;

    private int pageItem = 0;

    void OnEnable()
    {
        levelButtons = GetComponentsInChildren<LevelButtom>();
    }


}
