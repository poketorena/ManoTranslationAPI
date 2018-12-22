using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MessagePack;

namespace ManoTranslationAPI
{
    internal static class ManoTranslator
    {
        private static Dictionary<char, string> encode;
        private static Dictionary<string, char> decode;

        public static string Encode(string str, int dictionaryVersion)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var streamReader = new StreamReader(assembly.GetManifestResourceStream($"ManoTranslationAPI.Resources.ManoEncodeDictionaryVersion{dictionaryVersion}.data"), Encoding.UTF8))
            {
                encode = MessagePackSerializer.Deserialize<Dictionary<char, string>>(streamReader.BaseStream);
            }

            var ret = "";

            foreach (var c in str)
            {
                if (!encode.ContainsKey(c))
                {
                    ret += c;
                    continue;
                }

                ret += encode[c];
            }

            return ret;
        }

        public static string Decode(string str, int dictionaryVersion)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var streamReader = new StreamReader(assembly.GetManifestResourceStream($"ManoTranslationAPI.Resources.ManoDecodeDictionaryVersion{dictionaryVersion}.data"), Encoding.UTF8))
            {
                decode = MessagePackSerializer.Deserialize<Dictionary<string, char>>(streamReader.BaseStream);
            }

            var ret = "";

            const string howa = "ほわっ";
            const string mun = "むんっ";
            var seek = 0;

            var match = "";

            while (seek < str.Length)
            {
                var c = str[seek];

                if (c != howa.First() && c != mun.First())
                {
                    ret += match;
                    ret += c;
                    seek++;
                    match = "";
                    continue;
                }

                if (str.Length - seek < 3)
                {
                    ret += str.Substring(seek);
                    break;
                }

                var s = str.Substring(seek, 3);

                if (s != howa && s != mun)
                {
                    ret += match;
                    ret += c;
                    seek++;
                    match = "";
                    continue;
                }

                match += s;
                seek += 3;

                if (decode.ContainsKey(match))
                {
                    ret += decode[match];
                    match = "";
                    continue;
                }
            }
            ret += match;

            return ret;
        }
    }
}
