using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
	public GameObject canvasMainMenu;
	public GameObject canvasNewGame;
	public GameObject canvasLoadGame;

	public InputField textKnight;
	public InputField textRogue;
	public InputField textWizard;

	public InputField ageKnight;
	public InputField ageRogue;
	public InputField ageWizard;

	public GameObject buttonHolder;
	public GameObject buttonPrefab;

	void Awake() { ShowMainMenu(); }

	public void ShowMainMenu()
	{
		canvasMainMenu.SetActive(true);
		canvasLoadGame.SetActive(false);
		canvasNewGame.SetActive(false);
	}

	public void ShowLoadGame()
	{
		canvasMainMenu.SetActive(false);
		canvasLoadGame.SetActive(true);
		canvasNewGame.SetActive(false);
		GenerateButtonsForGame();
	}

	public void ShowNewGame()
	{
		/*Debug.Log(GameData.current.knight.age.ToString());
		Debug.Log(GameData.current.rogue.age.ToString());
		Debug.Log(GameData.current.wizard.age.ToString());*/
		canvasMainMenu.SetActive(false);
		canvasLoadGame.SetActive(false);
		canvasNewGame.SetActive(true);
		GameData.current = new GameData();
		textKnight.text = GameData.current.knight.name;
		textRogue.text = GameData.current.rogue.name;
		textWizard.text = GameData.current.wizard.name;
        /*ageKnight.text = GameData.current.knight.age.ToString();
        ageRogue.text = GameData.current.rogue.age.ToString();
        ageWizard.text = GameData.current.wizard.age.ToString();*/
    }

	public void QuitGame() { Application.Quit(); }

	public void SaveAndStartGame()
	{
		int knightAge = int.Parse(ageKnight.text.ToString());
		int rogueAge = int.Parse(ageRogue.text.ToString());
		int wizardAge = int.Parse(ageWizard.text.ToString());
		GameData.current.knight.name = textKnight.text;
		GameData.current.rogue.name = textRogue.text;
		GameData.current.wizard.name = textWizard.text;
		GameData.current.knight.age = knightAge;
		GameData.current.rogue.age = rogueAge;
		GameData.current.wizard.age = wizardAge;
		Saver.Save();
		SceneManager.LoadScene(1);
	}

	public void GenerateButtonsForGame()
	{
		Saver.Load();
		// Clear old buttons (for simplicity, I tagged the Button prefab!)
		foreach (GameObject oldButtons in GameObject.FindGameObjectsWithTag("LoadGameButton"))
		{
			Destroy(oldButtons);
		}
		// Generate new buttons
		foreach (GameData game in Saver.savedGames)
		{
			Debug.Log("Should add button: " + game.knight.name + " - " + game.rogue.name + " - " + game.wizard.name);
			// To create buttons, it is Unity's best practice to create a prefab of your button
			GameObject gameButtonObject = Instantiate(buttonPrefab, canvasLoadGame.transform);
			if (gameButtonObject)
			{
				// Change the text of the "Button"
				gameButtonObject.GetComponentInChildren<Text>().text = game.knight.name + "  " + game.knight.age + " - " + game.rogue.name + "  " + game.rogue.age + " - " + game.wizard.name + "  " + game.wizard.age;
				// Change the Click listener, using a delegate
				gameButtonObject.GetComponentInChildren<Button>().onClick.AddListener(delegate { GameLoadClicked(game); });
			}
		}
	}

	private void GameLoadClicked(GameData game)
	{
		GameData.current = game;
		SceneManager.LoadScene(1);
	}
}
