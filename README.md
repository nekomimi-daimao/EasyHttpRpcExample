# EasyHttpRpcExample

example of [EasyHttpRpc](https://gist.github.com/nekomimi-daimao/e5726cde473de30a12273cd827779704)

## How to use (en)

1. Install the VSCode plugin [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client).
1. Clone this repository.
1. Open and run [Assets/Scenes/EasyHttpRPCExample.unity](/Assets/Scenes/EasyHttpRPCExample.unity).
1. Open [http/rest.http](/http/rest.http) in VSCode.
1. Enter the address displayed on the screen into [rest.http](/http/rest.http).
1. Run API.

## How to use (ja)

1. VSCodeのプラグイン [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) をインストールします。
1. このリポジトリをクローンします。
1. [Assets/Scenes/EasyHttpRPCExample.unity](/Assets/Scenes/EasyHttpRPCExample.unity)を開いて実行します。
1. [http/rest.http](/http/rest.http)をVSCodeで開きます。
1. 画面に表示されたアドレスを[rest.http](/http/rest.http)に入力します。
1. APIを実行します。

## API

- instantiate  
  Instantiate cube. count, color.
- count  
  Count instantiated cube.
- error  
  throw error
- post  
  post string
