﻿using Characters;
using Characters.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;

        void Start ()
        {
            _player = FindObjectOfType<Player>();
        }
	
        void Update ()
        {
            if (CheckIfPlayerIsDead())
            {
                ResetGame();
            }
        }

        private bool CheckIfPlayerIsDead()
        {
            var playerHealth = _player.GetComponent<Health>();
            return playerHealth.CheckIfDead();
        }

        private void ResetGame()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
