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

        private Curve curve;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            if(closedLoop == true)
            {
                Vector3[] loopPoints = new Vector3[controlPoints.Length+1];
                for(int i = 0; i < loopPoints.Length - 1; i++)
                {
                    loopPoints[i] = controlPoints[i];
                }
                loopPoints[loopPoints.Length-1] = loopPoints[0];
                curve = new Curve(loopPoints, curveType, resolution);
                return;
            }
            curve = new Curve(controlPoints, curveType, resolution);
        }

        private void OnValidate()
        {
            Initialize();
        }

        private void OnDrawGizmos()
        {
            curve.Draw();   
        }
    }
}