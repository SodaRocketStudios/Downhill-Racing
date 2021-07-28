using UnityEngine;

namespace CurveBuilder
{
    public class Spline : MonoBehaviour
    {
        [SerializeField, Min(1), Tooltip("The number of segments that the curve will be made of.")]
        private int resolution = 10;
        
        [SerializeField]
        private CurveType curveType = CurveType.bezier;

        [SerializeField]
        private bool closedLoop = false;

        [SerializeField]
        private Vector3[] _controlPoints;
        public Vector3[] ControlPoints
        {
            get{return _controlPoints;}
        }

        private CurveData _curve;
        public CurveData Curve
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
                _curve = new CurveData(loopPoints, curveType, resolution);
                return;
            }
            _curve = new CurveData(_controlPoints, curveType, resolution);
        }

        private void OnValidate()
        {
            Initialize();
        }

        private void OnDrawGizmos()
        {
            _curve.Draw();   
        }
    }
}