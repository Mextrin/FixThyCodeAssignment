using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        //TODO ScoreManager
        //Update time before optimizing: 0.02ms
        //Optimizations:
        // - Getting Text components now happens on Awake instead of Update
        // - Setting the scoreText.text happens whenevre score gets a new, different value
        //      - score is now a Property and spelled in Pascal Case to follow a code standard.
        //Update time after optimizing: 0.00ms because system is now event based meaning it will no long update every frame.

        static ScoreManager instance;

        Text scoreText;
        static int score;


        public static int Score
        {
            get => score;
            set
            {
                if (value != score)
                {
                    score = value;
                    instance.scoreText.text = "Score: " + score;
                }
            }
        }


        void Awake ()
        {
            // Reset the score.
            scoreText = GetComponent<Text>();
            Score = 0;

            if (!instance)
                instance = this;
        }
    }
}