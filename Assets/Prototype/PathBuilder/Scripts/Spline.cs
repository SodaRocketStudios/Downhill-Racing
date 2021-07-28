using UnityEngine;

namespace PathBuilder
{
    public class Spline : MonoBehaviour
    {
        [SerializeField, Min(1), Tooltip("The number of segments that the curve will be made of.")]
        private int resolution = 10;
        
        [SerializeField]
        private SplineType splineType = SplineType.bezier;

        [SerializeField]
        private bool closedLoop = false;

        [SerializeField]
        private Vector3[] _controlPoints;
        public Vector3[] ControlPoints
        {
            get{return _controlPoints;}
            set
            {
                _controlPoints = value;
                Initialize();
            }
        }

        [SerializeField]
        private bool drawSpline;

        private SplineData _curve;
        public SplineData Curve
        {
            get{return _curve;}
        }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            if(closedLoop == true)
            {
                Vector3[] loopPoints = new Vector3[_controlPoints.Length+2];
                for(int i = 0; i < _controlPoints.Length; i++)
                {
                    loopPoints[i] = _controlPoints[i];
                }
                loopPoints[loopPoints.Length-1] = loopPoints[0];
                loopPoints[loopPoints.Length-2] = loopPoints[0] + (loopPoints[0]-loopPoints[1]);
                _curve = new SplineData(loopPoints, splineType, resolution);
                return;
            }
            _curve = new SplineData(_controlPoints, splineType, resolution);
        }

        private void OnValidate()
        {
            Initialize();
        }

        private void OnDrawGizmos()
        {
            if(drawSpline)
            {
                _curve.Draw();
            }      
        }
    }
}