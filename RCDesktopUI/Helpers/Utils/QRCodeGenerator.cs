using System.Drawing;
using Zen.Barcode;

namespace RCDesktopUI.Helpers.Utils
{
    public static class QRCodeGenerator
    {
        public static Image Generate(string text, int maxBarHeight)
        {
            CodeQrBarcodeDraw QRCode = BarcodeDrawFactory.CodeQr;

            return QRCode.Draw(text, maxBarHeight);
        }
    }
}
