using CryptoApi.Models;

namespace CryptoApi.ViewModels
{
    public class CTextBlockBuilder
    {
        private string _titleTmp;
        private string _titleTmpVlues;
        private object? _titleTmpData;

        private string _textTmp;
        private string _textTmpVlues;
        private object? _textTmpData;

        public CTextBlockBuilder SetTitle (string title)
        {
            _titleTmp = title;
            return this;
        }
        public CTextBlockBuilder SetTitleValues(string values)
        {
            _titleTmpVlues = values;
            return this;
        }
        public CTextBlockBuilder SetTitleData(object? data)
        {
            _titleTmpData = data;
            return this;
        }

        public CTextBlockBuilder SetText(string text)
        {
            _textTmp = text;
            return this;
        }
        public CTextBlockBuilder SetTextValues(string values)
        {
            _textTmpVlues = values;
            return this;
        }
        public CTextBlockBuilder SetTextData(object? data)
        {
            _textTmpData = data;
            return this;
        }

        public CTextBlockVM Build ()
        {
            string title = CTextTmpM.Parse(_titleTmp, _titleTmpVlues, _titleTmpData);
            string text = CTextTmpM.Parse(_textTmp, _textTmpVlues, _textTmpData);
            return new CTextBlockVM(title, text);
        }
    }
}
