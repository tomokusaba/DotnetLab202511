# DotnetLab202203

.NET 9 で作成した Blazor WebAssembly アプリです。フォーム入力とデータアノテーションによるバリデーション、QuickGrid を使った一覧表示の例が含まれています。

## 必要環境
- .NET SDK 9.0 以降

## セットアップと実行方法
```bash
# 依存関係の復元
dotnet restore DotnetLab202203.sln

# ビルド
dotnet build DotnetLab202203.sln

# 開発サーバーの起動（ホットリロード対応）
dotnet watch run --project DotnetLab202203
```
ブラウザで `http://localhost:5241`（起動時の出力に表示されるポート）にアクセスしてください。

## アプリの概要
- `/` : 名前と誕生日を入力し、バリデーションを通過したデータを QuickGrid で表示するサンプル
- `/starship` : 複合オブジェクト（Starship と Destination）の入力フォーム。StringLength 制限や子要素の検証結果を表示します。

## プロジェクト構成
- `DotnetLab202203/Pages` : 各画面（Index、StarshipInput など）
- `DotnetLab202203/Models` : 入力モデルとバリデーション属性
- `DotnetLab202203/CustomValidate` : カスタムバリデーション属性
