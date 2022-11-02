﻿using UnityEngine;
using UnityEngine.Events;


    public class SceneTransitionDestination : MonoBehaviour
    {
        public enum DestinationTag
        {
            A, B, C, D, E, F, G,
        }

        public GameObject confiner;
        public DestinationTag destinationTag;    // This matches the tag chosen on the TransitionPoint that this is the destination for.
        [Tooltip("This is the gameobject that has transitioned.  For example, the player.")]
        public GameObject transitioningGameObject;
        public UnityEvent OnReachDestination;
    }
