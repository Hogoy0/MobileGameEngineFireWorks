using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	int _nTime;
	int _nTargetCount;
	
	public struct st_History
    {
		public string sName;
		public int nEventTime;
		public int nPoint;
    }

	PageBattle _pageBattle;
	GameObject _goTarget;

	st_History _stHistory;
	List<st_History> _liHistory = new List<st_History>();

	public TargetController _targetController;

	int _nTotalScore = 0;

	private static GameManager Singleton;

	private GameManager() { }

    private void Awake()
    {
		if (Singleton == null)
		{
			Singleton = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

    public static GameManager GetInstance
	{
		get
		{
			if (Singleton == null)
			{
				Singleton = FindObjectOfType<GameManager>();

				if (Singleton == null)
				{
					GameObject singletonObject = new GameObject("GameManager");
					Singleton = singletonObject.AddComponent<GameManager>();
					DontDestroyOnLoad(singletonObject);
				}
			}

			return Singleton;
		}
	}

	public void Initialize()
	{
		_nTime = 60;
		_nTargetCount = 4;
		_nTotalScore = 0;

		_pageBattle = FindObjectOfType<PageBattle>();
		_targetController = FindObjectOfType<TargetController>();
	}

	public int GetPlayTime()
    {
		return _nTime;
    }

	public void SetTarget()
    {
		_goTarget = _targetController.ResetTarget(_nTargetCount);
		_pageBattle.SetRenderTexture(true);
		_pageBattle.SetModelCamera();
	}

	void ClearTarget()
    {
		_targetController.ClearTargets();
	}

	public int GetTotalScore()
    {
		return _nTotalScore;
    }

	public void AddScore(int score = 0)
	{
		_nTotalScore += score;

		if ( score > 0 )
        {
			_stHistory.sName = GetTarget().GetComponent<NPCController>()?.GetName();
			_stHistory.nEventTime = _pageBattle.GetElapedTime();
			_stHistory.nPoint = score;
			_liHistory.Add(_stHistory);
		}

		_pageBattle.AddScore(_nTotalScore);
		_pageBattle.SetRenderTexture(false);

		ClearTarget();

		StartCoroutine(_pageBattle.StartCounter(5, SetTarget));
    }

	public GameObject GetTarget()
    {
		return _goTarget;
    }

	public int GetTargetCount()
    {
		return _nTargetCount;
    }

	public List<st_History> GetHistory()
    {
		return _liHistory;
    }
}
