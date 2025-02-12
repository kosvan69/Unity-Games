﻿using Characters.Enemies;
using UnityEngine;

namespace Weapons.Guns.Blaster
{
    public class Blaster : EnergyWeapon
    {
        private float _currentShotDuration;
        private float _currentDamage;
        private float _currentRange;

        private RaycastHit _raycastHit;
        private LineRenderer _lineRenderer;

        private const string IndestructibleTerrainTag = "IndestructibleTerrain";
        private const string EnemyTag = "Enemy";

        protected override void Start()
        {
            base.Start();
            _lineRenderer = GetComponent<LineRenderer>();
            InitializeBlasterStats();
        }

        protected override void Update()
        {
            base.Update();
            if (timer >= weaponData.AttackCooldown * _currentShotDuration)
            {
                _lineRenderer.enabled = false;
            }
        }

        private void InitializeBlasterStats()
        {
            var blasterData = weaponData as BlasterData;
            if (blasterData)
            {
                _currentShotDuration = blasterData.ShotDuration;
                _currentDamage = blasterData.Damage;
                _currentRange = blasterData.MaxAttackRange;
            }
        }

        protected override void Shoot()
        {
            timer = 0f;
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, transform.position);
            
            var shootRay = new Ray { origin = transform.position, direction = transform.forward };

            if (Physics.Raycast(shootRay, out _raycastHit, _currentRange))
            {
                if (autoTarget.SpottedEnemy && !_raycastHit.collider.CompareTag(IndestructibleTerrainTag))
                {
                    var enemy = autoTarget.SpottedEnemy.GetComponent<Enemy>();
                    enemy.TakeDamage(_currentDamage);

                    var pointOnEnemyHeight = autoTarget.SpottedEnemy.GetComponent<CapsuleCollider>().height / 2;
                    var targetVector = new Vector3(0f, pointOnEnemyHeight, 0f);
                    _lineRenderer.SetPosition(1, autoTarget.SpottedEnemy.transform.position + targetVector);
                }
                else if (_raycastHit.collider.CompareTag(IndestructibleTerrainTag))
                {
                    _lineRenderer.SetPosition(1, _raycastHit.point);
                }
                else if (_raycastHit.collider.CompareTag(EnemyTag))
                {
                    var enemy = _raycastHit.collider.GetComponent<Enemy>();
                    enemy.TakeDamage(_currentDamage);
                    _lineRenderer.SetPosition(1, _raycastHit.point);
                }
                else
                {
                    _lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * _currentRange);
                }
            }
            PlayWeaponSound();
        }
    }
}