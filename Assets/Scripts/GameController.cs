using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	public Vector3 spawnValues;

	public int hazardCount = 10;
	public float spawnWait = .5f; 
	public float waveWait = 4f;
	public float startWait = 1f;
	
	public GUIText scoreText;
	private int score;

	public GUIText restartText;
	public GUIText gameOverText;

	private bool restart = false;
	private bool gameOver = false;

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	void Start()
	{
		score = 0;
		UpdateScore ();

		StartCoroutine (SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i=0; i<hazardCount; i++)
			{
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver)
			{
				restartText.text = "请输入R键重新开始";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void Update()
	{
		if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
