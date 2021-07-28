using UnityEngine;

namespace CurveBuilder
{
    public class Spline : MonoBehaviour
    {
        // [SerializeField,  Min(2), Tooltip("The number of control points that define the shape of the spline")]
        // private int numberOfPoints = 4;

        [SerializeField, Min(1)]
        private int resolution = 10;
        
        [SerializeField]
        private CurveType curveType = CurveType.bezier;

        [SerializeField]
        private bool closedLoop = false;

        public Vector3[] controlPoints;

        private Curve _curveData;
        public Curve CurveData
        {
            get{return _curveData;}
        }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            if(closedLoop == true)
            {
                Vector3[] loopPoints = new Vector3[controlPoints.Length+2];
                for(int i = 0; i < controlPoints.Length; i++)
                {
                    loopPoints[i] = controlPoints[i];
                }
                loopPoints[loopPoints.Length-1] = loopPoints[0];
                loopPoints[loopPoints.Length-2] = loopPoints[0] + (loopPoints[0]-loopPoints[1]);
                _curveData = new Curve(loopPoints, curveType, resolution);
                return;
            }
            _curveData = new Curve(controlPoints, curveType, resolution);
        }

        private void OnValidate()
        {
            Initialize();
        }

        private void OnDrawGizmos()
        {
            _curveData.Draw();   
        }
    }
}