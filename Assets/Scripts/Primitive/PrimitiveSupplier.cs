using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Nekomimi.Daimao.Example
{
    public class PrimitiveSupplier : MonoBehaviour
    {
        private List<GameObject> _objects = new List<GameObject>();
        private readonly Dictionary<Color, Material> _colors = new Dictionary<Color, Material>();

        public int Count => _objects.Count;

        public async UniTask Instantiate(Color color, int count)
        {
            if (!_colors.ContainsKey(color))
            {
                var newMaterial = new Material(Shader.Find("Standard"));
                newMaterial.color = color;
                _colors[color] = newMaterial;
            }
            var material = _colors[color];

            var parentTs = this.transform;
            for (var i = 0; i < count; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.SetParent(parentTs);
                var rigid = go.AddComponent<Rigidbody>();
                rigid.position = Vector3.up * 4f;
                go.GetComponent<Renderer>().sharedMaterial = material;
                _objects.Add(go);
                await UniTask.Delay(TimeSpan.FromSeconds(0.2d));
            }
        }

        private void OnDestroy()
        {
            foreach (var material in _colors.Values)
            {
                if (material != null)
                {
                    Destroy(material);
                }
            }
        }
    }
}
