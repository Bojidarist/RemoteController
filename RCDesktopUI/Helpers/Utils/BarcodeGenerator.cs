using System.Drawing;
using Zen.Barcode;

namespace RCDesktopUI.Helpers.Utils
{
    public static class BarcodeGenerator
    {
        public static Image Generate(string text, int maxBarHeight)
        {
            Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;

            return barcode.Draw(text, maxBarHeight, 3);
        }
    }
}
