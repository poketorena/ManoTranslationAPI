namespace ManoTranslationAPI
{
    public class RequestBody
    {
        public string Text { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public int DictionaryVersion { get; set; }
    }
}
