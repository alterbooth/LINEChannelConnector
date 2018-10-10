using System.Collections.Generic;
using System.Linq;

namespace LINEChannelConnector.Models
{
    public class ButtonsSet : IPrompt
    {
        public string Text { get; set; } = "";

        public IList<ButtonsSetItem> Items { get; set; } = new List<ButtonsSetItem>();

        public ButtonsSet(string text, IList<ButtonsSetItem> items)
        {
            Text = text;
            Items = items;
        }

        public class ButtonsSetItem
        {
            public string Label { get; set; } = "";

            public string Data { get; set; } = "";

            public ButtonsSetItem(string label, string data)
            {
                Label = label;
                Data = data;
            }
        }

        public string AsPrompt()
        {
            if (Items == null || !Items.Any())
            {
                return string.Empty;
            }

            var lines = new List<string> { Text };
            lines.AddRange(Items.Select(item => $"{item.Label}:{item.Data}"));
            return string.Join("|", lines);
        }
    }
}
