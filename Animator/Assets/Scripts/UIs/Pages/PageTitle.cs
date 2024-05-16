using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public partial class PageTitle : MonoBehaviour
{
	GameManager _gameManager = null;

	void Awake()
	{
		if ( null == _gameManager ) _gameManager = GameManager.GetInstance;
	}

	public void OnClick()
    {
		SceneManager.LoadScene(ESceneType.Animator.ToString());
	}
}
