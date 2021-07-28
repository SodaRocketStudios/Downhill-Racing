using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathBuilder
{
    public class MeshBuilder : MonoBehaviour
    {
        public Spline spline;
        public float width;

        public Mesh MeshFromSpline(Spline spline, float width)
        {
            Mesh mesh = new Mesh();
            Vector3[] vertices;
            int[] triangles;

            Vector3[] curvePoints = spline.Vertices;
            Vector3[] curveNormals = spline.Normals;

            // Need two vertices for each point in the curve.
            vertices = new Vector3[curvePoints.Length*2];
            triangles = new int[6*(curvePoints.Length-1)];

            // For each point in the curve
            for(int i = 0; i < curvePoints.Length - 1; i++)
            {
                Vector3 right = Vector3.Cross(curveNormals[i], curvePoints[i+1] - curvePoints[i]).normalized;

                vertices[(i*2)]   = curvePoints[i]   + right;
                vertices[(i*2)+1] = curvePoints[i]   - right;
                vertices[(i*2)+2] = curvePoints[i+1] + right;
                vertices[(i*2)+3] = curvePoints[i+1] - right;

                triangles[(i*6)]   = (2*i);
                triangles[(i*6)+1] = (2*i)+1;
                triangles[(i*6)+2] = (2*i)+2;
                triangles[(i*6)+3] = (2*i)+3;
                triangles[(i*6)+4] = (2*i)+2;
                triangles[(i*6)+5] = (2*i)+1;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            MeshFilter filter;
            MeshRenderer renderer;

            if(TryGetComponent<MeshFilter>(out filter))
            {
                filter.sharedMesh = mesh;
            }
            else
            {
                gameObject.AddComponent<MeshFilter>().sharedMesh = mesh;
            }
            if(TryGetComponent<MeshRenderer>(out renderer))
            {
                renderer.sharedMaterial.color = Color.blue;
            }
            else
            {
                renderer = gameObject.AddComponent<MeshRenderer>();
                renderer.sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                renderer.sharedMaterial.color = Color.blue;
            }

            return mesh;
        }
    }
}