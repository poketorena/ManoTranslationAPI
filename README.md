# ManoTranslationAPI

[![Build status](https://ci.appveyor.com/api/projects/status/ceiq28fku7e6m76x?svg=true)](https://ci.appveyor.com/project/poketorena/manotranslationapi)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](LICENSE)

## Description

ManoTranslatorのWebAPI

## Usage

### ja -> mano

Request

```bash
curl -X POST -H "Content-Type: application/json" -d '{"Text": "あいうabc123!?", "SourceLanguage": "ja", "TargetLanguage": "mano", "DictionaryVersion": 2}' https://manotranslationapi.azurewebsites.net/api/translate
```

Response

```bash
{"Data":"むんっむんっほわっむんっむんっほわっむんっほわっむんっむんっむんっむんっほわっむんっむんっむんっむんっむんっほわっほわっむんっむんっほわっむんっむんっほわっむんっむんっほわっほわっむんっむんっほわっむんっむんっむんっむんっむんっむんっほわっむんっほわっむんっほわっほわっむんっむんっほわっほわっほわっほわっむんっむんっほわっほわっほわっむんっほわっむんっほわっむんっむんっほわっほわっむんっむんっむんっむんっむんっほわっほわっむんっほわっむんっほわっほわっむんっむんっむんっむんっほわっむんっむんっほわっほわっほわっほわっむんっほわっ"}
```

### mano -> ja

Request

```bash
curl -X POST -H "Content-Type: application/json" -d '{"Text": "むんっむんっほわっむんっむんっほわっむんっほわっむんっむんっむんっむんっほわっむんっむんっむんっむんっむんっほわっほわっむんっむんっほわっむんっむんっほわっむんっむんっほわっほわっむんっむんっほわっむんっむんっむんっむんっむんっむんっほわっむんっほわっむんっほわっほわっむんっむんっほわっほわっほわっほわっむんっむんっほわっほわっほわっむんっほわっむんっほわっむんっむんっほわっほわっむんっむんっむんっむんっむんっほわっほわっむんっほわっむんっほわっほわっむんっむんっむんっむんっほわっむんっむんっほわっほわっほわっほわっむんっほわっ", "SourceLanguage": "mano", "TargetLanguage": "ja", "DictionaryVersion": 2}' https://manotranslationapi.azurewebsites.net/api/translate
```

Response

```bash
{"Data":"あいうabc123!?"}
```

## DictionaryVersion

|Version|対応文字列|
|----|----|
|1 |全角ひらがなのみ|
|2 | 全角ひらがな、半角英数字、半角記号の一部（詳しくは[こちら](https://github.com/para7/ManoTranslator/blob/master/TweetConverter/TweetConverter/Program.cs)）|

バージョン2で辞書に**破壊的変更**が行われました。

よってバージョン1とバージョン2の間に互換性はありません。

## Development Environment

* Windows 10 Home
* Visual Studio 2017 Enterprise

## Dependency

* .NET Core 2.1
* [Azure Functions](https://azure.microsoft.com/ja-jp/services/functions/)
* [ManoTranslator](https://github.com/para7/ManoTranslator)
* [Utf8Json](https://github.com/neuecc/Utf8Json)
* [MessagePack for C#](https://github.com/neuecc/MessagePack-CSharp)

## Author

[@science507](https://twitter.com/science507)
