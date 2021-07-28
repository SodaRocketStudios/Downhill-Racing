using UnityEngine;

namespace PathBuilder
{
    public class CurveData
    {
        private CurveGenerator generator;

        private Vector3[] _vertices;
        public Vector3[] Vertices
        {
            get{return _vertices;}
            set
            {
                _vertices = new Vector3[value.Length];
                for(int i = 0; i < value.Length; i++)
                {
                    _vertices[i] = value[i];
                }
            }
        }

        private Vector3[] _normals;
        public Vector3[] Normals
        {
            get{return _normals;}
        }
        private float _normalAngle = 0;


        public CurveData(Vector3[] controlPoints, CurveType curveType, int resolution = 10)
        {
            switch(curveType)
            {
                case CurveType.bezier:
                    generator = new Bezier();
                    break;
                case CurveType.linear:
                    Vertices = controlPoints;
                    return;
                default:
                    Vertices = controlPoints;
                    return;
            }
            Vertices = generator?.GetCurve(controlPoints, resolution);
            CalculateNormals(_normalAngle);
        }

        // Calculates normal vectors for each segment of a curve.
        private void CalculateNormals(float angle)
        {
            _normals = new Vector3[_vertices.Length - 1];

            // For each segment in the curve
            for(int i = 0; i < _normals.Length; i++)
            {
                // Set the normal as the up vector rotated to line up with the segment
                Vector3 line = _vertices[i] - _vertices[i+1];
                Quaternion rotationToLine = Quaternion.Inverse(Quaternion.FromToRotation(line, Vector3.right));
                Vector3 normal = rotationToLine*Vector3.up;
                normal = Quaternion.AngleAxis(angle, line)*normal; // Rotate the normal by the desired amount
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

    public enum CurveType
    {
        bezier,
        linear
    }
}