using System;
using UnityEngine;

namespace Assets.VirusAttackSource.Utilities {

    [Serializable]
    public sealed class PrefabCountPair {

        [SerializeField] private GameObject _prefab;
        [SerializeField] private int        _count;
    }
}