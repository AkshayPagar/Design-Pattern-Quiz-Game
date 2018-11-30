using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreBoardManager : IPlayerResponseObserver
{

  
    private int score;

    private static ScoreBoardManager scoreBoardManager;

    private static object obj = new object();


    private ScoreBoardManager()
    {
    }

    public static ScoreBoardManager GetInstance()
    {
        lock (obj)
        {
            if (scoreBoardManager == null)
            {
                scoreBoardManager = new ScoreBoardManager();
            }
        }

        return scoreBoardManager;
    }



    public void updateStatus()
    {
         this.score += 5; 
    }

    public int getScore()
    {
      return this.score;
}
    public void setScore(int score)
    {
        this.score=score;
    }

}
