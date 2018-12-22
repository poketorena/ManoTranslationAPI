# ManoTranslationAPI

[![Build status](https://ci.appveyor.com/api/projects/status/ceiq28fku7e6m76x?svg=true)](https://ci.appveyor.com/project/poketorena/manotranslationapi)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](LICENSE)

## Description

ManoTranslatorのWebAPI

## Usage

### ja -> mano

Request

```bash
curl -X POST -H "Content-Type: application/json" -d '{"Text": "あいうabc123!?", "SourceLanguage": "ja", "TargetLanguage": "mano"}' https://manotranslationapi.azurewebsites.net/api/translate
```

Response

```bash
{"Data":"むんっむんっほわっむんっむんっほわっむんっほわっむんっむんっむんっむんっほわっむんっむんっむんっむんっむんっほわっほわっむんっむんっほわっむんっむんっほわっむんっむんっほわっほわっむんっむんっほわっむんっむんっむんっむんっむんっむんっほわっむんっほわっむんっほわっほわっむんっむんっほわっほわっほわっほわっむんっむんっほわっほわっほわっむんっほわっむんっほわっむんっむんっほわっほわっむんっむんっむんっむんっむんっほわっほわっむんっほわっむんっほわっほわっむんっむんっむんっむんっほわっむんっむんっほわっほわっほわっほわっむんっほわっ"}
```

### mano -> ja

Request

```bash
curl -X POST -H "Content-Type: application/json" -d '{"Text": "むんっむんっほわっむんっむんっほわっむんっほわっむんっむんっむんっむんっほわっむんっむんっむんっむんっむんっほわっほわっむんっむんっほわっむんっむんっほわっむんっむんっほわっほわっむんっむんっほわっむんっむんっむんっむんっむんっむんっほわっむんっほわっむんっほわっほわっむんっむんっほわっほわっほわっほわっむんっむんっほわっほわっほわっむんっほわっむんっほわっむんっむんっほわっほわっむんっむんっむんっむんっむんっほわっほわっむんっほわっむんっほわっほわっむんっむんっむんっむんっほわっむんっむんっほわっほわっほわっほわっむんっほわっ", "SourceLanguage": "mano", "TargetLanguage": "ja"}' https://manotranslationapi.azurewebsites.net/api/translate
```

Response

```bash
{"Data":"あいうabc123!?"}
```

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
