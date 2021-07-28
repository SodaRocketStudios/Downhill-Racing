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

            Vector3[] curvePoints = spline.CurveData.Vertices;
            Vector3[] curveNormals = spline.CurveData.Normals;

            return mesh;
        }
    }
}