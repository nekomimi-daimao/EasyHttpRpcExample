using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Nekomimi.Daimao.Example
{
    public class DebuggerPrimitiveSupplier : MonoBehaviour
    {
        private EasyHttpRPC _easyHttpRPC;

        [SerializeField]
        private string _address;

        [SerializeField]
        private bool _isListening;

        [SerializeField]
        private PrimitiveSupplier _primitiveSupplier = default;

        private void Start()
        {
            _easyHttpRPC = new EasyHttpRPC(this.GetCancellationTokenOnDestroy());
            _address = _easyHttpRPC.Address;
            _isListening = _easyHttpRPC.IsListening;

            _easyHttpRPC.RegisterRPC(nameof(Instantiate), Instantiate);
            _easyHttpRPC.RegisterRPC(nameof(Count), Count);
            _easyHttpRPC.RegisterRPC(nameof(Error), Error);
            _easyHttpRPC.RegisterRPC(nameof(Post), Post);
        }

        private void OnDestroy()
        {
            _easyHttpRPC?.Close();
        }

        private readonly Rect _rect = new Rect(20, 20, Screen.width, Screen.height);

        private void OnGUI()
        {
            GUI.skin.label.fontSize = 20;
            GUI.Label(_rect, _easyHttpRPC?.Address);
        }

        private async Task<string> Instantiate(NameValueCollection arg)
        {
            await UniTask.SwitchToMainThread();

            var argColor = arg["color"];
            if (string.IsNullOrEmpty(argColor) || !ColorUtility.TryParseHtmlString(argColor, out var color))
            {
                color = Color.white;
            }

            var argCount = arg["count"];
            if (!int.TryParse(argCount, out var count))
            {
                count = 0;
            }

            await _primitiveSupplier.Instantiate(color, count);
            return "SUCCESS";
        }

        private Task<string> Count(NameValueCollection arg)
        {
            return Task.FromResult(_primitiveSupplier.Count.ToString());
        }

        private Task<string> Error(NameValueCollection arg)
        {
            throw new ArgumentException("always throw");
        }

        private Task<string> Post(NameValueCollection arg)
        {
            var post = arg[EasyHttpRPC.PostKey];
            return Task.FromResult(new string(post?.Reverse().ToArray()));
        }
    }
}
