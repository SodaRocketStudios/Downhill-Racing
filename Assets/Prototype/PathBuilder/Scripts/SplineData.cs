using UnityEngine;

namespace PathBuilder
{
    public class SplineData
    {
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

        private int _resolution = 10;


        public SplineData(Vector3[] controlPoints, SplineType splineType, int resolution = 10)
        {
            switch(splineType)
            {
                case SplineType.bezier:
                    generator = new Bezier();
                    break;
                case SplineType.linear:
                    _vertices = controlPoints;
                    return;
                default:
                    _vertices = controlPoints;
                    return;
            }

            _resolution = Mathf.Max(resolution, 1);
            _vertices = generator?.GetCurve(controlPoints, _resolution);
            _normalAngles = new float[_resolution];

            CalculateNormals();
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