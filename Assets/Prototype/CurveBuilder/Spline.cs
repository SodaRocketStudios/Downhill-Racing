using UnityEngine;

namespace CurveBuilder
{
    public class Spline : MonoBehaviour
    {
        [SerializeField,  Min(2), Tooltip("The number of control points that define the shape of the spline")]
        private int numberOfPoints = 4;

        [SerializeField, Min(1)]
        private int resolution = 10;
        
        [SerializeField]
        private CurveType curveType = CurveType.bezier;

        private GameObject[] controlPoints;

        private Curve curve;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {            
            Vector3[] points = InitializeControlPoints();
            curve = new Curve(points, curveType, resolution);
        }

        private Vector3[] InitializeControlPoints()
        {
            Vector3[] points = new Vector3[numberOfPoints];
            for(int i = 0; i < points.Length; i++)
            {
                // Set points equal to the position of the control points.
            }
            return points;
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