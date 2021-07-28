using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CurveBuilder
{
    public class MeshBuilder : MonoBehaviour
    {
        public Mesh MeshFromSpline(Spline spline)
        {
            Mesh mesh = new Mesh();

            Vector3[] curvePoints = spline.Curve.Vertices;
            Vector3[] curveNormals = spline.Curve.Normals;

            return mesh;
        }
    }
}