using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using StatueGames;
using Unity.VisualScripting;
using UnityEngine;

namespace KeyboredGames
{
    public enum State
    {
        UI,
        Gameplay,
        Collect
    }

    public class GameManager : MonoBehaviour
    {
        public State state;
        public static GameManager Instance;

        private void Awake()
        {
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
                case State.Collect:
                    CollectState();
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

        public void CollectState()
        {
            //
        }

    }
}