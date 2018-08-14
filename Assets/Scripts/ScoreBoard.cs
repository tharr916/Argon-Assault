using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{

    private int _score;
    private Text _scoreText;

	// Use this for initialization
	void Start ()
	{
	    _scoreText = GetComponent<Text>();
	    _scoreText.text = _score.ToString();
	}

    public void ScoreHit(int pointsPerEnemy)
    {
        _score = _score += pointsPerEnemy;
        _scoreText.text = _score.ToString();

    }

}
