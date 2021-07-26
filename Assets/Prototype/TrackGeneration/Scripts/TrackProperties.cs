using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrackGenerator
{
    [CreateAssetMenu(fileName = "New Track Properties", menuName = "Track Generation/Track Properties")]
    public class TrackProperties : ScriptableObject
    {
        [SerializeField, Tooltip("The length of the track.")]
        private TrackLength _length;
        public TrackLength Length
        {
            get{return _length;}
            set{_length = value;}
        }

        [SerializeField, Tooltip("The average downward slope of the track in degrees.\n\nHigher values will result in faster acceleration through the track.")]
        private float _slope = 0.5f;
        public float Slope
        {
            get{return _slope;}
            set{_slope = value;}
        }

        [SerializeField, Tooltip("The friction of the track when no modifiers are applied.")]
        private float _baseFriction = 1;
        public float BaseFriction
        {
            get{return _baseFriction;}
            set{_baseFriction = value;}
        }

        [SerializeField, Tooltip("The type of surface that the track will have.")]
        private TrackTexture _surfaceTexture;
        public TrackTexture surfaceTexture
        {
            get{return _surfaceTexture;}
            set{_surfaceTexture = value;}
        }

        [SerializeField, Tooltip("How frequently there will be turns in the track.")]
        private TurnFrequency _turnAmount;
        public TurnFrequency TurnAmount
        {
            get{return _turnAmount;}
            set{_turnAmount = TurnAmount;}
        }

        [SerializeField, Tooltip("The type of turns in the track.")]
        private TurnType _typeOfTurns;
        public TurnType TypeOfTurns
        {
            get{return _typeOfTurns;}
            set{_typeOfTurns = value;}
        }
    }

    #region property enums
    public enum TrackLength
    {
        Short,
        Medium,
        Long,
        ExtraLong,
        Extreme
    }

    public enum TurnFrequency
    {
        None,
        VeryRare,
        Rare,
        Frequent,
        VeryFrequent,
        Yes
        
    }

    public enum TurnType
    {
        Smooth,
        Sharp
    }

    public enum TrackTexture
    {
        Smooth, // Flat/No variation
        Wavy,   // Large hill like variations
        Rough,  // Small and very frequent variations
        Bumpy   // Medium and fairly frequent variations
    }
    #endregion
}