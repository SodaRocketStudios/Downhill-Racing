using UnityEngine;

namespace CurveBuilder
{
    public class Curve
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
        private float _normalAngle = 0;

        public Curve(Vector3[] controlPoints, CurveType curveType, int resolution = 10)
        {
            switch(curveType)
            {
                case CurveType.bezier:
                    generator = new Bezier();
                    break;
                case CurveType.linear:
                    SetVertices(controlPoints);
                    return;
                default:
                    SetVertices(controlPoints);
                    return;
            }
            SetVertices(generator?.GetCurve(controlPoints, resolution));
        }

        public void SetVertices(Vector3[] vertices)
        {
            _vertices = new Vector3[vertices.Length];
            for(int i = 0; i < vertices.Length; i++)
            {
                _vertices[i] = vertices[i];
            }

            CalculateNormals(_normalAngle);
        }

        private void CalculateNormals(float angle)
        {
            _normals = new Vector3[_vertices.Length - 1];

            for(int i = 0; i < _normals.Length; i++)
            {
                Vector3 line = _vertices[i] - _vertices[i+1];
                Quaternion rotationToLine = Quaternion.Inverse(Quaternion.FromToRotation(line, Vector3.right));
                Vector3 normal = rotationToLine*Vector3.up;
                normal = Quaternion.AngleAxis(angle, line)*normal;
                _normals[i] = normal;
            }
        }

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