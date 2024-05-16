using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    string _sName;

    [SerializeField]
    int _nPoint;

    Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        SetDance();
    }

    public void SetDance()
    {
        _animator.SetFloat("DanceType", Random.Range(0, 7));
    }

    public int GetPoint()
    {
        return _nPoint;
    }

    public string GetName()
    {
        return _sName;
    }
}
