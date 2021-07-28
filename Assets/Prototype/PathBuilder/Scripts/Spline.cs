using UnityEngine;

namespace PathBuilder
{
    public class Spline : MonoBehaviour
    {
        [SerializeField, Min(1), Tooltip("The number of segments that the curve will be made of.")]
        private int _resolution = 10;
        
        [SerializeField]
        private SplineType _splineType = SplineType.bezier;

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

        private CurveGenerator generator;

        private Vector3[] _vertices;
        public Vector3[] Vertices
        {
            get{return _vertices;}
        }

        private Vector3[] _normals;
        public Vector3[] Normals
        {
            get{return _normals;}
        }
        private float[] _normalAngles;


        public Spline(SplineType splineType, int numberOfControlPoints = 4, int resolution = 100)
        {
            _splineType = splineType;
            _resolution = Mathf.Max(resolution, 1);
            _controlPoints = new Vector3[numberOfControlPoints];

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
                _controlPoints = loopPoints;
            }

            switch(_splineType)
            {
                case SplineType.bezier:
                    generator = new Bezier();
                    break;
                case SplineType.linear:
                    _vertices = _controlPoints;
                    return;
                default:
                    _vertices = _controlPoints;
                    return;
            }

            _resolution = Mathf.Max(_resolution, 1);
            _vertices = generator?.GetCurve(_controlPoints, _resolution);
            _normalAngles = new float[_resolution];

            CalculateNormals();
        }

        private void OnValidate()
        {
            Initialize();
        }

        private void OnDrawGizmos()
        {
            if(drawSpline)
            {
                Draw();
            }      
        }

        // Calculates normal vectors for each segment of a curve.
        private void CalculateNormals()
        {
            _normals = new Vector3[_vertices.Length - 1];

            // For each segment in the curve
            for(int i = 0; i < _normals.Length; i++)
            {
                // Set the normal as the up vector rotated to line up with the segment
                Vector3 line = _vertices[i] - _vertices[i+1];
                Quaternion rotationToLine = Quaternion.Inverse(Quaternion.FromToRotation(line, Vector3.right));
                Vector3 normal = rotationToLine*Vector3.up;
                normal = Quaternion.AngleAxis(_normalAngles[i], line)*normal; // Rotate the normal by the desired amount
                _normals[i] = normal;
            }
        }

        // Draws the curve and normals
        public void Draw()
        {
            for(int i = 0; i < _vertices.Length - 1; i++)
            {
                Gizmos.DrawLine(_vertices[i+1], _vertices[i]);
                Vector3 Midpoint = 0.5f*(_vertices[i] + _vertices[i+1]);
                Gizmos.DrawLine(Midpoint, _normals[i] + Midpoint);
            }
        }
    }

    public enum SplineType
    {
        bezier,
        linear
    }
}