using UnityEngine;

namespace CurveBuilder
{
    public class Spline : MonoBehaviour
    {
        [SerializeField,  Min(2), Tooltip("The number of points in the spline")]
        private int numberOfPoints = 4;
        
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
            Vector3[] points = GetControlPoints();
            curve = new Curve(points, curveType);
        }

        private Vector3[] GetControlPoints()
        {
            Vector3[] points = new Vector3[numberOfPoints];
            for(int i = 0; i < points.Length; i++)
            {
                points[i].x = i;
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