using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField]
    Transform[] _tTargetRoot;

    [SerializeField]
    GameObject[] _goTargetArray;

    List<GameObject> _liTarget = new List<GameObject>();
    GameObject _goTarget;

    public GameObject ResetTarget(int n)
    {
        ClearTargets();
        CreateTargets(n);
        SetTarget();

        return _goTarget;
    }

    public void ClearTargets()
    {
        Array.ForEach(_tTargetRoot, t => ComUtil.DestroyChildren(t));
        _liTarget.Clear();
    }

    void CreateTargets(int n)
    {
        GameObject target = null;

        _goTargetArray = _goTargetArray.OrderBy(x => UnityEngine.Random.value).ToArray();
    
        for (int i = 0; i < n; i++)
        {
            target = Instantiate(_goTargetArray[i]);
            target.transform.SetParent(_tTargetRoot[i]);

            target.transform.localPosition = Vector3.zero;
            target.transform.localRotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 360), 0));

            _liTarget.Add(target);
        }
    }

    void SetTarget()
    {
        _goTarget = _liTarget.OrderBy(x => UnityEngine.Random.value).FirstOrDefault();
    }
}
