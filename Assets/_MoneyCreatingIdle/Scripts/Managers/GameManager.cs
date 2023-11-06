using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using StatueGames;
using Tabtale.TTPlugins;
using UnityEngine;
using Unity.VisualScripting;

namespace KeyboredGames
{
    public enum State
    {
        UI,
        Gameplay
    }

    public class GameManager : MonoBehaviour
    {
        public State state;

        public static GameManager Instance;

        private void Awake()
        {
            // Initialize CLIK Plugin
            TTPCore.Setup();
            // Your code here
            Instance = this;
        }

        private void Start()
        {
            state = State.Gameplay;
            EventManager.Instance.levelStart += StateSelector;
        }

        public void StateSelector()
        {
            switch (state)
            {
                case State.UI:
                    UIState();
                    break;
                case State.Gameplay:
                    GameplayState();
                    break;
            }
        }

        public void UIState()
        {
            //
        }

        public void GameplayState()
        {
            //
        }
    }
}
