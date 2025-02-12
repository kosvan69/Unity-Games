﻿using UnityEngine;

namespace Weapons
{
    public abstract class WeaponData : ScriptableObject
    {
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private float _attackCooldown = 0.5f;
        [SerializeField] private float _maxAttackRange = 2f;
        [SerializeField] private Transform _gripTransform;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Sprite _weaponSprite;

        public GameObject WeaponPrefab => _weaponPrefab;
        public float AttackCooldown => _attackCooldown;
        public float MaxAttackRange => _maxAttackRange;
        public Transform GripTransform => _gripTransform;
        public AudioClip AudioClip => _audioClip;
        public Sprite WeaponSprite => _weaponSprite;
    }
}