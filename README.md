# lilToon EmissiveFreak

<p align="center">
  <img src="https://img.shields.io/badge/Unity-2018.3%2B-blue?logo=unity" alt="Unity Version">
  <img src="https://img.shields.io/badge/lilToon-1.9.0%2B-purple" alt="lilToon Version">
  <img src="https://img.shields.io/badge/License-MIT-green" alt="License">
</p>

lilToon の高度なエミッシブエフェクトを実現する拡張パッケージです。パララックス効果、複数のエミッシブレイヤー、アニメーション効果などを提供します。

## ✨ 機能

- **エミッシブパララックス**: 深度に基づくパララックス効果
- **複数エミッシブレイヤー**: 最大 2 つの独立したエミッシブレイヤー
- **アニメーション効果**:
  - 呼吸効果（Breathing）
  - ブリンクアウト効果（BlinkOut）
  - ブリンクイン効果（BlinkIn）
  - 色相シフト（HueShift）
  - UV スクロール
- **マスクシステム**: 各エフェクトに対応したマスクテクスチャサポート
- **深度制御**: エフェクトの深度を個別に制御

## 🔧 インストール

### VPM リポジトリから（推奨）

1. 以下のリンクをクリックしてリポジトリを自動追加: [https://vpm.hinasense.jp/add.html](https://vpm.hinasense.jp/add.html)
2. VCC（VRChat Creator Companion）でプロジェクトに `lilToon EmissiveFreak` を追加

### 手動インストール

1. [リリースページ](https://github.com/hinanoaira/lilToon-emissivefreak/releases) から最新版をダウンロード
2. Unity プロジェクトの `Packages` フォルダに解凍したフォルダを配置

## 📋 必要環境

- **Unity**: 2018.3 以上
- **lilToon**: 1.9.0 以上

## 🎨 使用方法

1. シェーダーを `lilToonFreak/lilToon` に変更
2. インスペクターで `EmissiveFreak` セクションを展開
3. 各種パラメータを調整してエフェクトを設定

### Emission Parallax

- `Texture & Color`: テクスチャ
- `TexCol Mask`: マスク
- `Deapth & Mask`: 深度マスク
- `Invert Depth Mask`: 深度マスクを反転させる

### Emissive Freak 1st & 2nd

各レイヤーで Emission Parallax と同等の設定に加え以下の追加設定が可能：

- **UV アニメーション**:
  - `Scroll U`: U 方向のスクロール速度
  - `Scroll V`: V 方向のスクロール速度
- **Breathing エフェクト**:
  - `Breathing`: 明滅効果
  - `Blink Out`: 明滅うちの滅のみの効果
  - `Blink In`: 明滅のうちの明のみの効果
  - `Hue Shift`: 色相シフトの強度

## 🛠️ 開発者向け情報

### プロジェクト構造

```
Packages/jp.hinasense.liltoon.freak/
├── Editor/
│   ├── CustomInspector.cs          # カスタムインスペクター
│   └── jp.hinasense.liltoon.freak.Editor.asmdef
├── Shader/
│   ├── custom.hlsl                 # メインシェーダーコード
│   ├── custom_insert.hlsl          # シェーダー挿入部分
│   ├── lilCustomShader*.lilblock   # lilToon ブロックファイル
│   └── *.lilcontainer             # 各シェーダーバリアント
├── package.json
├── CHANGELOG.md
└── README.md
```

### カスタマイズ

シェーダーをカスタマイズする場合は、以下のファイルを編集してください：

- `custom.hlsl`: メインのシェーダーロジック
- `custom_insert.hlsl`: 既存シェーダーへの挿入コード
- `CustomInspector.cs`: インスペクター UI

## 📝 更新履歴

詳細な更新履歴は [CHANGELOG.md](CHANGELOG.md) をご覧ください。

## 📄 ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。詳細は [LICENSE](LICENSE) ファイルをご覧ください。

## 🙏 サードパーティライセンス

使用しているサードパーティライブラリのライセンス情報は [THIRD_PARTY_LICENSES.md](THIRD_PARTY_LICENSES.md) をご覧ください。

## 🤝 コントリビューション

バグレポートや機能要求は [Issues](https://github.com/hinanoaira/lilToon-emissivefreak/issues) にお願いします。

## 📞 サポート

- **作者**: HinanoAira
- **Email**: aira@hinasense.jp
- **Website**: https://hinasense.jp

---

<p align="center">
  Made with ❤️ for the VRChat community
</p>
