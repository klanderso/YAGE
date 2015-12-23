using System.Collections.Generic;
using GameLibrary;

namespace GnomoriaEditor
{
    public class QualityRow
    {
        public ItemQuality Quality { get; set; }
        public string Name { get; set; }

        public QualityRow(ItemQuality quality)
        {
            Quality = quality;
            Name = quality.ToString();
        }

        public static IEnumerable<QualityRow> GetQualities()
        {
            var qualities = new List<QualityRow>();
            for (var i = 0; i < 6; i++)
            {
                qualities.Add(new QualityRow((ItemQuality)i));
            }
            return qualities;
        }
    }
}