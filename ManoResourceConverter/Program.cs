﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using MessagePack;

namespace ManoResourceConverter
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("辞書のバージョンを数字で入力してください。");

            int dictionaryVersion;

            try
            {
                dictionaryVersion = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("入力に失敗しました。");
                throw;
            }

            if (dictionaryVersion != 1 && dictionaryVersion != 2)
            {
                Console.WriteLine("不正なバージョンです。プログラムを終了します。");
            }

            var reader = new XmlSerializer(typeof(Serial[]));

            Serial[] data;

            const string Filepath = "manodictionary.xml";

            if (!File.Exists(Filepath))
            {
                Console.WriteLine("manodictionary.xmlが見つかりません");
                return;
            }

            using (var streamReader = new StreamReader(Filepath, Encoding.UTF8))
            {
                data = (Serial[])reader.Deserialize(streamReader);
            }

            var encode = new Dictionary<char, string>();
            var decode = new Dictionary<string, char>();

            foreach (var x in data)
            {
                encode.Add(x.key, x.value);
                decode.Add(x.value, x.key);
            }

            if (!Directory.Exists("Resources"))
            {
                Directory.CreateDirectory("Resources");
            }

            using (var streamWriterEncode = new StreamWriter($@"Resources\ManoEncodeDictionaryVersion{dictionaryVersion}.data"))
            using (var streamWriterDecode = new StreamWriter($@"Resources\ManoDecodeDictionaryVersion{dictionaryVersion}.data"))
            {
                MessagePackSerializer.Serialize(streamWriterEncode.BaseStream, encode);
                MessagePackSerializer.Serialize(streamWriterDecode.BaseStream, decode);
            }

            Console.WriteLine("リソースの変換に成功しました。");
            Console.WriteLine("任意のキーを押すとプログラムを終了します。");
            Console.ReadLine();
        }
    }
}
